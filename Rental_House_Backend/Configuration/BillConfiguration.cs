using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Configuration
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("bills");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Room);
            builder.Property(x => x.Time);
            builder.Property(x => x.Price);
            builder.Property(x => x.Electric_Num);
            builder.Property(x => x.Water_Num);
            builder.Property(x => x.Garbage_Fee);
            builder.Property(x => x.Wifi_Fee);
            builder.Property(x => x.Total);
        }
    }
}
