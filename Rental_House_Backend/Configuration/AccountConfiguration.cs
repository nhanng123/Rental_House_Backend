using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts");
            builder.HasKey(x => x.Username);
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.RoomId).IsRequired();
            builder.Property(x => x.Role).IsRequired();
            
        }
    }
}
