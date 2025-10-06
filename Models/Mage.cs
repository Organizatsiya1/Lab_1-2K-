namespace Models
{
    public class Mage:Character
    {
        public int Mana {  get; set; }
        public MagicSchools School { get; set; }
        public Mage(string name, string descr, int hp, int str, int mana, MagicSchools sch) 
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
