using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2022_09_23.Entities
{
    public class Subject : AbstractEntity
    {
        public Subject()
        {
            this.Teachers = new HashSet<Teacher>();
            this.Students = new HashSet<Student>();
        }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Code { get; set; }
        [Required]
        public int Credit { get; set; }
        [Required]
        [MaxLength(250)]
        public string Department { get; set; }
        public int SemesterId { get; set; }
        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; } // task 9: Egészítse ki a tantárgyak adatait órarendi információval. Ez legyen szabad szöveges mező.
    }
}
