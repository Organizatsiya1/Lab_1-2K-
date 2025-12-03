using BusinessLogic;
using ConsoleApp;
using Ninject;
using Presenter;
using Shared;

namespace ConsoleAppUI
{
    public class Program
    {
        /// <summary>
        /// Точка запуска консольного приложения
        /// </summary>
        static void Main()
        {
            var kernel = new StandardKernel(new SimpleConfigModule(false));

            var model = kernel.Get<IModel>();
            var view = new ConsoleView();

            var presenter = new MainPresenter(view, model, null, kernel);
        }
    }
}
