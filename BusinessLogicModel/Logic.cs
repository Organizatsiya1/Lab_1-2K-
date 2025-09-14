namespace BusinessLogicModel
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
            NormalizeCommon(name, disc, hp, str, out var nName, out var nDisc, out var nHp, out var nStr);
            mana = ClampStat(mana, 0, 2000);

            Mage mage = new Mage(nName, nDisc, nHp, nStr, mana, School);
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

            NormalizeCommon(name, disc, hp, str, out var nName, out var nDisc, out var nHp, out var nStr);
            stam = ClampStat(stam, 0, 1000);

            unit.Name = nName;
            unit.Description = nDisc;
            unit.HP = nHp;
            unit.Strength = nStr;
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

            NormalizeCommon(name, disc, hp, str, out var nName, out var nDisc, out var nHp, out var nStr);
            mana = ClampStat(mana, 0, 2000);

            unit.Name = nName;
            unit.Description = nDisc;
            unit.HP = nHp;
            unit.Strength = nStr;
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
            string mes = "Поединок завершён\n";
            char1.HP-=char2.Strength;
            char2.HP-=char1.Strength;
            if (char1.HP<=0) 
            {
                DeleteUnit(char1);
                mes += $"{char1.Name} выбывает из группы\n";
            }
            if (char2.HP <= 0) 
            {
                DeleteUnit(char2);
                mes += $"{char2.Name} выбывает из группы\n";
            }
            return mes;
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
