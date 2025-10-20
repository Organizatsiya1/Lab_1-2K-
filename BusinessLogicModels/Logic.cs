using DataAccessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Logic
    {
        private IUnitOfWork _unitOfWork;

        public Logic(bool useDapper)
        {
            if (useDapper)
            {
                _unitOfWork = new DapperUnitOfWork();
            }
            else
            {
                _unitOfWork = new EntityUnitOfWork();
            }
        }

        /// <summary>
        /// Получает всех юнитов отряда
        /// </summary>
        /// <returns>Список юнитов</returns>
        public List<Character> GetUnits()
        {
            var fighters = _unitOfWork.Fighters.ReadAll().Cast<Character>();
            var mages = _unitOfWork.Mages.ReadAll().Cast<Character>();
            return fighters.Concat(mages).ToList();
        }

        /// <summary>
        /// Нормализует имя персонажа (заменяет пустое на "Безымянный")
        /// </summary>
        /// <param name="name">Исходное имя</param>
        /// <returns>Нормализованная строка</returns>
        private string NormalizeName(string name)
        {
            return string.IsNullOrWhiteSpace(name) ? "Безымянный" : name.Trim();
        }

        /// <summary>
        /// Ограничивает числовую характеристику заданным диапазоном
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="min">Минимум = 0</param>
        /// <param name="max">Максимум = 100</param>
        /// <returns></returns>
        private int ClampStat(int value, int min = 0, int max = 100)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        /// <summary>
        /// Нормализация общего набора полей
        /// c out-параметрами
        /// </summary>
        /// <param name="name">Имя персонажа</param>
        /// <param name="desc">Описание</param>
        /// <param name="hp">Значение здоровья</param>
        /// <param name="str">Значение силы</param>
        /// <param name="outName">Нормализованное имя</param>
        /// <param name="outDisc">Нормализованное описание</param>
        /// <param name="outHp">Исправленное значение здоровья</param>
        /// <param name="outStr">Исправленное значение силы</param>
        private void NormalizeCommon(string name, string desc, int hp, int str,
            out string outName, out string outDisc, out int outHp, out int outStr)
        {
            const int hpMax = 100;
            const int strMax = 10;

            outName = NormalizeName(name);
            outDisc = desc ?? "";
            outHp = ClampStat(hp, 0, hpMax);
            outStr = ClampStat(str, 0, strMax);
        }

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
            NormalizeCommon(name, disc, hp, str, out var nName, out var nDisc, out var nHp, out var nStr);
            stam = ClampStat(stam, 0, 1000);

            // Проверяем, что weapon — действительно определён в enum, иначе ставим None
            if (!Enum.IsDefined(typeof(Weapons), weapon))
                weapon = Weapons.None;

            Fighter fighter = new Fighter(nName, nDisc, nHp, nStr, stam, weapon);
            _unitOfWork.Fighters.Create(fighter);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Добавляет мага в отряд
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="disc">Описание</param>
        /// <param name="hp">Здоровье</param>
        /// <param name="str">Сила</param>
        /// <param name="mana">Количество маны</param>
        /// <param name="School">Выбранная школа магии</param>
        public void AddMage(string name, string disc, int hp, int str, int mana, MagicSchools School)
        {
            NormalizeCommon(name, disc, hp, str, out var nName, out var nDisc, out var nHp, out var nStr);
            mana = ClampStat(mana, 0, 2000);

            Mage mage = new Mage(nName, nDisc, nHp, nStr, mana, School);
            _unitOfWork.Mages.Create(mage);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Удаляет юнита из отряда
        /// </summary>
        /// <param name="unit">Удаляемый юнит</param>
        public void DeleteUnit(Character unit)
        {
            if (unit == null) return;

            if (unit is Fighter f)
                _unitOfWork.Fighters.Delete(f);
            else if (unit is Mage m)
                _unitOfWork.Mages.Delete(m);

            _unitOfWork.SaveChanges();
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
            if (unit == null) return;

            NormalizeCommon(name, disc, hp, str, out var nName, out var nDisc, out var nHp, out var nStr);
            stam = ClampStat(stam, 0, 1000);

            unit.Name = nName;
            unit.Description = nDisc;
            unit.HP = nHp;
            unit.Strength = nStr;
            unit.Weapon = weapon;
            unit.Stamina = stam;
            _unitOfWork.Fighters.Update(unit);
            _unitOfWork.SaveChanges();
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
        public void ChangeMage(Mage unit, string name, string disc, int hp, int str, int mana, MagicSchools School)
        {
            if (unit == null) return;

            NormalizeCommon(name, disc, hp, str, out var nName, out var nDisc, out var nHp, out var nStr);
            mana = ClampStat(mana, 0, 2000);

            unit.Name = nName;
            unit.Description = nDisc;
            unit.HP = nHp;
            unit.Strength = nStr;
            unit.Mana = mana;
            unit.School = School;
            _unitOfWork.Mages.Update(unit);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Прочитать данные юнита
        /// </summary>
        /// <param name="unit">Юнит</param>
        /// <returns name="info">Прочитанная информация</returns>
        public string ReadUnit(Character unit)
        {
            if (unit == null) return "";

            string info = "";
            var properties = unit.GetType().GetProperties();
            foreach (var property in properties)
            {
                info += $"{property.Name}: {property.GetValue(unit)}\n";
            }

            if (unit is Mage)
            {
                info += $"Выносливость: 0\n";
                info += $"Оружие: {Displays.WeaponsNames[Weapons.None]}\n";
            }
            else if (unit is Fighter)
            {
                info += $"Мана: 0\n";
                info += $"Школа магии: -\n";
            }

            return info;
        }

        /// <summary>
        /// Метод, проводящий поединок между персонажами, если здоровье кого-то опускается до 0 и ниже, он выбывает из списка
        /// </summary>
        /// <param name="char1">Первый персонаж</param>
        /// <param name="char2">Второй персонаж</param>
        public string Fight(Character char1, Character char2)
        {
            string mes = "\t\tПоединок\n";
            mes += $"\n{char1.Name} (Здоровье: {char1.HP})  vs  {char2.Name} (Здоровье: {char2.HP})\n\n";

            int damageTo1 = char2.Strength;
            int damageTo2 = char1.Strength;

            mes += $"{char1.Name} получает {damageTo1} урона\n";
            mes += $"{char2.Name} получает {damageTo2} урона\n\n";

            char1.HP -= damageTo1;
            char2.HP -= damageTo2;

            // отрицательного здоровья нет - минимум 0
            if (char1.HP < 0) char1.HP = 0;
            if (char2.HP < 0) char2.HP = 0;

            mes += $"Статусы после удара: {char1.Name}: {char1.HP} единиц здоровья, {char2.Name}: {char2.HP} единиц здоровья\n\n";

            if (char1.HP == 0 && char2.HP == 0)
            {
                DeleteUnit(char1);
                DeleteUnit(char2);
                mes += "Оба бойца выбиты из группы.\n";
            }
            else if (char1.HP == 0)
            {
                DeleteUnit(char1);
                mes += $"{char1.Name} выбывает из группы\n";
            }
            else if (char2.HP == 0)
            {
                DeleteUnit(char2);
                mes += $"{char2.Name} выбывает из группы\n";
            }
            else
            {
                mes += "Оба выжили. Поединок окончен\n";

                // Обновляем данные в БД
                if (char1 is Fighter f1)
                    _unitOfWork.Fighters.Update(f1);
                else if (char1 is Mage m1)
                    _unitOfWork.Mages.Update(m1);

                if (char2 is Fighter f2)
                    _unitOfWork.Fighters.Update(f2);
                else if (char2 is Mage m2)
                    _unitOfWork.Mages.Update(m2);

                _unitOfWork.SaveChanges();
            }

            mes += "\nПоединок завершён\n";
            return mes;
        }

        /// <summary>
        /// Выбрать владельцев определённого типа оружия
        /// </summary>
        /// <param name="weapon">Тип оружия</param>
        /// <returns name="marked">Выбранные юниты</returns>
        public List<Character> ChooseMarked(Weapons weapon)
        {
            var marked = _unitOfWork.Fighters.ReadAll()
                .Where(f => f.Weapon == weapon)
                .Cast<Character>()
                .ToList();
            return marked;
        }

        /// <summary>
        /// Выбрать владельцев определённого типа магии
        /// </summary>
        /// <param name="magic">Тип магии</param>
        /// <returns name="marked">Выбранные юниты</returns>
        public List<Character> ChooseMarked(MagicSchools magic)
        {
            var marked = _unitOfWork.Mages.ReadAll()
                .Where(f => f.School == magic)
                .Cast<Character>()
                .ToList();
            return marked;
        }

        /// <summary>
        /// Освобождение ресурсов
        /// </summary>
        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
