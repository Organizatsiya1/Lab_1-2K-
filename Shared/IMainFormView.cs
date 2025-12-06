using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shared
{
    public interface IMainFormView : IView
    {
        /// <summary>
        /// Получить выбранные строки DataGridView (для поединка)
        /// </summary>
        List<Character> GetSelectedCharacters();
    }
}
