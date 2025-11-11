using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public interface ICharManipulator
    {
        /// <summary>
        /// Получает всех юнитов отряда
        /// </summary>
        /// <returns>Список юнитов</returns>
        List<Character> GetUnits();

        /// <summary>
        /// Удаляет юнита из отряда
        /// </summary>
        /// <param name="unit">Удаляемый юнит</param>
        void DeleteUnit(Character unit);

        /// <summary>
        /// Прочитать данные юнита
        /// </summary>
        /// <param name="unit">Юнит</param>
        /// <returns name="info">Прочитанная информация</returns>
        string ReadUnit(Character unit);

        /// <summary>
        /// Метод, проводящий поединок между персонажами, если здоровье кого-то опускается до 0 и ниже, он выбывает из списка
        /// </summary>
        /// <param name="char1">Первый персонаж</param>
        /// <param name="char2">Второй персонаж</param>
        string Fight(Character char1, Character char2);
    }
}
