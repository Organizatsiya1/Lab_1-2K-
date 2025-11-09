using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public interface IFighterManipulator
    {
        void AddFighter(string name, string disc, int hp, int str, int stam, Weapons weapon);
        void ChangeFighter(Fighter unit, string name, string disc, int hp, int str, int stam, Weapons weapon);
        List<Character> ChooseMarked(Weapons weapon);
    }
}
