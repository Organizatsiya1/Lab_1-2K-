using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IConsoleView : IView
    {
        /// <summary>
        /// Метод вывода меню для консольного приложения
        /// </summary>
        void ShowMenu();
    }
}
