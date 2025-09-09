using Business_Logic;
using Model;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        static Logic logic = new Logic();

        /// <summary>
        /// Точка входа в консольное приложение с запуском консольного меню
        /// </summary>
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Гильдия искателей приключений");
                Console.WriteLine("Добро пожаловать!");
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Создать персонажа");
                Console.WriteLine("2. Удалить персонажа");
                Console.WriteLine("3. Показать всех персонажей");
                Console.WriteLine("4. Изменить персонажа");
                Console.WriteLine("5. Дополнительные функции");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateCharacter();
                        break;
                    case "2":
                        DeleteCharacter();
                        break;
                    case "3":
                        ShowAll();
                        break;
                    case "4":
                        EditCharacter();
                        break;
                    case "5":
                        ExtraFunctions();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод, попробуйте снова");
                        break;
                }

                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Создает персонажа через консольный ввод и добавляет его в логику
        /// </summary>
        static void CreateCharacter()
        {
            Console.Clear();
            Console.WriteLine("Создание персонажа");
            Console.Write("Тип (1 - Воин, 2 - Маг): ");
            var t = Console.ReadLine();

            Console.Write("Имя: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Описание: ");
            string desc = Console.ReadLine() ?? "";

            int hp = ReadInt("HP", 100);
            int str = ReadInt("Сила", 10);

            if (t == "1")
            {
                int stam = ReadInt("Выносливость", 20);
                Console.WriteLine("Оружие: " + string.Join(", ", Enum.GetNames(typeof(Weapons))));
                Console.Write("Выберите оружие (например Sword): ");
                string w = Console.ReadLine();
                Weapons weapon;
                if (!Enum.TryParse<Weapons>(w, true, out weapon))
                    weapon = Weapons.None;

                logic.Add_Fighter(name, desc, hp, str, stam, weapon);
                Console.WriteLine("Воин добавлен.");
            }
            else if (t == "2")
            {
                int mana = ReadInt("Мана", 50);
                Console.WriteLine("Школы магии: " + string.Join(", ", Enum.GetNames(typeof(Magic_Schools))));
                Console.Write("Выберите школу (например Fire): ");
                string s = Console.ReadLine();
                Magic_Schools school;
                if (!Enum.TryParse<Magic_Schools>(s, true, out school))
                    school = Magic_Schools.Fire;

                logic.Add_Mage(name, desc, hp, str, mana, school);
                Console.WriteLine("Маг добавлен.");
            }
            else
            {
                Console.WriteLine("Неверный тип.");
            }
        }

        /// <summary>
        /// Удаляет персонажа по индексу, выбранному пользователем из списка
        /// </summary>
        static void DeleteCharacter()
        {
            Console.Clear();
            Console.WriteLine("Удаление персонажа");

            var units = logic.GetUnits();
            if (!units.Any())
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            ShowShortList();
            int idx = ReadInt("Введите номер персонажа для удаления (0..N-1)", -1);
            if (idx >= 0 && idx < units.Count)
            {
                logic.Delete_Unit(units[idx]);
                Console.WriteLine("Персонаж удалён.");
            }
            else
            {
                Console.WriteLine("Неверный индекс.");
            }
        }

        /// <summary>
        /// Выводит в консоль подробную информацию обо всех персонажах
        /// </summary>
        static void ShowAll()
        {
            Console.Clear();
            Console.WriteLine("Список персонажей:");

            var units = logic.GetUnits();
            if (!units.Any())
            {
                Console.WriteLine("Пусто.");
                return;
            }

            for (int i = 0; i < units.Count; i++)
            {
                Console.WriteLine($"[{i}] {units[i].GetType().Name} - {units[i].Name}");
                Console.WriteLine(logic.Read_Unit(units[i]));
                Console.WriteLine(new string('-', 40));
            }
        }

        /// <summary>
        /// Редактирование выбранного персонажа, сохранение текущих значений при пустом вводе
        /// </summary>
        static void EditCharacter()
        {
            Console.Clear();
            Console.WriteLine("Изменение персонажа");

            var units = logic.GetUnits();
            if (!units.Any())
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            ShowShortList();
            int idx = ReadInt("Введите номер персонажа для изменения (0..N-1)", -1);
            if (idx < 0 || idx >= units.Count)
            {
                Console.WriteLine("Неверный индекс.");
                return;
            }

            var selected = units[idx];

            if (selected is Fighter f)
            {
                Console.WriteLine("Редактирование воина. Оставьте поле пустым, чтобы сохранить текущее значение.");
                string name = ReadStringWithDefault("Имя", f.Name);
                string desc = ReadStringWithDefault("Описание", f.Description);
                int hp = ReadIntWithDefault("HP", f.HP);
                int str = ReadIntWithDefault("Сила", f.Strength);
                int stam = ReadIntWithDefault("Выносливость", f.Stamina);
                Console.WriteLine("Оружие: " + string.Join(", ", Enum.GetNames(typeof(Weapons))));
                string w = ReadStringWithDefault("Оружие", f.Weapon.ToString());
                if (!Enum.TryParse<Weapons>(w, true, out Weapons weapon)) weapon = f.Weapon;

                logic.Change_Fighter(f, name, desc, hp, str, stam, weapon);
                Console.WriteLine("Данные воина обновлены.");
            }
            else if (selected is Mage m)
            {
                Console.WriteLine("Редактирование мага. Оставьте поле пустым, чтобы сохранить текущее значение.");
                string name = ReadStringWithDefault("Имя", m.Name);
                string desc = ReadStringWithDefault("Описание", m.Description);
                int hp = ReadIntWithDefault("HP", m.HP);
                int str = ReadIntWithDefault("Сила", m.Strength);
                int mana = ReadIntWithDefault("Мана", m.Mana);
                Console.WriteLine("Школы: " + string.Join(", ", Enum.GetNames(typeof(Magic_Schools))));
                string s = ReadStringWithDefault("Школа", m.School.ToString());
                if (!Enum.TryParse<Magic_Schools>(s, true, out Magic_Schools school)) school = m.School;

                logic.Change_Mage(m, name, desc, hp, str, mana, school);
                Console.WriteLine("Данные мага обновлены.");
            }
            else
            {
                Console.WriteLine("Неизвестный тип персонажа.");
            }
        }

        /// <summary>
        /// Меню дополнительных бизнес функций (выстраивание отряда, фильтры по оружию/школе)
        /// </summary>
        static void ExtraFunctions()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Дополнительные функции:");
                Console.WriteLine("1. Выстроить: сначала воины, затем маги");
                Console.WriteLine("2. Показать владельцев выбранного оружия");
                Console.WriteLine("3. Показать магов выбранной школы");
                Console.WriteLine("0. Назад");
                Console.Write("Выбор: ");
                var c = Console.ReadLine();

                if (c == "1")
                {
                    logic.Line_Up();
                    Console.WriteLine("Отряд выстроен. (воины сначала)");
                }
                else if (c == "2")
                {
                    Console.WriteLine("Оружия: " + string.Join(", ", Enum.GetNames(typeof(Weapons))));
                    Console.Write("Выберите оружие: ");
                    var w = Console.ReadLine();
                    if (Enum.TryParse<Weapons>(w, true, out Weapons weapon))
                    {
                        var res = logic.Choose_Marked(weapon);
                        if (!res.Any()) Console.WriteLine("Нет воинов с выбранным оружием.");
                        else
                        {
                            Console.WriteLine("Найденные персонажи:");
                            foreach (var u in res) Console.WriteLine($"{u.GetType().Name}: {u.Name}");
                        }
                    }
                    else Console.WriteLine("Некорректное оружие.");
                }
                else if (c == "3")
                {
                    Console.WriteLine("Школы: " + string.Join(", ", Enum.GetNames(typeof(Magic_Schools))));
                    Console.Write("Выберите школу: ");
                    var s = Console.ReadLine();
                    if (Enum.TryParse<Magic_Schools>(s, true, out Magic_Schools school))
                    {
                        var res = logic.Choose_Marked(school);
                        if (!res.Any()) Console.WriteLine("Нет магов с выбранной школой.");
                        else
                        {
                            Console.WriteLine("Найденные персонажи:");
                            foreach (var u in res) Console.WriteLine($"{u.GetType().Name}: {u.Name}");
                        }
                    }
                    else Console.WriteLine("Некорректная школа.");
                }
                else if (c == "0") return;
                else Console.WriteLine("Неверный ввод.");

                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        #region вспомогательные методы ввода

        /// <summary>
        /// Выводит короткий и удобный список юнитов с индексами (для выбора по индексу в меню)
        /// </summary>
        static void ShowShortList()
        {
            var units = logic.GetUnits();
            for (int i = 0; i < units.Count; i++)
            {
                Console.WriteLine($"[{i}] {units[i].GetType().Name} - {units[i].Name}");
            }
        }

        ///  <summary>
        /// Считывает целое число из консоли
        /// </summary>
        /// <param name="prompt">Текст подсказки для пользователя</param>
        /// <param name="defaultValue">Значение по умолчанию, возвращаемое при некорректном вводе</param>
        /// <returns>Введённое целое число либо значение по умолчанию</returns>
        static int ReadInt(string prompt, int defaultValue)
        {
            Console.Write($"{prompt} (число) [{defaultValue}]: ");
            var s = Console.ReadLine();
            if (int.TryParse(s, out int v)) return v;
            return defaultValue;
        }

        /// <summary>
        /// Считывает целое число с возможностью оставить пустой ввод для сохранения текущего значения (редактирование персонажа)
        /// </summary>
        /// <param name="prompt">Текст подсказки для пользователя</param>
        /// <param name="current">Текущее значение, которое будет возвращено при пустом или некорректном вводе</param>
        /// <returns>Новое значение или сохранённое текущее значение при пустом или некорректном вводе</returns>
        static int ReadIntWithDefault(string prompt, int current)
        {
            Console.Write($"{prompt} [{current}]: ");
            var s = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s)) return current;
            if (int.TryParse(s, out int v)) return v;
            Console.WriteLine("Некорректный ввод — сохраняется текущее значение.");
            return current;
        }

        /// <summary>
        /// Считывает строку с возможностью оставить пустой ввод для сохранения текущего значения
        /// </summary>
        /// <param name="prompt">Текст подсказки для пользователя</param>
        /// <param name="current">Текущее значение, которое будет возвращено при пустом вводе</param>
        /// <returns>Введённая строка или текущее значение при пустом вводе</returns>
        static string ReadStringWithDefault(string prompt, string current)
        {
            Console.Write($"{prompt} [{current}]: ");
            var s = Console.ReadLine();
            return string.IsNullOrWhiteSpace(s) ? current : s;
        }
    }

    #endregion
}
