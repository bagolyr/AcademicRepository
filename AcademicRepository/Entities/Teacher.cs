namespace _2022_09_23.Entities
{
    public class Teacher : AbstractEntity
    {
        public Teacher()
        {
            this.Subjects = new HashSet<Subject>();
        }
        public string NeptunCode { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
