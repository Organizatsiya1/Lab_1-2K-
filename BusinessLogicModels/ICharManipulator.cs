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
        List<Character> GetUnits();
        void DeleteUnit(Character unit);
        string ReadUnit(Character unit);
        string Fight(Character char1, Character char2);
    }
}
