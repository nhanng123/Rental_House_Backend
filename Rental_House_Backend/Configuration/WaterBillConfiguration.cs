using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Configuration
{
    public class WaterBillConfiguration : IEntityTypeConfiguration<WaterBill>
    {
        public void Configure(EntityTypeBuilder<WaterBill> builder)
        {
            builder.ToTable("waterbills");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BillId);
            builder.Property(x => x.RoomId);
            builder.Property(x => x.Water_Number);
            builder.Property(x => x.Water_Date);

        }
    }
}

