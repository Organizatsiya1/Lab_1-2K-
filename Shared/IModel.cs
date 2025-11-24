using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IModel
    {
        // Character Service Methods
        List<Character> GetUnits();
        void DeleteUnit(Character unit);
        string ReadUnit(Character unit);
        string Fight(Character char1, Character char2);

        // Fighter Service Methods
        void AddFighter(string name, string disc, int hp, int str, int stam, Weapons weapon);
        void ChangeFighter(Fighter unit, string name, string disc, int hp, int str, int stam, Weapons weapon);
        List<Character> ChooseMarked(Weapons weapon);

        // Mage Service Methods
        void AddMage(string name, string disc, int hp, int str, int mana, MagicSchools school);
        void ChangeMage(Mage unit, string name, string disc, int hp, int str, int mana, MagicSchools school);
        List<Character> ChooseMarked(MagicSchools magic);

        // Normalizer Methods
        string NormalizeName(string name);
        int ClampStat(int value, int min = 0, int max = 100);

        // Composite Methods
        List<Character> GetSpecializedUnits(Weapons weapon, MagicSchools school);
        void DeleteUnits(List<Character> units);
        string GetSquadStats();

        // Событие из лекции
        event Action DataChanged;
    }
}
