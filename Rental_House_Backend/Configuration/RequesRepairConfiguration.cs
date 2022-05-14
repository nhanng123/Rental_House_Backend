using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Configuration
{
    public class RequesRepairConfiguration : IEntityTypeConfiguration<RequestRepair>
    {
        public void Configure(EntityTypeBuilder<RequestRepair> builder)
        {
            builder.ToTable("repairs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Room);
            builder.Property(x => x.Description);
            builder.Property(x => x.Date);
        }
    }
}
