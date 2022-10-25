using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _2022_09_23.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Deleted { get; set; }
    }

    public class SiteEntityTypeCOnfiguration: IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.HasQueryFilter(site => !site.Deleted);
        }
    }
}
