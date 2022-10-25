namespace _2022_09_23.Entities
{
    public class Teacher
    {
        public Teacher()
        {
            this.Subjects = new HashSet<Subject>();
        }
        public int Id { get; set; }
        public string NeptunCode { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public bool Deleted { get; set; }
    }
}
