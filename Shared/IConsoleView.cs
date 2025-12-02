using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IConsoleView
    {
        event Action AddDataEvent;
        event Action DeleteDataEvent;
        event Action LoadDataEvent;
        event Action EditDataEvent;
        event Action ExtraFunctionsEvent;
        event Action ChangeRepositoryEvent;

        void ShowMessage(string text);
        void ShowError(string text);
        void ShowUnits(string title, List<Models.Character> units);
        void ShowMenu();
    }
}
