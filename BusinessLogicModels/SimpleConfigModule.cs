using BusinessLogicModels;
using DataAccessLayer;
using Ninject.Modules;
using Shared;

namespace BusinessLogic
{
    public class SimpleConfigModule : NinjectModule
    {
        private readonly bool _useDapper;

        public SimpleConfigModule(bool useDapper = false)
        {
            _useDapper = useDapper;
        }

        /// <summary>
        /// Настраивает DI контейнер (Ninject) для регистрации всех зависимостей приложения
        /// </summary>
        public override void Load()
        {
            // Биндинг UnitOfWork
            if (_useDapper)
            {
                Bind<IUnitOfWork>().To<DapperUnitOfWork>().InSingletonScope();
            }
            else
            {
                Bind<IUnitOfWork>().To<EntityUnitOfWork>().InSingletonScope();
            }

            // Биндинг сервисов
            Bind<IStandartizer>().To<Standartizer>().InSingletonScope();
            Bind<ICharManipulator>().To<CharacterLogic>().InSingletonScope();
            Bind<IFighterManipulator>().To<FighterLogic>().InSingletonScope();
            Bind<IMageManipulator>().To<MageLogic>().InSingletonScope();

            // Биндинг фасада
            Bind<IFacade>().To<Facade>().InSingletonScope();
            Bind<IModel>().To<Facade>().InSingletonScope();
        }
    }
}
