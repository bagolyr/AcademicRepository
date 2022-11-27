using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _2022_09_23.Attributes;

namespace _2022_09_23.Entities
{
    public class Teacher : AbstractEntity
    {
        public Teacher()
        {
            this.Subjects = new HashSet<Subject>();
        }
        [Required]
        //[MaxLength(6)]
        [NeptunCodeValidationAttribute]
        public string NeptunCode { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string EmailAddress { get; set; }
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public Position Position { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
