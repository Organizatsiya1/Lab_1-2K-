using BusinessLogic;
using Ninject;
using Presenter;
using Shared;
using System;
using System.Windows.Forms;

namespace WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var kernel = new StandardKernel(new SimpleConfigModule(false));
            var model = kernel.Get<IModel>();

            var mainView = new MainForm();
            var addHeroView = new AddHeroForm();

            var presenter = new MainPresenter(mainView, model, addHeroView);

            Application.Run(mainView);
        }
    }
}