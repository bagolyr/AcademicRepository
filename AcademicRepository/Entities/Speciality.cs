using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _2022_09_23.Entities
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }    
    }

    public class SpecialityEntityTypeCOnfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            
        }
    }
}
