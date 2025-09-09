using System.Formats.Asn1;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace BusinessLogic
{
    public class Logic
    {
        private readonly List<Character> units = new List<Character>();

        /// <summary>
        /// Возвращаемый список — независимая копия,
        /// чтобы внешний код (UI) не мог напрямую изменить внутренний список Logic
        /// </summary>
        /// <returns>Копия текущего списка юнитов</returns>
        public List<Character> GetUnits()
        {
            return units.ToList();
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
            Fighter fighter = new Fighter(name, disc, hp, str, stam, weapon);
            units.Add(fighter);
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
            Mage mage = new Mage(name, disc, hp, str, mana, School);
            units.Add(mage);
        }

        /// <summary>
        /// Удаляет юнита из отряда
        /// </summary>
        /// <param name="unit">Удаляемый юнит</param>
        public void DeleteUnit(Character unit) 
        {
            if (unit == null) return;
            units.Remove(unit); 
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
            unit.Name = name;
            unit.Description = disc;
            unit.HP = hp;
            unit.Strength = str;
            unit.Weapon = weapon;
            unit.Stamina = stam;
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
            unit.Name = name;
            unit.Description = disc;
            unit.HP = hp;
            unit.Strength = str;
            unit.Mana = mana;
            unit.School = School;
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
            return info;
        }

        /// <summary>
        /// Построить юнитов - сгруппировать: сначала бойцы - потом маги
        /// </summary>
        public void LineUp()
        {
            var linedUp = units.OrderBy(c => c is Fighter fighter ? 0 : 1).ToList();

            // нужно переставить элементы в исходном списке (в методе-параметре),
            // присваивание units = linedUp меняло только локальную ссылку
            units.Clear();
            units.AddRange(linedUp);
        }

        /// <summary>
        /// Выбрать владельцев определённого типа оружия
        /// </summary>
        /// <param name="weapon">Тип оружия</param>
        /// <returns name="marked">Выбранные юниты</returns>
        public List<Character> ChooseMarked(Weapons weapon) 
        {
            var marked = units.Where(p => ((p is Fighter fighter) && (fighter.Weapon==weapon))).ToList();
            return marked;
        }

        /// <summary>
        /// Выбрать владельцев определённого типа магии
        /// </summary>
        /// <param name="magic">Тип магии</param>
        /// <returns name="marked">Выбранные юниты</returns>
        public List<Character> ChooseMarked(MagicSchools magic)
        {
            var marked = units.Where(p => ((p is Mage mage) && (mage.School == magic))).ToList();
            return marked;
        }
    }
}
