using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace _2022_09_23.Entities
{
    // Task 26. Használja a modell validációs attribútumokat a modelljeinek property-jein. A property-ket
    // próbálja értelemszerűen ellátni ezekkel az attribútumokkal.
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }

    public class PositionEntityTypeCOnfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {

        }
    }
}
