using Shared;
using Models;
using BusinessLogic;
using Ninject;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Presenter
{
    public class MainPresenter
    {
        private readonly IView view;
        private IModel model;
        private readonly IAddHeroView addHeroView;
        private StandardKernel kernel;
        private readonly bool isConsoleMode;

        /// <summary>
        /// Инициализирует новый экземпляр MainPresenter и настраивает взаимодействие между компонентами
        /// </summary>
        /// <param name="view">Интерфейс представления для отображения данных и получения ввода от пользователя</param>
        /// <param name="model">Интерфейс модели, содержащей бизнес-логику и данные приложения</param>
        /// <param name="addHeroView">Интерфейс формы добавления/редактирования персонажа</param>
        /// <param name="kernel">Контейнер зависимостей Ninject для управления репозиториями</param>
        public MainPresenter(IView view, IModel model, IAddHeroView addHeroView = null, StandardKernel kernel = null)
        {
            this.view = view;
            this.model = model;
            this.addHeroView = addHeroView;
            this.kernel = kernel;

            isConsoleMode = view is IConsoleView;

            BindViewEvents();
            model.DataChanged += RedrawAll;
            RedrawAll();

            if (isConsoleMode)
            {
                var consoleView = view as IConsoleView;
                consoleView?.ShowMenu();
            }
        }

        /// <summary>
        /// Подписки на события
        /// </summary>
        private void BindViewEvents()
        {
            view.AddDataEvent += OnAdd;
            view.DeleteDataEvent += OnDelete;
            view.EditDataEvent += OnEdit;
            view.LoadDataEvent += RedrawAll;
            view.FilterFightersEvent += OnFilterFighters;
            view.FilterMagesEvent += OnFilterMages;
            view.FightEvent += OnFight;
            view.ChangeRepositoryEvent += OnChangeRepository;
        }

        /// <summary>
        /// Обновление отображения
        /// </summary>
        private void RedrawAll()
        {
            view.Redraw(model.GetUnits());
        }

        /// <summary>
        /// Метод добавления персонажа
        /// </summary>
        private void OnAdd()
        {
            if (!isConsoleMode && addHeroView != null)
            {
                addHeroView.SetCreateMode();
                if (addHeroView.ShowDialog() == DialogResult.OK)
                {
                    Character c = addHeroView.CreatedHero;
                    AddCharacterToModel(c);
                }
            }
            else
            {
                CreateCharacter();
            }
        }

        /// <summary>
        /// Создание персонажа через консоль
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

                view.ShowError("Неверный ввод. Введите 1 - Воин, 2 - Маг, 0 - Отмена");
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
                view.ShowMessage("Воин добавлен.");
            }
            else if (t == "2")
            {
                int mana = ReadInt("Мана", 50);
                MagicSchools school = ChooseEnum<MagicSchools>("Школа магии");

                model.AddMage(name, desc, hp, str, mana, school);
                view.ShowMessage("Маг добавлен.");
            }
        }

        /// <summary>
        /// Добавление персонажа в модель
        /// </summary>
        /// <param name="c">Персонаж для добавления</param>
        private void AddCharacterToModel(Character c)
        {
            if (c is Fighter f)
            {
                model.AddFighter(f.Name, f.Description, f.HP, f.Strength, f.Stamina, f.Weapon);
            }
            else if (c is Mage m)
            {
                model.AddMage(m.Name, m.Description, m.HP, m.Strength, m.Mana, m.School);
            }
        }

        /// <summary>
        /// Метод удаления персонажа
        /// </summary>
        private void OnDelete()
        {
            if (isConsoleMode)
            {
                DeleteCharacter();
            }
            else
            {
                Character selected = view.GetSelectedCharacter();
                if (selected == null) return;

                model.DeleteUnit(selected);
            }
        }

        /// <summary>
        /// Удаление персонажа через консоль
        /// </summary>
        private void DeleteCharacter()
        {
            Console.Clear();
            Console.WriteLine("Удаление персонажа");

            var units = model.GetUnits();
            if (!units.Any())
            {
                view.ShowMessage("Список пуст.");
                return;
            }

            ShowShortList(units);
            int idx = ReadInt("Введите номер персонажа для удаления:", -1);
            if (idx >= 0 && idx < units.Count)
            {
                model.DeleteUnit(units[idx]);
                view.ShowMessage("Персонаж удалён.");
            }
            else
            {
                view.ShowError("Неверный индекс.");
            }
        }

        /// <summary>
        /// Метод редактирования персонажа
        /// </summary>
        private void OnEdit()
        {
            if (!isConsoleMode && addHeroView != null)
            {
                Character selected = view.GetSelectedCharacter();
                if (selected == null) return;

                addHeroView.LoadCharacter(selected);

                if (addHeroView.ShowDialog() == DialogResult.OK)
                {
                    Character updated = addHeroView.CreatedHero;
                    UpdateCharacterInModel(selected, updated);
                }
            }
            else
            {
                EditCharacter();
            }
        }

        /// <summary>
        /// Редактирование персонажа через консоль
        /// </summary>
        private void EditCharacter()
        {
            Console.Clear();
            Console.WriteLine("Изменение персонажа");

            var units = model.GetUnits();
            if (!units.Any())
            {
                view.ShowMessage("Список пуст.");
                return;
            }

            ShowShortList(units);
            int idx = ReadInt("Введите номер персонажа для изменения", -1);
            if (idx < 0 || idx >= units.Count)
            {
                view.ShowError("Неверный индекс.");
                return;
            }

            var selected = units[idx];

            if (selected is Fighter f)
            {
                view.ShowMessage("Редактирование воина. Оставьте поле пустым, чтобы сохранить текущее значение.");
                string name = ReadStringWithDefault("Имя", f.Name);
                string disc = ReadStringWithDefault("Описание", f.Description);
                int hp = ReadIntWithDefault("Здоровье", f.HP);
                int str = ReadIntWithDefault("Сила", f.Strength);
                int stam = ReadIntWithDefault("Выносливость", f.Stamina);

                var weaponKeys = Displays.WeaponsNames.Keys.ToArray();
                view.ShowMessage("Оружие:");
                for (int i = 0; i < weaponKeys.Length; i++)
                {
                    var wk = weaponKeys[i];
                    view.ShowMessage($"{i + 1}. {Displays.WeaponsNames[wk]}");
                }
                view.ShowMessage($"Введите номер (1..{weaponKeys.Length}) или нажмите Enter, чтобы оставить текущее [{Displays.WeaponsNames[f.Weapon]}]: ");
                var wInput = (Console.ReadLine() ?? "").Trim();
                Weapons weapon = f.Weapon;
                if (!string.IsNullOrWhiteSpace(wInput) && int.TryParse(wInput, out int wnum) && wnum >= 1 && wnum <= weaponKeys.Length)
                {
                    weapon = weaponKeys[wnum - 1];
                }

                model.ChangeFighter(f, name, disc, hp, str, stam, weapon);
                view.ShowMessage("Данные воина обновлены.");
            }
            else if (selected is Mage m)
            {
                view.ShowMessage("Редактирование мага. Оставьте поле пустым, чтобы сохранить текущее значение.");
                string name = ReadStringWithDefault("Имя", m.Name);
                string desc = ReadStringWithDefault("Описание", m.Description);
                int hp = ReadIntWithDefault("Здоровье", m.HP);
                int str = ReadIntWithDefault("Сила", m.Strength);
                int mana = ReadIntWithDefault("Мана", m.Mana);

                var schoolKeys = Displays.MagicNames.Keys.ToArray();
                view.ShowMessage("Школы магии:");
                for (int i = 0; i < schoolKeys.Length; i++)
                {
                    var sk = schoolKeys[i];
                    view.ShowMessage($"{i + 1}. {Displays.MagicNames[sk]}");
                }
                view.ShowMessage($"Введите номер (1..{schoolKeys.Length}) или нажмите Enter, чтобы оставить текущее [{Displays.MagicNames[m.School]}]: ");
                var sInput = (Console.ReadLine() ?? "").Trim();
                MagicSchools school = m.School;
                if (!string.IsNullOrWhiteSpace(sInput) && int.TryParse(sInput, out int snum) && snum >= 1 && snum <= schoolKeys.Length)
                {
                    school = schoolKeys[snum - 1];
                }

                model.ChangeMage(m, name, desc, hp, str, mana, school);
                view.ShowMessage("Данные мага обновлены.");
            }
            else
            {
                view.ShowError("Неизвестный тип персонажа.");
            }
        }

        /// <summary>
        /// Обновление персонажа в модели
        /// </summary>
        /// <param name="oldChar">Данные о персонаже до обновления</param>
        /// <param name="newChar">Данные о персонаже после обновления</param>
        private void UpdateCharacterInModel(Character oldChar, Character newChar)
        {
            if (oldChar is Fighter oldF && newChar is Fighter f)
            {
                model.ChangeFighter(oldF, f.Name, f.Description, f.HP, f.Strength, f.Stamina, f.Weapon);
            }
            else if (oldChar is Mage oldM && newChar is Mage m)
            {
                model.ChangeMage(oldM, m.Name, m.Description, m.HP, m.Strength, m.Mana, m.School);
            }
        }

        /// <summary>
        /// Метод фильтрации воинов по оружию
        /// </summary>
        /// <param name="weaponName">Выбранное оружие для фильтра</param>
        private void OnFilterFighters(string weaponName)
        {
            try
            {
                Weapons weapon = Displays.WeaponsNames
                    .First(x => x.Value == weaponName).Key;

                var list = model.ChooseMarked(weapon);

                if (isConsoleMode)
                {
                    view.Redraw(list);
                    view.ShowMessage($"Найдено {list.Count} воинов с оружием: {weaponName}");
                }
                else
                {
                    view.Redraw(list);
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка фильтрации: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод фильтрации магов по школе магии
        /// </summary>
        /// <param name="schoolName">Выбранная школа магии для фильтра</param>
        private void OnFilterMages(string schoolName)
        {
            try
            {
                MagicSchools school = Displays.MagicNames
                    .First(x => x.Value == schoolName).Key;

                var list = model.ChooseMarked(school);

                if (isConsoleMode)
                {
                    view.Redraw(list);
                    view.ShowMessage($"Найдено {list.Count} магов школы: {schoolName}");
                }
                else
                {
                    view.Redraw(list);
                }
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка фильтрации: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод дуэли между персонажами
        /// </summary>
        private void OnFight()
        {
            try
            {
                if (isConsoleMode)
                {
                    FightConsole();
                }
                else
                {
                    if (!(view is IMainFormView winFormsView)) return;

                    var selectedCharacters = winFormsView.GetSelectedCharacters();

                    if (selectedCharacters == null || selectedCharacters.Count != 2)
                    {
                        return;
                    }

                    Character character1 = selectedCharacters[0];
                    Character character2 = selectedCharacters[1];

                    string result = model.Fight(character1, character2);

                    view.ShowMessage(result);
                    RedrawAll();
                }
                
            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка в битве: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод дуэли консольного представления
        /// </summary>
        private void FightConsole()
        {
            var units = model.GetUnits();

            if (units.Count < 2)
            {
                view.ShowError("Недостаточно персонажей для поединка (нужно минимум 2)");
                return;
            }

            bool firstChosen = false;
            bool secondChosen = false;
            int pickedIndex = 0;
            Character character1 = null;
            Character character2 = null;

            while (!firstChosen)
            {
                Console.Clear();
                Console.WriteLine("Выберите номер бойца:");

                for (int i = 0; i < units.Count; i++)
                {
                    var character = units[i];
                    string type = Displays.CharacterTypes[character.GetType()];
                    Console.WriteLine($"{i + 1,2}. {type,-6} | {character.Name,-15} | Здоровье:{character.HP,3} | Сила:{character.Strength,2}");
                }

                Console.Write("\nВаш выбор (0 - отмена): ");
                int.TryParse(Console.ReadLine(), out int position);
                position--; // Переводим в 0-индекс
                pickedIndex = position;

                if (position == -1) // Пользователь ввел 0
                {
                    view.ShowMessage("Выбор отменен.");
                    return;
                }

                if (position >= 0 && position < units.Count)
                {
                    firstChosen = true;
                    character1 = units[position];
                    Console.WriteLine($"\nВыбран: {Displays.CharacterTypes[character1.GetType()]} - {character1.Name}");
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

            while (!secondChosen)
            {
                Console.Clear();
                Console.WriteLine("Выберите номер соперника:");

                for (int i = 0; i < units.Count; i++)
                {
                    var character = units[i];
                    string type = Displays.CharacterTypes[character.GetType()];
                    string mark = (i == pickedIndex) ? "  <- (УЖЕ ВЫБРАН)" : "";
                    Console.WriteLine($"{i + 1,2}. {type,-6} | {character.Name,-15} | Здоровье:{character.HP,3} | Сила:{character.Strength,2} {mark}");
                }

                Console.Write("\nВаш выбор (0 - отмена): ");
                int.TryParse(Console.ReadLine(), out int position);
                position--;

                if (position == -1)
                {
                    view.ShowMessage("Выбор отменен.");
                    return;
                }

                if (position >= 0 && position < units.Count && position != pickedIndex)
                {
                    secondChosen = true;
                    character2 = units[position];
                    Console.WriteLine($"\nВыбран соперник: {Displays.CharacterTypes[character2.GetType()]} - {character2.Name}");
                    Console.WriteLine("\nНажмите любую клавишу, чтобы начать поединок...");
                    Console.ReadKey();
                }
                else if (position == pickedIndex)
                {
                    Console.WriteLine("\nНельзя выбрать того же персонажа!");
                }
                else
                {
                    Console.WriteLine("\nВыбран несуществующий персонаж.");
                }

                if (!secondChosen)
                {
                    Console.WriteLine("\nНажмите любую клавишу, чтобы попробовать снова...");
                    Console.ReadKey();
                }
            }

            Console.Clear();
            string result = model.Fight(character1, character2);

            view.ShowMessage(result);

            Console.WriteLine("\nНажмите любую клавишу для отображения обновленного списка...");
            Console.ReadKey();

            view.Redraw(model.GetUnits());

            Console.ReadKey();
        }

        /// <summary>
        /// Метод смены репозитория
        /// </summary>
        private void OnChangeRepository(bool useDapper)
        {
            try
            {
                kernel = new StandardKernel(new SimpleConfigModule(useDapper));
                var newModel = kernel.Get<IModel>();

                if (model != null)
                {
                    model.DataChanged -= RedrawAll;
                }
                newModel.DataChanged += RedrawAll;
                model = newModel;

                RedrawAll();

                if (isConsoleMode)
                {
                    Console.Clear();
                    Console.WriteLine($"Текущий выбор: {(useDapper ? "Dapper" : "Entity Framework")}");

                    Console.WriteLine("Репозиторий успешно изменен!");
                    Console.WriteLine("\nНажмите любую клавишу для отображения списка...");
                    Console.ReadKey();
                }
                else
                {
                    view.ShowMessage($"Репозиторий изменен на: {(useDapper ? "Dapper" : "Entity Framework")}");
                }

            }
            catch (Exception ex)
            {
                view.ShowError($"Ошибка смены репозитория: {ex.Message}");
            }
        }

        #region Вспомогательные методы для консоли

        /// <summary>
        /// Показывает список значений enum и позволяет выбрать по номеру
        /// </summary>
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
        /// Выводит короткий список юнитов с индексами
        /// </summary>
        private void ShowShortList(System.Collections.Generic.List<Character> units)
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
        private int ReadInt(string prompt, int defaultValue)
        {
            Console.Write($"{prompt} (число) [{defaultValue}]: ");
            var s = Console.ReadLine();
            if (int.TryParse(s, out int v)) return v;
            return defaultValue;
        }

        /// <summary>
        /// Считывает целое число с возможностью оставить текущее значение
        /// </summary>
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
        /// Считывает строку с возможностью оставить текущее значение
        /// </summary>
        private string ReadStringWithDefault(string prompt, string current)
        {
            Console.Write($"{prompt} [{current}]: ");
            var s = Console.ReadLine();
            return string.IsNullOrWhiteSpace(s) ? current : s;
        }

        #endregion
    }
}