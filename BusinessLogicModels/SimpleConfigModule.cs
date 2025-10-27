using DataAccessLayer;
using Ninject.Modules;

namespace BusinessLogic
{
    public class SimpleConfigModule : NinjectModule
    {
        private readonly bool _useDapper;

        public SimpleConfigModule(bool useDapper = false)
        {
            _useDapper = useDapper;
        }

        public override void Load()
        {
            if (_useDapper)
            {
                Bind<IUnitOfWork>().To<DapperUnitOfWork>().InSingletonScope();
            }
            else
            {
                Bind<IUnitOfWork>().To<EntityUnitOfWork>().InSingletonScope();
            }
        }
    }
}
