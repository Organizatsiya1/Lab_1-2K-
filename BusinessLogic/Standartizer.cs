using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public class Standartizer : IStandartizer
    {
        /// <summary>
        /// Нормализует имя персонажа, заполняет параметр имя "Безымянный", если он пустой
        /// </summary>
        /// <param name="name">Имя персонажа</param>
        /// <returns>Имя персонажа или "Безымянный", если пусто</returns>
        public string StandartizeName(string name) =>
        string.IsNullOrWhiteSpace(name) ? "Безымянный" : name.Trim();

        /// <summary>
        /// Ограничивает числовую характеристику заданным диапазоном
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="min">Минимум = 0</param>
        /// <param name="max">Максимум = 100</param>
        /// <returns>Нормализованное значение</returns>
        public int ClampStat(int value, int min = 0, int max = 100)
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
        public void StandartizeCommon(string name, string desc, int hp, int str,
            out string outName, out string outDisc, out int outHp, out int outStr)
        {
            const int hpMax = 100;
            const int strMax = 10;

            outName = StandartizeName(name);
            outDisc = desc ?? "";
            outHp = ClampStat(hp, 0, hpMax);
            outStr = ClampStat(str, 0, strMax);
        }
    }
}
