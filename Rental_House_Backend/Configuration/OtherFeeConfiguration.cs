using Microsoft.EntityFrameworkCore;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Configuration
{
    public class OtherFeeConfiguration : IEntityTypeConfiguration<OtherFee>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OtherFee> builder)
        {
            builder.ToTable("otherfees");
            builder.HasKey(x => x.AreaID);
            builder.Property(x => x.WaterFee);
            builder.Property(x => x.ElectricFee);
            builder.Property(x => x.WifiFee);
            builder.Property(x => x.GarbageFee);
        }
    }
}
