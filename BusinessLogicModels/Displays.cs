using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicModels
{
    public static class Displays
    {
        public static readonly Dictionary<Type, string> CharacterTypes = new Dictionary<Type, string>
        {
            { typeof(Fighter), "Воин" },
            { typeof(Mage), "Маг" }
        };

        public static readonly Dictionary<Weapons, string> WeaponsNames = new Dictionary<Weapons, string>
        {
            { Weapons.None, "Без оружия" },
            { Weapons.Mace, "Булава" },
            { Weapons.Sword, "Меч" },
            { Weapons.Axe, "Топор" }
        };

        public static readonly Dictionary<MagicSchools, string> MagicNames = new Dictionary<MagicSchools, string>
        {
            { MagicSchools.Fire, "Огонь" },
            { MagicSchools.Ice, "Лёд" },
            { MagicSchools.Light, "Свет" }
        };
    }
}
