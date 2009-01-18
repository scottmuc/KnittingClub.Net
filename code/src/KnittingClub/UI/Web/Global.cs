using System;
using System.Web;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Rhino.Commons;

namespace KnittingClub.UI.Web
{
    public class Global : HttpApplication, IContainerAccessor
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            IWindsorContainer container = new WindsorContainer(new XmlInterpreter());

            IoC.Initialize(container);
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