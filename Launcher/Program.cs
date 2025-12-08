using BusinessLogic;
using Ninject;
using Shared;
using System;
using System.Windows.Forms;
using WinFormsApp;
using ConsoleAppUI;

namespace Presenter
{
    internal static class Program
    {
        /// <summary>
        /// ТОЧКА СБОРКИ - здесь решаем, какое приложение запускать
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("Выберите режим приложения:");
            Console.WriteLine("1 - Консольное приложение");
            Console.WriteLine("2 - Windows Forms приложение");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine()?.Trim();

            if (choice == "1")
            {
                Console.WriteLine("Запуск консольного приложения...");
                RunConsoleApp();
            }
            else if (choice == "2")
            {
                Console.WriteLine("Запуск Windows Forms приложения...");
                RunWinFormsApp();
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
            }
        }

        /// <summary>
        /// Метод запуска консольного приложения
        /// </summary>
        static void RunConsoleApp()
        {
            var kernel = new StandardKernel(new SimpleConfigModule(false));

            var view = new ConsoleView();
            var model = kernel.Get<IModel>();
            var presenter = new MainPresenter(view, model, null, kernel);
        }

        /// <summary>
        /// Метод запуска Windows Forms приложения
        /// </summary>
        [STAThread]
        static void RunWinFormsApp()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var kernel = new StandardKernel(new SimpleConfigModule(false));

            var view = new MainForm();
            var addHeroView = new AddHeroForm();
            var model = kernel.Get<IModel>();

            var presenter = new MainPresenter(view, model, addHeroView, kernel);

            Application.Run(view);
        }
    }
}
