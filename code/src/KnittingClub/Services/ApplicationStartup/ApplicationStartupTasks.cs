using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Rhino.Commons;

namespace KnittingClub.Services.ApplicationStartup
{
    public class ApplicationStartupTasks : ICommand
    {
        public static void ApplicationBegin() 
        {
            new ApplicationStartupTasks().Execute();
        }

        public void Execute()
        {
            IWindsorContainer container = new WindsorContainer(new XmlInterpreter());

            IoC.Initialize(container);
        }
    }

    public interface ICommand
    {
        void Execute();
    }
}