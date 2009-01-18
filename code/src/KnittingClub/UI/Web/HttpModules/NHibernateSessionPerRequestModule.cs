using System;
using System.Web;
using Castle.Facilities.NHibernateIntegration;
using Castle.MicroKernel.Facilities;
using Castle.Windsor;
using NHibernate;

namespace KnittingClub.UI.Web.HttpModules
{
    public class NHibernateSessionPerRequestModule : IHttpModule 
    {
        protected static readonly String SessionKey = "SessionWebModule.session";

        public void Dispose() 
        {
        }

        public void Init(HttpApplication context) 
        {
            context.BeginRequest += Application_BeginRequest;
            context.EndRequest += Application_EndRequest;
        }


        private void Application_BeginRequest(object sender, EventArgs e) 
        {
			IWindsorContainer container = ObtainContainer();

			var sessManager = (ISessionManager) container[ typeof(ISessionManager) ];

            ISession session = sessManager.OpenSession();

			HttpContext.Current.Items.Add(SessionKey, session);

            session.BeginTransaction();

        }

        private void Application_EndRequest(object sender, EventArgs e) 
        {
            ISession session = (ISession) HttpContext.Current.Items[SessionKey];

            if (session != null)
            {
                try
                {
                    session.Transaction.Commit();
                }
                catch (Exception)
                {
                    session.Transaction.Rollback();
                }
                finally
                {
                    session.Close();                    
                }
            }


            HttpContext.Current.Trace.Write("ISession Closed"); 
        }

		private static IWindsorContainer ObtainContainer()
		{
			IContainerAccessor containerAccessor = 
				HttpContext.Current.ApplicationInstance as IContainerAccessor;
	
			if (containerAccessor == null)
			{
				throw new FacilityException("You must extend the HttpApplication in your web project " + 
					"and implement the IContainerAccessor to properly expose your container instance");
			}
	
			IWindsorContainer container = containerAccessor.Container;
	
			if (container == null)
			{
				throw new FacilityException("The container seems to be unavailable (null) in " + 
					"your HttpApplication subclass");
			}
			return container;
		}

    }
}