using Model;
using System.Formats.Asn1;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Business_Logic
{
    public class Logic
    {
        private readonly List<Character> units = new List<Character>();

        // Возвращаем копию текущего списка (безопасно для UI)
        public List<Character> GetUnits()
        {
            return units.ToList();
        }

        /// <summary>
        /// Добавляет бойца в отряд
        /// </summary>
        /// <param name="units">Список всех юнитов - отряд</param>
        public void Add_Fighter(string name, string disc, int hp, int str, int stam, Weapons weapon) 
        {
            Fighter fighter = new Fighter(name, disc, hp, str, stam, weapon);
            units.Add(fighter);
        }
        /// <summary>
        /// Добавляет мага в отряд
        /// </summary>
        /// <param name="units">Список всех юнитов - отряд</param>
        public void Add_Mage(string name, string disc, int hp, int str, int mana, Magic_Schools School) 
        {
            Mage mage = new Mage(name, disc, hp, str, mana, School);
            units.Add(mage);
        }
        /// <summary>
        /// Удаляет юнита из отряда
        /// </summary>
        /// <param name="units">Список всех юнитов - отряд</param>
        /// <param name="unit">Удаляемый юнит</param>
        public void Delete_Unit(Character unit) 
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
        public void Change_Fighter(Fighter unit, string name, string disc, int hp, int str, int stam, Weapons weapon) 
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
        public void Change_Mage(Mage unit, string name, string disc, int hp, int str, int mana, Magic_Schools School)
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
        public string Read_Unit(Character unit) 
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
        /// <param name="units">Список всех юнитов - отряд</param>
        public void Line_Up()
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
        /// <param name="units">Список всех юнитов - отряд</param>
        /// <param name="weapon">Тип оружия</param>
        /// <returns name="marked">Выбранные юниты</returns>
        public List<Character> Choose_Marked(Weapons weapon) 
        {
            var marked = units.Where(p => ((p is Fighter fighter) && (fighter.Weapon==weapon))).ToList();
            return marked;
        }
        /// <summary>
        /// Выбрать владельцев определённого типа магии
        /// </summary>
        /// <param name="units">Список всех юнитов - отряд</param>
        /// <param name="magic">Тип магии</param>
        /// <returns name="marked">Выбранные юниты</returns>
        public List<Character> Choose_Marked(Magic_Schools magic)
        {
            var marked = units.Where(p => ((p is Mage mage) && (mage.School == magic))).ToList();
            return marked;
        }
    }
}
