using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public interface IStandartizer
    {
        /// <summary>
        /// Нормализует имя персонажа (заменяет пустое на "Безымянный")
        /// </summary>
        /// <param name="name">Исходное имя</param>
        /// <returns>Нормализованная строка</returns>
        string StandartizeName(string name);

        /// <summary>
        /// Ограничивает числовую характеристику заданным диапазоном
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="min">Минимум = 0</param>
        /// <param name="max">Максимум = 100</param>
        /// <returns>Нормализованное значение</returns>
        int ClampStat(int value, int min = 0, int max = 100);

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
        void StandartizeCommon(string name, string desc, int hp, int str,
        out string outName, out string outDisc, out int outHp, out int outStr);
    }
}
