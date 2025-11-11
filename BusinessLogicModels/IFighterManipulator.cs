using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public interface IFighterManipulator
    {
        /// <summary>
        /// Добавляет бойца в отряд
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="disc">Описание</param>
        /// <param name="hp">Здоровье</param>
        /// <param name="str">Сила</param>
        /// <param name="stam">Выносливость</param>
        /// <param name="weapon">Выбранный тип оружия</param>
        void AddFighter(string name, string disc, int hp, int str, int stam, Weapons weapon);

        /// <summary>
        /// Изменение данных бойца
        /// </summary>
        /// <param name="unit">Юнит</param>
        /// <param name="name">Имя</param>
        /// <param name="disc">Досье</param>
        /// <param name="hp">Здоровье</param>
        /// <param name="str">Сила</param>
        /// <param name="stam">Выносливость</param>
        /// <param name="weapon">Оружие</param>
        void ChangeFighter(Fighter unit, string name, string disc, int hp, int str, int stam, Weapons weapon);

        /// <summary>
        /// Выбрать владельцев определённого типа оружия
        /// </summary>
        /// <param name="weapon">Тип оружия</param>
        /// <returns name="marked">Выбранные юниты</returns>
        List<Character> ChooseMarked(Weapons weapon);
    }
}
