using Castle.Windsor;
using Castle.Windsor.Installer;

namespace DI.After
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer();

            container.Install(FromAssembly.This());

            DoWork(container);

            container.Dispose();
        }

        private static void DoWork(WindsorContainer container)
        {
            var king = container.Resolve<IKing>();
            king.RuleTheCastle();
        }
    }
}