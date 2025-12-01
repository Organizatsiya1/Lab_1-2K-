using BusinessLogic;
using BusinessLogicModels;
using Models;
using Ninject;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program : IView
    {
        // Реализация событий интерфейса
        public event Action AddDataEvent;
        public event Action DeleteDataEvent;
        public event Action EditDataEvent;
        public event Action LoadDataEvent;
        public event Action<string> FilterFightersEvent;
        public event Action<string> FilterMagesEvent;
        public event Action<int, int> FightEvent;
        public event Action<bool> ChangeRepositoryEvent;

        private List<Character> _currentCharacters = new List<Character>();
        private int _selectedIndex = -1;

        // Ваши вспомогательные методы (добавляем их сюда)
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

        private T ChooseEnumWithDefault<T>(string title, T defaultValue) where T : Enum
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

                string defaultMark = value.Equals(defaultValue) ? " [текущее]" : "";
                Console.WriteLine($"{i + 1}. {display}{defaultMark}");
            }

            Console.Write($"Введите число (1..{values.Length}) или Enter для текущего: ");
            var input = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrEmpty(input))
                return defaultValue;

            if (int.TryParse(input, out int n) && n >= 1 && n <= values.Length)
                return (T)values.GetValue(n - 1);

            Console.WriteLine("Некорректный ввод — сохраняется текущее значение.");
            return defaultValue;
        }

        private void ShowShortList()
        {
            for (int i = 0; i < _currentCharacters.Count; i++)
            {
                var typeName = Displays.CharacterTypes[_currentCharacters[i].GetType()];
                Console.WriteLine($"[{i}] {typeName} - {_currentCharacters[i].Name}");
            }
        }

        private int ReadInt(string prompt, int defaultValue)
        {
            Console.Write($"{prompt} (число) [{defaultValue}]: ");
            var s = Console.ReadLine();
            if (int.TryParse(s, out int v)) return v;
            return defaultValue;
        }

        private int ReadIntWithDefault(string prompt, int current)
        {
            Console.Write($"{prompt} [{current}]: ");
            var s = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(s)) return current;
            if (int.TryParse(s, out int v)) return v;
            Console.WriteLine("Некорректный ввод — сохраняется текущее значение.");
            return current;
        }

        private string ReadStringWithDefault(string prompt, string current)
        {
            Console.Write($"{prompt} [{current}]: ");
            var s = Console.ReadLine();
            return string.IsNullOrWhiteSpace(s) ? current : s;
        }

        // Основные методы интерфейса
        public void Main()
        {
            LoadDataEvent?.Invoke();

            while (true)
            {
                ShowMainMenu();
                var choice = Console.ReadLine();
                HandleMenuChoice(choice);
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("=== ГИЛЬДИЯ ИСКАТЕЛЕЙ ПРИКЛЮЧЕНИЙ ===");
            Console.WriteLine($"Всего персонажей: {_currentCharacters.Count}");
            Console.WriteLine($"Выбран: {(_selectedIndex >= 0 ? _currentCharacters[_selectedIndex].Name : "нет")}");
            Console.WriteLine();
            Console.WriteLine("1. Показать всех персонажей");
            Console.WriteLine("2. Добавить персонажа");
            Console.WriteLine("3. Редактировать выбранного");
            Console.WriteLine("4. Удалить выбранного");
            Console.WriteLine("5. Выбрать персонажа");
            Console.WriteLine("6. Дополнительные функции");
            Console.WriteLine("7. Сменить репозиторий");
            Console.WriteLine("0. Выход");
            Console.Write("\nВыбор: ");
        }

        private void HandleMenuChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    LoadDataEvent?.Invoke();
                    WaitForContinue();
                    break;
                case "2":
                    AddDataEvent?.Invoke();
                    break;
                case "3":
                    if (_selectedIndex >= 0)
                        EditDataEvent?.Invoke();
                    else
                        ShowError("Сначала выберите персонажа!");
                    break;
                case "4":
                    if (_selectedIndex >= 0)
                        DeleteDataEvent?.Invoke();
                    else
                        ShowError("Сначала выберите персонажа!");
                    break;
                case "5":
                    SelectCharacter();
                    break;
                case "6":
                    ShowExtraFunctionsMenu();
                    break;
                case "7":
                    ShowRepositorySelection();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    ShowError("Неверный ввод");
                    WaitForContinue();
                    break;
            }
        }

        public void Redraw(List<Character> units)
        {
            _currentCharacters = units ?? new List<Character>();

            Console.Clear();
            Console.WriteLine("=== СПИСОК ПЕРСОНАЖЕЙ ===");

            if (!_currentCharacters.Any())
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            string rowFormat = "| {0,4} | {1,-10} | {2,-15} | {3,7} | {4,6} | {5,12} | {6,6} | {7,-12} | {8,-12} | {9,-30} |";
            int tableWidth = 150;

            Console.WriteLine(new string('-', tableWidth));
            Console.WriteLine(rowFormat,
                "№", "Тип", "Имя", "Здоровье", "Сила", "Выносливость", "Мана", "Оружие", "Школа магии", "Описание");
            Console.WriteLine(new string('-', tableWidth));

            for (int i = 0; i < _currentCharacters.Count; i++)
            {
                var u = _currentCharacters[i];
                string type = Displays.CharacterTypes[u.GetType()];
                string name = u.Name;
                int hp = u.HP;
                int str = u.Strength;

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

                if (desc.Length > 30) desc = desc.Substring(0, 27) + "...";

                string selected = (i == _selectedIndex) ? "→" : " ";
                Console.WriteLine(rowFormat,
                    $"{selected}{i}", type, name, hp, str, stamina, mana, weapon, school, desc);
            }

            Console.WriteLine(new string('-', tableWidth));
        }

        public Character GetSelectedCharacter()
        {
            if (_selectedIndex >= 0 && _selectedIndex < _currentCharacters.Count)
            {
                return _currentCharacters[_selectedIndex];
            }
            return null;
        }

        public void ShowMessage(string text)
        {
            Console.WriteLine($"\n✓ {text}");
            WaitForContinue();
        }

        public void ShowError(string text)
        {
            Console.WriteLine($"\n✗ ОШИБКА: {text}");
            WaitForContinue();
        }

        private void SelectCharacter()
        {
            Console.Clear();
            Console.WriteLine("=== ВЫБОР ПЕРСОНАЖА ===");

            if (!_currentCharacters.Any())
            {
                ShowError("Нет персонажей для выбора");
                return;
            }

            ShowShortList();

            Console.Write("\nВведите номер: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < _currentCharacters.Count)
            {
                _selectedIndex = index;
                ShowMessage($"Выбран персонаж: {_currentCharacters[index].Name}");
            }
            else
            {
                ShowError("Неверный номер");
            }
        }

        private void ShowExtraFunctionsMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ДОПОЛНИТЕЛЬНЫЕ ФУНКЦИИ ===");
                Console.WriteLine("1. Поединок персонажей");
                Console.WriteLine("2. Показать владельцев выбранного оружия");
                Console.WriteLine("3. Показать магов выбранной школы");
                Console.WriteLine("0. Назад");
                Console.Write("\nВыбор: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowFightSelection();
                        break;
                    case "2":
                        ShowWeaponFilter();
                        break;
                    case "3":
                        ShowSchoolFilter();
                        break;
                    case "0":
                        return;
                    default:
                        ShowError("Неверный ввод");
                        break;
                }
            }
        }

        private void ShowFightSelection()
        {
            if (_currentCharacters.Count < 2)
            {
                ShowMessage("Для поединка нужно минимум 2 персонажа.");
                return;
            }

            bool trigg1 = false;
            bool trigg2 = false;
            int picked = 0;
            int pos2 = 0; // Объявляем здесь!
            Character ch1 = null;
            Character ch2 = null;

            while (trigg1 == false)
            {
                Console.Clear();
                Console.WriteLine("Выберите номер бойца:");
                for (int i = 0; i < _currentCharacters.Count; i++)
                {
                    var u = _currentCharacters[i];
                    string type = Displays.CharacterTypes[u.GetType()];

                    Console.WriteLine($"{i + 1,2}. {type,-6} | {u.Name,-15} | Здоровье:{u.HP,3} | Сила:{u.Strength,2}");
                }

                Console.Write("\nВаш выбор: ");
                int.TryParse(Console.ReadLine(), out int pos1);
                pos1--;
                picked = pos1;

                if (pos1 >= 0 && pos1 < _currentCharacters.Count)
                {
                    trigg1 = true;
                    ch1 = _currentCharacters[pos1];
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
                Console.WriteLine("Выберите номер соперника:");
                for (int i = 0; i < _currentCharacters.Count; i++)
                {
                    var u = _currentCharacters[i];
                    string type = Displays.CharacterTypes[u.GetType()];

                    string mark = (i == picked) ? "  <- (УЖЕ ВЫБРАН)" : "";
                    Console.WriteLine($"{i + 1,2}. {type,-6} | {u.Name,-15} | Здоровье:{u.HP,3} | Сила:{u.Strength,2} | {mark}");
                }

                Console.Write("\nВаш выбор: ");
                int.TryParse(Console.ReadLine(), out pos2); // Используем уже объявленную переменную
                pos2--;

                if (pos2 >= 0 && pos2 < _currentCharacters.Count && pos2 != picked)
                {
                    trigg2 = true;
                    ch2 = _currentCharacters[pos2];

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
            FightEvent?.Invoke(picked, pos2); // Теперь pos2 доступна!
            Console.ReadKey();
        }

        private void ShowWeaponFilter()
        {
            Weapons weapon = ChooseEnum<Weapons>("Выберите оружие");
            FilterFightersEvent?.Invoke(Displays.WeaponsNames[weapon]);
        }

        private void ShowSchoolFilter()
        {
            MagicSchools school = ChooseEnum<MagicSchools>("Выберите школу");
            FilterMagesEvent?.Invoke(Displays.MagicNames[school]);
        }

        private void ShowRepositorySelection()
        {
            Console.Clear();
            Console.WriteLine("Выберите репозиторий для работы приложения:");
            Console.WriteLine("1 - Entity");
            Console.WriteLine("2 - Dapper");
            Console.Write("Ваш выбор: ");

            string input = Console.ReadLine()?.Trim();
            bool useDapper = input == "2";
            ChangeRepositoryEvent?.Invoke(useDapper);

            if (input == "1" || input == "2")
            {
                ShowMessage($"Репозиторий изменен на: {(useDapper ? "Dapper" : "Entity")}");
            }
            else
            {
                ShowError("Некорректный ввод");
            }
        }

        private void WaitForContinue()
        {
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }

    }
}
