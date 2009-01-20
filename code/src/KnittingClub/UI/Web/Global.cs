using System;
using System.Web;
using Castle.Windsor;
using KnittingClub.Services.ApplicationStartup;
using Rhino.Commons;

namespace KnittingClub.UI.Web
{
    public class Global : HttpApplication, IContainerAccessor
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ContainerBootstrapper.ApplicationBegin();
        }

		/// <summary>
		/// Obtain the container.
		/// </summary>
		public IWindsorContainer Container
		{
			get { return IoC.Container; }
		}
    }
}