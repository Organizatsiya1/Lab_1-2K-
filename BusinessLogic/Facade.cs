using Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicModels
{
    public class Facade : IFacade, IModel
    {
        public event Action DataChanged;

        private readonly ICharManipulator _characterLogic;
        private readonly IFighterManipulator _fighterLogic;
        private readonly IMageManipulator _mageLogic;
        private readonly IStandartizer _standartizer;

        public Facade(ICharManipulator characterService,
                         IFighterManipulator fighterService,
                         IMageManipulator mageService,
                         IStandartizer normalizer)
        {
            _characterLogic = characterService;
            _fighterLogic = fighterService;
            _mageLogic= mageService;
            _standartizer = normalizer;
        }

        // === Character Service Methods ===

        /// <summary>
        /// Получает всех юнитов отряда
        /// </summary>
        /// <returns>Список юнитов</returns>
        public List<Character> GetUnits() => _characterLogic.GetUnits();

        /// <summary>
        /// Удаляет юнита из отряда
        /// </summary>
        /// <param name="unit">Удаляемый юнит</param>
        public void DeleteUnit(Character unit)
        {
            _characterLogic.DeleteUnit(unit);
            DataChanged?.Invoke();
        }

        /// <summary>
        /// Прочитать данные юнита
        /// </summary>
        /// <param name="unit">Юнит</param>
        /// <returns name="info">Прочитанная информация</returns>
        public string ReadUnit(Character unit) => _characterLogic.ReadUnit(unit);

        /// <summary>
        /// Метод, проводящий поединок между персонажами, если здоровье кого-то опускается до 0 и ниже, он выбывает из списка
        /// </summary>
        /// <param name="char1">Первый персонаж</param>
        /// <param name="char2">Второй персонаж</param>
        public string Fight(Character char1, Character char2) => _characterLogic.Fight(char1, char2);

        // === Fighter Service Methods ===

        /// <summary>
        /// Добавляет бойца в отряд
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="disc">Описание</param>
        /// <param name="hp">Здоровье</param>
        /// <param name="str">Сила</param>
        /// <param name="stam">Выносливость</param>
        /// <param name="weapon">Выбранный тип оружия</param>
        public void AddFighter(string name, string disc, int hp, int str, int stam, Weapons weapon)
        {
            _fighterLogic.AddFighter(name, disc, hp, str, stam, weapon);
            DataChanged?.Invoke();
        }

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
        public void ChangeFighter(Fighter unit, string name, string disc, int hp, int str, int stam, Weapons weapon)
        {
            _fighterLogic.ChangeFighter(unit, name, disc, hp, str, stam, weapon);
            DataChanged?.Invoke();
        }

        /// <summary>
        /// Выбрать владельцев определённого типа оружия
        /// </summary>
        /// <param name="weapon">Тип оружия</param>
        /// <returns name="marked">Выбранные юниты</returns>
        public List<Character> ChooseMarked(Weapons weapon) => _fighterLogic.ChooseMarked(weapon);

        // === Mage Service Methods ===

        /// <summary>
        /// Добавляет мага в отряд
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="disc">Описание</param>
        /// <param name="hp">Здоровье</param>
        /// <param name="str">Сила</param>
        /// <param name="mana">Количество маны</param>
        /// <param name="School">Выбранная школа магии</param>
        public void AddMage(string name, string disc, int hp, int str, int mana, MagicSchools school)
        {
            _mageLogic.AddMage(name, disc, hp, str, mana, school);
            DataChanged?.Invoke();
        }

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
        public void ChangeMage(Mage unit, string name, string disc, int hp, int str, int mana, MagicSchools school)
        {
            _mageLogic.ChangeMage(unit, name, disc, hp, str, mana, school);
            DataChanged?.Invoke();
        }

        /// <summary>
        /// Выбрать владельцев определённого типа магии
        /// </summary>
        /// <param name="magic">Тип магии</param>
        /// <returns name="marked">Выбранные юниты</returns>
        public List<Character> ChooseMarked(MagicSchools magic) => _mageLogic.ChooseMarked(magic);

        // === Normalizer Methods (если нужен прямой доступ) ===

        /// <summary>
        /// Нормализует имя персонажа (заменяет пустое на "Безымянный")
        /// </summary>
        /// <param name="name">Исходное имя</param>
        /// <returns>Нормализованная строка</returns>
        public string NormalizeName(string name) => _standartizer.StandartizeName(name);

        /// <summary>
        /// Ограничивает числовую характеристику заданным диапазоном
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="min">Минимум = 0</param>
        /// <param name="max">Максимум = 100</param>
        /// <returns>Нормализованное значение</returns>
        public int ClampStat(int value, int min = 0, int max = 100) => _standartizer.ClampStat(value, min, max);

        // === Композитные методы (если нужны) ===

        /// <summary>
        /// Получить всех бойцов с определённым оружием и всех магов с определённой школой магии
        /// </summary>
        /// <param name="weapon">Выбранное оружие</param>
        /// <param name="school">Выбранная школа магии</param>
        /// <returns>Список персонажей с определенными оружием и школой магии</returns>
        public List<Character> GetSpecializedUnits(Weapons weapon, MagicSchools school)
        {
            var fightersWithWeapon = _fighterLogic.ChooseMarked(weapon);
            var magesWithSchool = _mageLogic.ChooseMarked(school);

            return fightersWithWeapon.Concat(magesWithSchool).ToList();
        }

        /// <summary>
        /// Массовое удаление юнитов
        /// </summary>
        /// <param name="units">Удаляемые персонажи</param>
        public void DeleteUnits(List<Character> units)
        {
            foreach (var unit in units)
            {
                _characterLogic.DeleteUnit(unit);
            }
        }

        /// <summary>
        /// Получить статистику отряда
        /// </summary>
        /// <returns name="stats">Полученные характеристики персонажей</returns>
        public string GetSquadStats()
        {
            var units = _characterLogic.GetUnits();
            var stats = new StringBuilder();

            stats.AppendLine($"Всего юнитов: {units.Count}");
            stats.AppendLine($"Бойцов: {units.OfType<Fighter>().Count()}");
            stats.AppendLine($"Магов: {units.OfType<Mage>().Count()}");
            stats.AppendLine($"Общее здоровье: {units.Sum(u => u.HP)}");
            stats.AppendLine($"Общая сила: {units.Sum(u => u.Strength)}");

            return stats.ToString();
        }

        // === Dispose Pattern ===

        /// <summary>
        /// Освобождение ресурсов (только те ресурсы, которые реализуют IDisposable)
        /// </summary>
        public void Dispose()
        {
            (_characterLogic as IDisposable)?.Dispose();
            (_fighterLogic as IDisposable)?.Dispose();
            (_mageLogic as IDisposable)?.Dispose();
        }
    }
}
