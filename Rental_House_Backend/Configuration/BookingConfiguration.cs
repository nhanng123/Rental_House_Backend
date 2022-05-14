using Microsoft.EntityFrameworkCore;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("bookings");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Phone);
            builder.Property(x => x.Room);
            builder.Property(x => x.Note);
            builder.Property(x => x.Status).HasDefaultValue(false);
            builder.Property(x => x.CreatedDate);
        }
    }
}
