using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace DI.After
{
    public static class CastleExtensions
    {
        public static void Register<TInt, TImp>(this IWindsorContainer container)
            where TInt : class
            where TImp : TInt
        {
            container.Register(
                Component.For<TInt>()
                    .ImplementedBy<TImp>()
                    .LifeStyle.Transient);
        }

        public static void Register<TInt, TImp>(this IWindsorContainer container, string kingsName, int value)
            where TInt : class
            where TImp : TInt
        {
            container.Register(
                Component.For<TInt>()
                    .ImplementedBy<TImp>()
                    //.DependsOn(new {name = kingsName})
                    .DependsOn(new ID(){Name = kingsName, Age = value})
                    .LifeStyle.Transient);
        }

        public static void Register<TInt, TImp>(this IWindsorContainer container, ID id)
           where TInt : class
           where TImp : TInt
        {
            container.Register(
                Component.For<TInt>()
                    .ImplementedBy<TImp>()
                    //.DependsOn(new {name = kingsName})
                    .DependsOn(new {id= id})
                    .LifeStyle.Transient);
        }
    }
}