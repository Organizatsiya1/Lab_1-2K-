using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public class Standartizer : IStandartizer
    {
        public string StandartizeName(string name) =>
        string.IsNullOrWhiteSpace(name) ? "Безымянный" : name.Trim();

        public int ClampStat(int value, int min = 0, int max = 100)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

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
