using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.InfrastructureLayer.EF.EntityConfigurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> carConfiguration)
        {
            carConfiguration.HasKey(c => c.Id);

            carConfiguration.Property(c => c.Id).ValueGeneratedNever();

            carConfiguration.Ignore(c => c.DomainEvents);
            carConfiguration.Ignore(c => c.TotalDistance);
            carConfiguration.Ignore(c => c.CurrentDistance);
            carConfiguration.Ignore(c => c.CurrentPosition);


            carConfiguration.HasIndex(c => c.RegistrationNumber).IsUnique();

            carConfiguration.OwnsOne(r => r.UnitPrice);


        }
    }


}
