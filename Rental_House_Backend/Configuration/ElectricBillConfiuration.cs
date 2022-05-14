using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Configuration
{
    public class ElectricBillConfiguration : IEntityTypeConfiguration<ElectricBill>
    {
        public void Configure(EntityTypeBuilder<ElectricBill> builder)
        {
            builder.ToTable("electricbills");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RoomId);
            builder.Property(x => x.Electric_Number);
            builder.Property(x => x.Electric_Date);

        }
    }
}
