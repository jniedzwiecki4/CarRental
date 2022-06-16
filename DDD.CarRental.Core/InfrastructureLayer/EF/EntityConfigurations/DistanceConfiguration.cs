using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.InfrastructureLayer.EF.EntityConfigurations
{
    class DistanceConfiguration : IEntityTypeConfiguration<Distance>
    {
        public void Configure(EntityTypeBuilder<Distance> distanceConfiguration)
        {
           
            
           
            distanceConfiguration.HasNoKey();

        }


    }
}
