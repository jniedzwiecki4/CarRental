using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.InfrastructureLayer.EF.EntityConfigurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> driverConfiguration)
        {
            driverConfiguration.HasKey(d => d.Id);

            driverConfiguration.Property(d => d.Id).ValueGeneratedNever();

            driverConfiguration.Ignore(d => d.DomainEvents);


            driverConfiguration.HasIndex(d => d.LicenceNumber).IsUnique();

            

        }
    }

    
}
