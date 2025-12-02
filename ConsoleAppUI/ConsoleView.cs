using Models;
using Shared;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    internal class ConsoleView : IConsoleView
    {
        public event Action AddDataEvent;
        public event Action DeleteDataEvent;
        public event Action EditDataEvent;
        public event Action LoadDataEvent;
        public event Action ExtraFunctionsEvent;
        public event Action ChangeRepositoryEvent;

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
                Console.WriteLine("5. Дополнительные функции");
                Console.WriteLine("6. Сменить репозиторий");
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
                        ExtraFunctionsEvent?.Invoke();
                        break;
                    case "6":
                        ChangeRepositoryEvent?.Invoke();
                        break;
                    case "0":
                        return;
                    default:
                        ShowError("Команда не найден.");
                        break;
                }
                Console.WriteLine("\nНажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        public void ShowMessage(string text)
        {
            Console.WriteLine(text);
        }

        public void ShowError(string text)
        {
            Console.WriteLine(text);
        }

        public void ShowUnits(string title, List<Character> units)
        {
            Console.WriteLine(title);
            foreach (var u in units)
                Console.WriteLine($"{Displays.CharacterTypes[u.GetType()]} - {u.Name}");
        }

    }
        
}
