using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using KnittingClub.Utility;
using Rhino.Commons;

namespace KnittingClub.Services.ApplicationStartup
{
    public class ContainerBootstrapper : ICommand
    {
        public static void ApplicationBegin() 
        {
            new ContainerBootstrapper().Execute();
        }

        public void Execute()
        {
            IWindsorContainer container = new WindsorContainer(new XmlInterpreter());

            IoC.Initialize(container);
        }
    }
}