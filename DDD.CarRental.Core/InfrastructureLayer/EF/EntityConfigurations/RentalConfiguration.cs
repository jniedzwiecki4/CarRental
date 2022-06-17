using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.InfrastructureLayer.EF.EntityConfigurations
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> rentalConfiguration)
        {
            rentalConfiguration.HasKey(r => r.Id);

            rentalConfiguration.Property(r => r.Id).ValueGeneratedNever();

            rentalConfiguration.Ignore(r => r.DomainEvents);


            rentalConfiguration.Property<long>("DriverId").IsRequired();

            rentalConfiguration.HasOne<Driver>()
                .WithMany()
                .IsRequired(false)
                .HasForeignKey("DriverId");

            rentalConfiguration.Property<long>("CarId").IsRequired();

            rentalConfiguration.HasOne<Car>()
                .WithMany()
                .IsRequired(false)
                .HasForeignKey("CarId");

            rentalConfiguration.OwnsOne(r => r.Total);


        }
    }


}
