using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _2022_09_23.Entities
{
    public class Position
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class PositionEntityTypeCOnfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {

        }
    }
}
