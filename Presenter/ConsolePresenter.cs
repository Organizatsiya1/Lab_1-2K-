using BusinessLogic;
using Models;
using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Presenter
{
    public class ConsolePresenter
    {
        private readonly IConsoleView consoleView;
        private StandardKernel kernel;
        private IModel model;

        public ConsolePresenter(IConsoleView consoleView, IModel model, StandardKernel kernel)
        {
            this.consoleView = consoleView;
            this.model = model;
            this.kernel = kernel;


            BindEvents();
        }

        private void BindEvents()
        {
            consoleView.AddDataEvent += CreateCharacter;
            consoleView.DeleteDataEvent += DeleteCharacter;
            consoleView.LoadDataEvent += ShowAll;
            consoleView.EditDataEvent += EditCharacter;
            consoleView.ExtraFunctionsEvent += ExtraFunctions;
            consoleView.ChangeRepositoryEvent += ChangeRepository;

            model.DataChanged += () => consoleView.ShowMessage("Данные изменены.");
        }

        public void Start()
        {
            while (true)
                consoleView.ShowMenu();
        }

        private void ChangeRepository()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите репозиторий:");
                Console.WriteLine("1 - Entity");
                Console.WriteLine("2 - Dapper");
                Console.Write("Ваш выбор: ");

                string input = Console.ReadLine()?.Trim();

                switch (input)
                {
                    case "1":
                        kernel = new StandardKernel(new SimpleConfigModule(false));
                        model = kernel.Get<IModel>();
                        model.DataChanged += () => consoleView.ShowMessage("Данные изменены.");
                        consoleView.ShowMessage("Переключено на Entity.");
                        return;

                    case "2":
                        kernel = new StandardKernel(new SimpleConfigModule(true));
                        model = kernel.Get<IModel>();
                        model.DataChanged += () => consoleView.ShowMessage("Данные изменены.");
                        consoleView.ShowMessage("Переключено на Dapper.");
                        return;

                    default:
                        consoleView.ShowError("Некорректный ввод. Попробуйте снова...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        /// <summary>
        /// Создает персонажа через консольный ввод и добавляет его в логику
        /// </summary>
        private void CreateCharacter()
        {
            Console.Clear();
            Console.WriteLine("Создание персонажа");
            Console.WriteLine("Оставьте поле пустым если хотите установить значение по умолчанию");

            string t;
            while (true)
            {
                Console.Write("Тип (1 - Воин, 2 - Маг, 0 - Отмена): ");
                t = (Console.ReadLine() ?? "").Trim();

                if (t == "0")
                {
                    Console.WriteLine("Создание отменено.");
                    return;
                }

                if (t == "1" || t == "2")
                    break;

                consoleView.ShowError("Неверный ввод. Введите 1 - Воин, 2 - Маг, 0 - Отмена");
            }

            Console.Write("Имя: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Описание: ");
            string desc = Console.ReadLine() ?? "";

            int hp = ReadInt("Здоровье", 100);
            int str = ReadInt("Сила", 10);

            if (t == "1")
            {
                int stam = ReadInt("Выносливость", 20);
                Weapons weapon = ChooseEnum<Weapons>("Тип оружия");

                model.AddFighter(name, desc, hp, str, stam, weapon);
                consoleView.ShowMessage("Воин добавлен.");
            }
            else if (t == "2")
            {
                int mana = ReadInt("Мана", 50);
                MagicSchools school = ChooseEnum<MagicSchools>("Школа магии");

                model.AddMage(name, desc, hp, str, mana, school);
                consoleView.ShowMessage("Маг добавлен.");
            }
        }

        /// <summary>
        /// Удаляет персонажа по индексу, выбранному пользователем из списка
        /// </summary>
        private void DeleteCharacter()
        {
            Console.Clear();
            Console.WriteLine("Удаление персонажа");

            var units = model.GetUnits();
            if (!units.Any())
            {
                consoleView.ShowMessage("Список пуст.");
                return;
            }

            ShowShortList(units);
            int idx = ReadInt("Введите номер персонажа для удаления:", -1);
            if (idx >= 0 && idx < units.Count)
            {
                model.DeleteUnit(units[idx]);
                consoleView.ShowMessage("Персонаж удалён.");
            }
            else
            {
                consoleView.ShowError("Неверный индекс.");
            }
        }

        /// <summary>
        /// Выводит в консоль подробную информацию обо всех персонажах
        /// </summary>
        private void ShowAll()
        {
            Console.Clear();
            Console.WriteLine("Список персонажей:");

            var units = model.GetUnits();
            if (!units.Any())
            {
                consoleView.ShowMessage("Пусто.");
                return;
            }

            // Заголовки таблицы
            // Формат строки с вертикальными разделителями
            string rowFormat = "| {0,4} | {1,-10} | {2,-15} | {3,7} | {4,6} | {5,12} | {6,6} | {7,-12} | {8,-12} | {9,-30} |";
            int tableWidth = 150; //общая ширина столбца

            // Верхняя граница
            Console.WriteLine(new string('-', tableWidth));

            // Заголовок таблицы (ширины подобраны для аккуратного вывода)
            Console.WriteLine(rowFormat,
                "№", "Тип", "Имя", "Здоровье", "Сила", "Выносливость", "Мана", "Оружие", "Школа магии", "Описание");

            // Разделитель под заголовком
            Console.WriteLine(new string('-', tableWidth));

            for (int i = 0; i < units.Count; i++)
            {
                var u = units[i];
                string type = Displays.CharacterTypes[u.GetType()];
                string name = u.Name;
                int hp = u.HP;
                int str = u.Strength;

                // Defaults
                int stamina = 0;
                int mana = 0;
                string weapon = Weapons.None.ToString();
                string school = "-";
                string desc = u.Description ?? "";

                if (u is Fighter f)
                {
                    stamina = f.Stamina;
                    weapon = Displays.WeaponsNames[f.Weapon];
                }
                else if (u is Mage m)
                {
                    mana = m.Mana;
                    school = Displays.MagicNames[m.School];
                }

                // Обрезаем описание, чтобы не ломать таблицу
                if (desc.Length > 30) desc = desc.Substring(0, 27) + "...";

                Console.WriteLine(rowFormat,
                    i, type, name, hp, str, stamina, mana, weapon, school, desc);
            }

            // Нижняя граница
            Console.WriteLine(new string('-', tableWidth));
        }

        /// <summary>
        /// Редактирование выбранного персонажа, сохранение текущих значений при пустом вводе
        /// </summary>
        private void EditCharacter()
        {
            Console.Clear();
            Console.WriteLine("Изменение персонажа");

            var units = model.GetUnits();
            if (!units.Any())
            {
                consoleView.ShowMessage("Список пуст.");
                return;
            }

            ShowShortList(units);
            int idx = ReadInt("Введите номер персонажа для изменения", -1);
            if (idx < 0 || idx >= units.Count)
            {
                consoleView.ShowError("Неверный индекс.");
                return;
            }

            var selected = units[idx];

            if (selected is Fighter f)
            {
                consoleView.ShowMessage("Редактирование воина. Оставьте поле пустым, чтобы сохранить текущее значение.");
                string name = ReadStringWithDefault("Имя", f.Name);
                string disc = ReadStringWithDefault("Описание", f.Description);
                int hp = ReadIntWithDefault("Здоровье", f.HP);
                int str = ReadIntWithDefault("Сила", f.Strength);
                int stam = ReadIntWithDefault("Выносливость", f.Stamina);

                var weaponKeys = Displays.WeaponsNames.Keys.ToArray();
                consoleView.ShowMessage("Оружие:");
                for (int i = 0; i < weaponKeys.Length; i++)
                {
                    var wk = weaponKeys[i];
                    consoleView.ShowMessage($"{i + 1}. {Displays.WeaponsNames[wk]}");
                }
                consoleView.ShowMessage($"Введите номер (1..{weaponKeys.Length}) или нажмите Enter, чтобы оставить текущее [{Displays.WeaponsNames[f.Weapon]}]: ");
                var wInput = (Console.ReadLine() ?? "").Trim();
                Weapons weapon = f.Weapon;
                if (!string.IsNullOrWhiteSpace(wInput) && int.TryParse(wInput, out int wnum) && wnum >= 1 && wnum <= weaponKeys.Length)
                {
                    weapon = weaponKeys[wnum - 1];
                }

                model.ChangeFighter(f, name, disc, hp, str, stam, weapon);
                consoleView.ShowMessage("Данные воина обновлены.");
            }
            else if (selected is Mage m)
            {
                consoleView.ShowMessage("Редактирование мага. Оставьте поле пустым, чтобы сохранить текущее значение.");
                string name = ReadStringWithDefault("Имя", m.Name);
                string desc = ReadStringWithDefault("Описание", m.Description);
                int hp = ReadIntWithDefault("Здоровье", m.HP);
                int str = ReadIntWithDefault("Сила", m.Strength);
                int mana = ReadIntWithDefault("Мана", m.Mana);

                var schoolKeys = Displays.MagicNames.Keys.ToArray();
                consoleView.ShowMessage("Школы магии:");
                for (int i = 0; i < schoolKeys.Length; i++)
                {
                    var sk = schoolKeys[i];
                    consoleView.ShowMessage($"{i + 1}. {Displays.MagicNames[sk]}");
                }
                consoleView.ShowMessage($"Введите номер (1..{schoolKeys.Length}) или нажмите Enter, чтобы оставить текущее [{Displays.MagicNames[m.School]}]: ");
                var sInput = (Console.ReadLine() ?? "").Trim();
                MagicSchools school = m.School;
                if (!string.IsNullOrWhiteSpace(sInput) && int.TryParse(sInput, out int snum) && snum >= 1 && snum <= schoolKeys.Length)
                {
                    school = schoolKeys[snum - 1];
                }

                model.ChangeMage(m, name, desc, hp, str, mana, school);
                consoleView.ShowMessage("Данные мага обновлены.");
            }
            else
            {
                consoleView.ShowError("Неизвестный тип персонажа.");
            }
        }

        /// <summary>
        /// Меню дополнительных бизнес функций (выстраивание отряда, фильтры по оружию/школе)
        /// </summary>
        private void ExtraFunctions()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Дополнительные функции:");
                Console.WriteLine("1. Устроить поединок");
                Console.WriteLine("2. Показать владельцев выбранного оружия");
                Console.WriteLine("3. Показать магов выбранной школы");
                Console.WriteLine("0. Назад");
                Console.Write("Выбор: ");

                var c = Console.ReadLine();

                switch (c)
                {
                    case "1":
                        StartFight();
                        break;

                    case "2":
                        ShowFightersByWeapon();
                        break;

                    case "3":
                        ShowMagesBySchool();
                        break;

                    case "0":
                        return;

                    default:
                        consoleView.ShowError("Неверный ввод.");
                        break;
                }
                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        private void StartFight()
        {
            bool trigg1 = false;
            bool trigg2 = false;
            int picked = 0;
            Character ch1 = null;
            Character ch2 = null;

            while (trigg1 == false)
            {
                Console.Clear();
                var units = model.GetUnits();
                if (!units.Any())
                {
                    Console.WriteLine("Нет доступных персонажей для поединка.");
                    Console.WriteLine("\nНажмите любую клавишу...");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Выберите номер бойца:");
                for (int i = 0; i < units.Count; i++)
                {
                    var u = units[i];
                    string type = Displays.CharacterTypes[u.GetType()];

                    Console.WriteLine($"{i + 1,2}. {type,-6} | {u.Name,-15} | Здоровье:{u.HP,3} | Сила:{u.Strength,2}");
                }

                Console.Write("\nВаш выбор: ");
                int.TryParse(Console.ReadLine(), out int pos1);
                pos1--;
                picked = pos1;

                if (pos1 >= 0 && pos1 < model.GetUnits().Count)
                {
                    trigg1 = true;
                    ch1 = model.GetUnits()[pos1];
                    Console.WriteLine($"\nВыбран: {Displays.CharacterTypes[ch1.GetType()]} - {ch1.Name}");
                    Console.WriteLine("\nНажмите любую клавишу, чтобы перейти к выбору соперника...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nВыбран несуществующий персонаж.");
                    Console.WriteLine("\nНажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                }
            }
            while (trigg2 == false)
            {
                Console.Clear();
                var units = model.GetUnits();
                Console.WriteLine("Выберите номер соперника:");
                for (int i = 0; i < units.Count; i++)
                {
                    var u = units[i];
                    string type = Displays.CharacterTypes[u.GetType()];

                    string mark = (i == picked) ? "  <- (УЖЕ ВЫБРАН)" : "";
                    Console.WriteLine($"{i + 1,2}. {type,-6} | {u.Name,-15} | Здоровье:{u.HP,3} | Сила:{u.Strength,2} | {mark}");
                }

                Console.Write("\nВаш выбор: ");
                int.TryParse(Console.ReadLine(), out int pos2);
                pos2--;

                if (pos2 >= 0 && pos2 < model.GetUnits().Count && pos2 != picked)
                {
                    trigg2 = true;
                    ch2 = model.GetUnits()[pos2];

                    Console.WriteLine($"\nВыбран соперник: {Displays.CharacterTypes[ch2.GetType()]} - {ch2.Name}");
                    Console.WriteLine("\nНажмите любую клавишу, чтобы начать поединок...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("\nВыбран несуществующий персонаж, или поединок хотят провести самим с собой");
                    Console.WriteLine("\nНажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            Console.WriteLine(model.Fight(ch1, ch2));
            Console.ReadKey();
        }

        private void ShowFightersByWeapon()
        {
            Weapons weapon = ChooseEnum<Weapons>("Выберите оружие");
            var res = model.ChooseMarked(weapon);

            if (!res.Any())
            {
                consoleView.ShowMessage("Нет воинов с выбранным оружием.");
                return;
            }

            consoleView.ShowMessage("Найденные персонажи:");
            foreach (var u in res)
                consoleView.ShowMessage($"{Displays.CharacterTypes[u.GetType()]}: {u.Name}");
        }

        private void ShowMagesBySchool()
        {
            MagicSchools school = ChooseEnum<MagicSchools>("Выберите школу");
            var res = model.ChooseMarked(school);
            if (!res.Any()) Console.WriteLine("Нет магов с выбранной школой.");
            else
            {
                Console.WriteLine("Найденные персонажи:");
                foreach (var u in res) Console.WriteLine($"{Displays.CharacterTypes[u.GetType()]}: {u.Name}");
            }
        }


        #region вспомогательные методы ввода

        /// <summary>
        /// Показывает список значений enum и позволяет выбрать по номеру
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <param name="title">Заголовок выбора</param>
        /// <returns>Выбранное значение перечисления</returns>
        private T ChooseEnum<T>(string title) where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            Console.WriteLine($"{title}:");

            for (int i = 0; i < values.Length; i++)
            {
                var value = (T)values.GetValue(i);
                string display;

                if (typeof(T) == typeof(Weapons))
                    display = Displays.WeaponsNames[(Weapons)(object)value];
                else if (typeof(T) == typeof(MagicSchools))
                    display = Displays.MagicNames[(MagicSchools)(object)value];
                else
                    display = value.ToString();

                Console.WriteLine($"{i + 1}. {display}");
            }


            while (true)
            {
                Console.Write($"Введите число (1..{values.Length}): ");
                var input = (Console.ReadLine() ?? "").Trim();
                if (int.TryParse(input, out int n) && n >= 1 && n <= values.Length)
                    return (T)values.GetValue(n - 1);

                Console.WriteLine("Ошибка: введите номер из списка.");
            }
        }

        /// <summary>
        /// Выводит короткий и удобный список юнитов с индексами (для выбора по индексу в меню)
        /// </summary>
        private void ShowShortList(List<Character> units)
        {
            for (int i = 0; i < units.Count; i++)
            {
                var typeName = Displays.CharacterTypes[units[i].GetType()];
                Console.WriteLine($"[{i}] {typeName} - {units[i].Name}");
            }
        }

        /// <summary>
        /// Считывает целое число из консоли
        /// </summary>
        /// <param name="prompt">Текст подсказки для пользователя</param>
        /// <param name="defaultValue">Значение по умолчанию, возвращаемое при некорректном вводе</param>
        /// <returns>Введённое целое число либо значение по умолчанию</returns>
        private int ReadInt(string prompt, int defaultValue)
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
        private int ReadIntWithDefault(string prompt, int current)
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
        private string ReadStringWithDefault(string prompt, string current)
        {
            Console.Write($"{prompt} [{current}]: ");
            var s = Console.ReadLine();
            return string.IsNullOrWhiteSpace(s) ? current : s;
        }
    }

    #endregion

}
