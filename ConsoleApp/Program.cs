using System;
using Business_Logic;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

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
                        Console.WriteLine("Создание персонажа (пока заглушка)");
                        // тут будет вызов logic.CreateCharacter(...)
                        break;

                    case "2":
                        Console.WriteLine("Удаление персонажа (пока заглушка)");
                        break;

                    case "3":
                        Console.WriteLine("Список персонажей (пока заглушка)");
                        break;

                    case "4":
                        Console.WriteLine("Изменение персонажа (пока заглушка)");
                        break;

                    case "5":
                        Console.WriteLine("Бизнес-функция (пока заглушка)");
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
    }
}
