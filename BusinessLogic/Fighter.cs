using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Fighter:Character
    {
        public int Stamina {  get; set; }
        public Weapons Weapon { get; set; }
        public Fighter(string name, string descr, int hp, int str, int stam, Weapons weap) 
        {
            Name = name;
            Description = descr;
            HP = hp;
            Strength = str;
            Stamina = stam;
            Weapon = weap;
        }
    }
}
