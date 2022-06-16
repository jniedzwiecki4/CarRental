using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.DomainModelLayer.Implementations;

namespace DDD.CarRental.Core.DomainModelLayer.Events
{
    public class RentalFinishedEvent : DomainEvent
    {

        public Rental Rental { get; protected set; }

        public RentalFinishedEvent(Rental rental)
        {
            this.Rental = rental;
        }

    }
}
