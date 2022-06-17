using DDD.SharedKernel.DomainModelLayer.Implementations;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using DDD.CarRental.Core.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Models
{
    public class Position : ValueObject
    {
        private decimal v1;
        private decimal v2;

        public int XPosition { get; set; }

        public int YPosition { get; set; }

        public string Unit { get; protected set; }

        public Position(int xPosition, int yPosition, string unit)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Unit = unit;
        }

        public Position(decimal v1, decimal v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return XPosition;
            yield return YPosition;
            yield return Unit;
        }

        public Distance CaltulateDistance(Position p1, Position p2)
        {
            if (p1.Unit != p2.Unit)
            {
                throw new ArgumentException("Jednostki nie sa takie same");
            }
            return new Distance((decimal)Math.Sqrt(Math.Pow(p1.XPosition - p2.XPosition, 2) + Math.Pow((p1.YPosition - p2.YPosition), 2)), p1.Unit);
        }
    }
}
