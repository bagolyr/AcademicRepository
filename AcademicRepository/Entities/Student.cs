using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2022_09_23.Entities
{
    public class Student : AbstractEntity
    {
        public Student()
        {
            this.Subjects = new HashSet<Subject>();
        }
        public string NeptunCode { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public int SpecialityId { get; set; }
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
