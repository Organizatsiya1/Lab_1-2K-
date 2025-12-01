using Models;
using System;
using System.Collections.Generic;

namespace Shared
{
    public interface IView
    {
        event Action AddDataEvent;
        event Action DeleteDataEvent;
        event Action EditDataEvent;
        event Action LoadDataEvent;

        // Методы, через которые Presenter управляет View
        void Redraw(List<Character> units);
        Character GetSelectedCharacter();
        void ShowMessage(string text);
        void ShowError(string text);

    }
}
