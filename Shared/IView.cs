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
        /// Выводит список всех персонажей с их характеристиками
        /// </summary>
        /// <param name="characters">Список персонажей</param>
        void Redraw(List<Character> characters);

        /// <summary>
        /// Получить выбранного персонажа
        /// </summary>
        /// <returns>Выбранный персонаж</returns>
        Character GetSelectedCharacter();

        /// <summary>
        /// Показ сообщения пользователю
        /// </summary>
        /// <param name="text">Текст сообщения</param>
        void ShowMessage(string text);

        /// <summary>
        /// Показ сообщения-ошибки пользователю
        /// </summary>
        /// <param name="text">Текст сообщения-ошибки</param>
        void ShowError(string text);
    }
}
