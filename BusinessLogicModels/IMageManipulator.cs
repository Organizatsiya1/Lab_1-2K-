using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public interface IMageManipulator
    {
        /// <summary>
        /// Добавляет мага в отряд
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="disc">Описание</param>
        /// <param name="hp">Здоровье</param>
        /// <param name="str">Сила</param>
        /// <param name="mana">Количество маны</param>
        /// <param name="School">Выбранная школа магии</param>
        void AddMage(string name, string disc, int hp, int str, int mana, MagicSchools school);

        /// <summary>
        /// Изменение данных мага
        /// </summary>
        /// <param name="unit">Юнит</param>
        /// <param name="name">Имя</param>
        /// <param name="disc">Досье</param>
        /// <param name="hp">Здоровье</param>
        /// <param name="str">Сила</param>
        /// <param name="mana">Мана</param>
        /// <param name="School">Тип магии</param>
        void ChangeMage(Mage unit, string name, string disc, int hp, int str, int mana, MagicSchools school);

        /// <summary>
        /// Выбрать владельцев определённого типа магии
        /// </summary>
        /// <param name="magic">Тип магии</param>
        /// <returns name="marked">Выбранные юниты</returns>
        List<Character> ChooseMarked(MagicSchools magic);
    }
}
