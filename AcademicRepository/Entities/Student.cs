using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using _2022_09_23.Attributes;

namespace _2022_09_23.Entities
{
    public class Student : AbstractEntity
    {
        public Student()
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
        public int SpecialityId { get; set; }
        [ForeignKey("SpecialityId")]
        public Speciality Speciality { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }

    public class StudentEntityTypeCOnfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //builder.HasQueryFilter(student => !student.Deleted);
        }
    }
}
