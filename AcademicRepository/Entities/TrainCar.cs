using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _2022_09_23.Entities
{
    public class TrainCar
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public int YearOfManufacture { get; set; }
        public string TrackNumber { get; set; }
        public string Owner { get; set; }
        public int SiteId { get; set; } 
        public Site Site { get; set; }
        public bool Deleted { get; set; }   

    }

    public class TrainCarEntityTypeCOnfiguration : IEntityTypeConfiguration<TrainCar>
    {
        public void Configure(EntityTypeBuilder<TrainCar> builder)
        {
            //builder.HasKey(traincar => new { traincar.Id, traincar.SerialNumber });
            //builder.HasOne(traincar => traincar.Site)
            //    .WithOne(site => site.)
            //    .HasForeignKey(traincar => traincar)
            builder.HasQueryFilter(traincar => !traincar.Deleted);
        }
    }
}
