namespace _2022_09_23.Entities
{
    public class Subject
    {
        public Subject()
        {
            this.Teachers = new HashSet<Teacher>();
            this.Students = new HashSet<Student>();
        }
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Credit { get; set; }
        public string Department { get; set; }
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public bool Deleted { get; set; }
        public string Description { get; set; } // task 9: Egészítse ki a tantárgyak adatait órarendi információval. Ez legyen szabad szöveges mező.
    }
}
