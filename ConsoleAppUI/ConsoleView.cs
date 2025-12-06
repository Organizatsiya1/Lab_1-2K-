using Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppUI
{
    public class ConsoleView : IConsoleView
    {
        public event Action AddDataEvent;
        public event Action DeleteDataEvent;
        public event Action EditDataEvent;
        public event Action LoadDataEvent;

        public event Action FightEvent;
        public event Action<string> FilterFightersEvent;
        public event Action<string> FilterMagesEvent;
        
        public event Action<bool> ChangeRepositoryEvent;

        private List<Character> currentCharacters;

        /// <summary>
        /// Показ меню консольного приложения
        /// </summary>
        public void ShowMenu()
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
                Console.WriteLine("5. Показать владельцев выбранного оружия");
                Console.WriteLine("6. Показать магов выбранной школы");
                Console.WriteLine("7. Устроить поединок");
                Console.WriteLine("8. Сменить репозиторий");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыбор: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDataEvent?.Invoke();
                        break;
                    case "2":
                        DeleteDataEvent?.Invoke();
                        break;
                    case "3":
                        LoadDataEvent?.Invoke();
                        break;
                    case "4":
                        EditDataEvent?.Invoke();
                        break;
                    case "5":
                        string weapon = GetWeaponFromUser();
                        if (weapon != null)
                            FilterFightersEvent?.Invoke(weapon);
                        break;
                    case "6":
                        string school = GetSchoolFromUser();
                        if (school != null)
                            FilterMagesEvent?.Invoke(school);
                        break;
                    case "7":
                        FightEvent?.Invoke();
                        break;
                    case "8":
                        ShowRepoMenu();
                        break;
                    case "0":
                        return;
                    default:
                        ShowError("Команда не найдена");
                        break;
                }
                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Выводит список всех персонажей с их характеристиками
        /// </summary>
        /// <param name="characters">Список персонажей</param>
        public void Redraw(List<Character> characters)
        {
            currentCharacters = characters;
            Console.Clear();

            if (characters == null || characters.Count == 0)
            {
                Console.WriteLine("Список персонажей пуст");
                return;
            }

            Console.WriteLine("Список персонажей:");

            for (int i = 0; i < characters.Count; i++)
            {
                var character = characters[i];
                var typeName = Displays.CharacterTypes[character.GetType()];

                Console.WriteLine($"\n[{i}] {typeName}: {character.Name}");
                Console.WriteLine($"\tHP: {character.HP}, Сила: {character.Strength}");

                if (character is Fighter fighter)
                {
                    Console.WriteLine($"\tОружие: {Displays.WeaponsNames[fighter.Weapon]}, Выносливость: {fighter.Stamina}");
                }
                else if (character is Mage mage)
                {
                    Console.WriteLine($"\tШкола: {Displays.MagicNames[mage.School]}, Мана: {mage.Mana}");
                }

                Console.WriteLine($"\tОписание: {character.Description}");
            }

            Console.WriteLine($"Всего персонажей: {characters.Count}");
        }


        public Character GetSelectedCharacter()
        {
            if (currentCharacters == null || currentCharacters.Count == 0)
            {
                ShowError("Нет доступных персонажей.");
                return null;
            }

            ShowShortList();
            Console.Write("\nВведите номер персонажа: ");

            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < currentCharacters.Count)
            {
                return currentCharacters[index];
            }

            ShowError("Неверный номер персонажа.");
            return null;
        }

        /// <summary>
        /// Показ сообщения пользователю
        /// </summary>
        /// <param name="text">Сообщение</param>
        public void ShowMessage(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Показ сообщения-ошибки пользователю
        /// </summary>
        /// <param name="text">Сообщение ошибки</param>
        public void ShowError(string text)
        {
            Console.WriteLine(text);
        }

        /// <summary>
        /// Меню выбора оружия от пользователя
        /// </summary>
        private string GetWeaponFromUser()
        {
            Console.Clear();
            Console.WriteLine("Выберите оружие для фильтрации:");

            var weapons = Displays.WeaponsNames;
            int i = 1;
            foreach (var weapon in weapons)
            {
                Console.WriteLine($"{i}. {weapon.Value}");
                i++;
            }

            Console.WriteLine("0. Отмена");
            Console.Write("\nВыберите оружие: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0) return null;

                if (choice > 0 && choice <= weapons.Count)
                {
                    return weapons.ElementAt(choice - 1).Value;
                }
                else
                {
                    ShowError("Неверный выбор.");
                }
            }
            else
            {
                ShowError("Неверный ввод.");
            }

            return null;
        }

        /// <summary>
        /// Меню выбора школы магии от пользователя
        /// </summary>
        private string GetSchoolFromUser()
        {
            Console.Clear();
            Console.WriteLine("Выберите школу магии для фильтрации:");

            var schools = Displays.MagicNames;
            int i = 1;
            foreach (var school in schools)
            {
                Console.WriteLine($"{i}. {school.Value}");
                i++;
            }

            Console.WriteLine("0. Отмена");
            Console.Write("\nВыберите школу: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0) return null;

                if (choice > 0 && choice <= schools.Count)
                {
                    return schools.ElementAt(choice - 1).Value;
                }
                else
                {
                    ShowError("Неверный выбор.");
                }
            }
            else
            {
                ShowError("Неверный ввод.");
            }

            return null;
        }

        /// <summary>
        /// Выводит короткий список текущих персонажей
        /// </summary>
        private void ShowShortList()
        {
            if (currentCharacters == null || currentCharacters.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            for (int i = 0; i < currentCharacters.Count; i++)
            {
                var typeName = Displays.CharacterTypes[currentCharacters[i].GetType()];
                Console.WriteLine($"[{i}] {typeName} - {currentCharacters[i].Name}");
            }
        }

        /// <summary>
        /// Получает тип репозитория от пользователя
        /// </summary>
        private void ShowRepoMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите репозиторий для работы приложения:");
            Console.WriteLine("1 - Entity Framework");
            Console.WriteLine("2 - Dapper");
            Console.Write("Ваш выбор: ");

            string input = Console.ReadLine()?.Trim();
            switch (input)
            {
                case "1":
                    ChangeRepositoryEvent?.Invoke(false);
                    break;
                case "2":
                    ChangeRepositoryEvent?.Invoke(true);
                    break;
                default:
                    ShowError("Некорректный ввод. Репозиторий не изменен.");
                    break;
            }
        }

    }
        
}
