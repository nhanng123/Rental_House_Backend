﻿using Duende.IdentityServer.EntityFramework.Extensions;
using Duende.IdentityServer.EntityFramework.Interfaces;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Rental_House_Backend.Configuration;
using Rental_House_Backend.Models;

namespace Rental_House_Backend.Data
{
    public class RentalHouseDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        private IOptions<OperationalStoreOptions> _operationalStoreOptions;

        public RentalHouseDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
            this._operationalStoreOptions = operationalStoreOptions;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new BillConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new RequesRepairConfiguration());
            modelBuilder.ApplyConfiguration(new ElectricBillConfiguration());
            modelBuilder.ApplyConfiguration(new WaterBillConfiguration());
            modelBuilder.ApplyConfiguration(new OtherFeeConfiguration());
            modelBuilder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Room> Room { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<RequestRepair> RequestRepair { get; set; }
        public DbSet<ElectricBill> ElectricBill { get; set; }
        public DbSet<WaterBill> WaterBill { get; set; }
        public DbSet<OtherFee> OtherFee { get; set; }

    }
}
