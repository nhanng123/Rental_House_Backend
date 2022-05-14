using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Rental_House_Backend.Data
{
    //public class RentalHouseDbContextFactory : IDesignTimeDbContextFactory<RentalHouseDbContext>
    //{
    //    public RentalHouseDbContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configurationRoot = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json")
    //            .Build();

    //        var connectionString = configurationRoot.GetConnectionString("RentalHousesDatabase");

    //        var optionBuilder = new DbContextOptionsBuilder<RentalHouseDbContext>();
    //        optionBuilder.UseSqlServer(connectionString);

    //        return new RentalHouseDbContext(optionBuilder.Options);
    //    }
    //}

}
