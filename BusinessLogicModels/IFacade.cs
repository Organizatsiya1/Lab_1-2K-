using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public interface IFacade : IDisposable
    {
        // Character Service Methods

        /// <summary>
        /// Получает всех юнитов отряда
        /// </summary>
        List<Character> GetUnits();

        /// <summary>
        /// Удаляет юнита из отряда
        /// </summary>
        void DeleteUnit(Character unit);

        /// <summary>
        /// Прочитать данные юнита
        /// </summary>
        string ReadUnit(Character unit);

        /// <summary>
        /// Провести поединок между персонажами
        /// </summary>
        string Fight(Character char1, Character char2);

        // Fighter Service Methods

        /// <summary>
        /// Добавляет бойца в отряд
        /// </summary>
        void AddFighter(string name, string disc, int hp, int str, int stam, Weapons weapon);

        /// <summary>
        /// Изменение данных бойца
        /// </summary>
        void ChangeFighter(Fighter unit, string name, string disc, int hp, int str, int stam, Weapons weapon);

        /// <summary>
        /// Выбрать владельцев определённого типа оружия
        /// </summary>
        List<Character> ChooseMarked(Weapons weapon);

        // Mage Service Methods

        /// <summary>
        /// Добавляет мага в отряд
        /// </summary>
        void AddMage(string name, string disc, int hp, int str, int mana, MagicSchools school);

        /// <summary>
        /// Изменение данных мага
        /// </summary>
        void ChangeMage(Mage unit, string name, string disc, int hp, int str, int mana, MagicSchools school);

        /// <summary>
        /// Выбрать владельцев определённого типа магии
        /// </summary>
        List<Character> ChooseMarked(MagicSchools magic);

        // Normalizer Methods (если нужен прямой доступ)

        /// <summary>
        /// Нормализует имя персонажа
        /// </summary>
        string NormalizeName(string name);

        /// <summary>
        /// Ограничивает числовую характеристику заданным диапазоном
        /// </summary>
        int ClampStat(int value, int min = 0, int max = 100);

        // Композитные методы (если нужны)

        /// <summary>
        /// Получить всех бойцов с определённым оружием и всех магов с определённой школой магии
        /// </summary>
        List<Character> GetSpecializedUnits(Weapons weapon, MagicSchools school);

        /// <summary>
        /// Массовое удаление юнитов
        /// </summary>
        void DeleteUnits(List<Character> units);

        /// <summary>
        /// Получить статистику отряда
        /// </summary>
        string GetSquadStats();
    }
}
