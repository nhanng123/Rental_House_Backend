using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Configuration
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("rooms");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.State).HasDefaultValue("Available");
            builder.Property(x => x.Number_Of_People).HasDefaultValue(0);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Description);
        }
    }
}
