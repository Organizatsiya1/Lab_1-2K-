using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Mage:Character
    {
        public int Mana {  get; set; }
        public Magic_Schools School { get; set; }
        public Mage(string name, string descr, int hp, int str, int mana, Magic_Schools sch) 
        {
            Name = name;
            Description = descr;
            HP = hp;
            Strength = str;
            Mana = mana;
            School = sch;
        }
    }
}
