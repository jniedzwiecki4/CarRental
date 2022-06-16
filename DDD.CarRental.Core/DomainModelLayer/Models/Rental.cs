using DDD.CarRental.Core.DomainModelLayer.Events;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Rental: Entity, IAggregateRoot
    {

        public DateTime Started { get; protected set; }
        
        public DateTime? Finished { get; protected set; }

        public Money Total { get; protected set; }

        public long DriverId { get; protected set; }
        public long CarId { get; protected set; }
        private IDiscountPolicy _policy;

        protected Rental()
        {
        }

        public Rental(long rentalId, DateTime started, long CarId, long DriverId) 
            : base(rentalId)
        {
            this.CarId = CarId;
            this.DriverId = DriverId;
            this.Started = started;
            this.Total = Money.Zero;

            AddDomainEvent(new RentalStartedEvent(this));
        }

        public void StopRental(DateTime finished, Money price)
        {
            if (finished < Started) throw new Exception($"Finished time can not be earlier than started");

            this.Finished = finished;

            this.Total = price.MultiplyBy(GetTimeInMinutes());

            this.AddDomainEvent(new RentalFinishedEvent(this));

        }


        public int GetTimeInMinutes()
        {
            if (!this.Finished.HasValue) throw new Exception("Not finished rental");

            return (this.Finished.Value - this.Started).Minutes + (this.Finished.Value - this.Started).Hours*(int)60;
        }

        public void RegisterPolicy(IDiscountPolicy policy)
        {
            this._policy = policy;
        }

        public int GiveFreeMinutes()
        {
            return _policy.CalculateDiscount(GetTimeInMinutes());
        }
    }

}
