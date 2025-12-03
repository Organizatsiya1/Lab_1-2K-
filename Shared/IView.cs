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
        
        event Action FightEvent;
        event Action<string> FilterFightersEvent;
        event Action<string> FilterMagesEvent;
        
        event Action<bool> ChangeRepositoryEvent;

        // Методы, через которые Presenter управляет View

        /// <summary>
        /// Обновить отображение списка персонажей
        /// </summary>
        void Redraw(List<Character> units);

        /// <summary>
        /// Получить выбранного персонажа
        /// </summary>
        Character GetSelectedCharacter();

        /// <summary>
        /// Показать информационное сообщение
        /// </summary>
        void ShowMessage(string text);

        /// <summary>
        /// Показать сообщение об ошибке
        /// </summary>
        void ShowError(string text);
    }
}
