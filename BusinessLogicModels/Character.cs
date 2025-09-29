namespace BusinessLogicModels
{
    public class Character : IDomainObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HP {  get; set; }
        public int Strength { get; set; }
    }
}
