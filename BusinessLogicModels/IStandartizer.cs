using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public interface IStandartizer
    {
        string StandartizeName(string name);
        int ClampStat(int value, int min = 0, int max = 100);
        void StandartizeCommon(string name, string desc, int hp, int str,
        out string outName, out string outDisc, out int outHp, out int outStr);
    }
}
