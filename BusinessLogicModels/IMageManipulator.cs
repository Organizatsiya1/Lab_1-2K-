using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public interface IMageManipulator
    {
        void AddMage(string name, string disc, int hp, int str, int mana, MagicSchools school);
        void ChangeMage(Mage unit, string name, string disc, int hp, int str, int mana, MagicSchools school);
        List<Character> ChooseMarked(MagicSchools magic);
    }
}
