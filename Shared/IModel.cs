using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IModel
    {
        // Событие из лекции, оно отправляется при изменении данных
        event Action DataChanged;

        // Character Service Methods

        /// <summary>
        /// Получает всех юнитов отряда
        /// </summary>
        /// <returns>Список юнитов</returns>
        List<Character> GetUnits();

        /// <summary>
        /// Удаляет юнита из отряда
        /// </summary>
        /// <param name="unit">Удаляемый юнит</param>
        void DeleteUnit(Character unit);

        /// <summary>
        /// Прочитать данные юнита
        /// </summary>
        /// <param name="unit">Юнит</param>
        /// <returns name="info">Прочитанная информация</returns>
        string ReadUnit(Character unit);

        /// <summary>
        /// Метод, проводящий поединок между персонажами, если здоровье кого-то опускается до 0 и ниже, он выбывает из списка
        /// </summary>
        /// <param name="char1">Первый персонаж</param>
        /// <param name="char2">Второй персонаж</param>
        string Fight(Character char1, Character char2);

        // Fighter Service Methods

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

        // Mage Service Methods

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

        // Normalizer Methods

        /// <summary>
        /// Нормализует имя персонажа (заменяет пустое на "Безымянный")
        /// </summary>
        /// <param name="name">Исходное имя</param>
        /// <returns>Нормализованная строка</returns>
        string NormalizeName(string name);

        /// <summary>
        /// Ограничивает числовую характеристику заданным диапазоном
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="min">Минимум = 0</param>
        /// <param name="max">Максимум = 100</param>
        /// <returns>Нормализованное значение</returns>
        int ClampStat(int value, int min = 0, int max = 100);

        // Composite Methods

        /// <summary>
        /// Получить всех бойцов с определённым оружием и всех магов с определённой школой магии
        /// </summary>
        /// <param name="weapon">Выбранное оружие</param>
        /// <param name="school">Выбранная школа магии</param>
        /// <returns>Список персонажей с определенными оружием и школой магии</returns>
        List<Character> GetSpecializedUnits(Weapons weapon, MagicSchools school);

        /// <summary>
        /// Массовое удаление юнитов
        /// </summary>
        /// <param name="units">Удаляемые персонажи</param>
        void DeleteUnits(List<Character> units);

        /// <summary>
        /// Получить статистику отряда
        /// </summary>
        /// <returns name="stats">Полученные характеристики персонажей</returns>
        string GetSquadStats();
    }
}
