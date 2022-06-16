using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRentalLib.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.InfrastructureLayer.EF.EntityConfigurations
{
    class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> positionConfiguration)
        {

            positionConfiguration.HasNoKey();

        }


    }
}