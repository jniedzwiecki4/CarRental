using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Events
{
    public class RentalStartedEvent : DomainEvent
    {
        public Rental Rental { get; protected set; }

        public RentalStartedEvent(Rental rental)
        {
            this.Rental = rental;
        }
    }
}
