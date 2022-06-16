using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.InfrastructureLayer
{
    public class PositionService
    {

        public Position GetPosition()
        {

            Random random = new Random();

            Position position = new Position((decimal)random.NextDouble(), (decimal)random.NextDouble());

            return position;

        }

    }
}
