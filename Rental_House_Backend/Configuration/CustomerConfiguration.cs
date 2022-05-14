
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.DoB).IsRequired();
            builder.Property(x => x.Id_Number);
            builder.Property(x => x.Nationality).IsRequired();
            builder.Property(x => x.Initial_Address).IsRequired();
            builder.Property(x => x.Job).IsRequired();
            builder.Property(x => x.Company);
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Room).IsRequired();
        }
    }
}
