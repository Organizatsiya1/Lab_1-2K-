using Models;
using System;
using System.Windows.Forms;

namespace Shared
{
    public interface IAddHeroView
    {
        event Action SaveEvent;
        event Action CancelEvent;

        /// <summary>
        /// Имя героя, связывает свойство с текстовым полем ввода имени
        /// </summary>
        string HeroName { get; }

        /// <summary>
        /// Описание героя, связывает свойство с текстовым полем ввода описания
        /// </summary>
        string HeroDescription { get; }

        /// <summary>
        /// Здоровье героя. Связывает свойство с числовым полем ввода HP.
        /// </summary>
        int HeroHP { get; }

        /// <summary>
        /// Сила героя, связывает свойство с числовым полем ввода силы
        /// </summary>
        int HeroStrength { get; }

        /// <summary>
        /// Определяет, является ли герой воином на основе выбранного типа в комбо-боксе
        /// </summary>
        bool IsFighter { get; }

        /// <summary>
        /// Определяет, является ли герой магом на основе выбранного типа в комбо-боксе
        /// </summary>
        bool IsMage { get; }

        /// <summary>
        /// Выносливость героя, связывает свойство с числовым полем ввода выносливости
        /// </summary>
        int HeroStamina { get; }

        /// <summary>
        /// Мана героя, связывает свойство с числовым полем ввода маны
        /// </summary>
        int HeroMana { get; }

        /// <summary>
        /// Выбранное оружие для воина
        /// Преобразует отображаемое имя оружия в значение перечисления Weapons
        /// </summary>
        /// <returns>Если выбранный элемент не найден, возвращает Weapons.None</returns>
        Weapons SelectedWeapon { get; }

        /// <summary>
        /// Выбранная школа магии для мага
        /// Преобразует отображаемое имя школы магии в значение перечисления MagicSchools
        /// </summary>
        /// <returns>Если выбранный элемент не найден, возвращает MagicSchools.Fire</returns>
        MagicSchools SelectedSchool { get; }

        Character CreatedHero { get; }

        /// <summary>
        /// Заполняет поля формы значениями из переданного объекта
        /// Дизайнер видимости определенных полей для война и мага
        /// </summary>
        /// <param name="character">Существующий персонаж для отображения в форме. Если null — ничего не делает</param>
        void LoadCharacter(Character character);

        /// <summary>
        /// Очистка формы, приведение к презентабельному виду формы (обозначение начальных данных)
        /// </summary>
        void SetCreateMode();

        /// <summary>
        /// Отображает форму как отдельное диалоговое окно
        /// </summary>
        /// <returns>Одно из значений перечисления DialogResult, указывающее результат диалога</returns>
        DialogResult ShowDialog();

        /// <summary>
        /// Метод показа формы
        /// </summary>
        void Show();

        /// <summary>
        /// Метод закрытия формы
        /// </summary>
        void Close();
    }
}
