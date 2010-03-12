using System;
using System.Web;
using Castle.Windsor;
using KnittingClub.Services.ApplicationStartup;
using Rhino.Commons;

public partial class Global : HttpApplication, IContainerAccessor
{
    protected void Application_Start(object sender, EventArgs e)
    {
        Bootstrapper.ApplicationBegin();
    }

    /// <summary>
    /// Obtain the container.
    /// </summary>
    public IWindsorContainer Container
    {
        get { return IoC.Container; }
    }
}