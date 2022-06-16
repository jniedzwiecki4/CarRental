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
            // ustawianie klucza głównego
            rentalConfiguration.HasKey(r => r.Id);

            // klucz tabeli nie będzie generowany przez EF
            rentalConfiguration.Property(r => r.Id).ValueGeneratedNever();

            // wykluczenie DomainsEvents z modelu relacyjnego - nie ma potrzeby zapisywania w bazie zdarzeń domenowych
            rentalConfiguration.Ignore(r => r.DomainEvents);

            // ToDo: konfiguracja pozostalych elementów

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
