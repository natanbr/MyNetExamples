using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace DI.After
{
    public class RoyalFamilyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register<IKing, King>();
            container.Register<IKing, King>(new ID() {Name = "KingName", Age = 100});
            //container.Register<IFinancier, Financier>();
            container.Register(Component.For<IFinancier>().ImplementedBy<Financier>().Named("Financier").LifeStyle.Transient);
            container.Register(Component.For<IFinancier>().ImplementedBy<FinancierManager>().Named("FinancierManager").LifeStyle.Transient);
            container.Register<ISecretary, ModernSecretary>();
        }
    }
}