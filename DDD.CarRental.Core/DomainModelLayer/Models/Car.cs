using DDD.CarRentalLib.DomainModelLayer.Models;
using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Car : Entity, IAggregateRoot
    {
        public enum Status
        {
            FREE = 0,
            RESERVED = 1,
            RENT = 2
        }

        public string RegistrationNumber { get; protected set; }

        
        public Distance CurrentDistance { get; protected set; }

        
        public Distance TotalDistance { get; protected set; }

        public Status _Status { get; protected set; }

     
        public Money UnitPrice { get; protected set; }
        public Position CurrentPosition { get; internal set; }

        protected Car()
        {
        }

        public Car(long carId, string registrationNumber, Status status, Distance totalDistnace, Money price) 
            : base(carId)
        {

            this.RegistrationNumber = registrationNumber;
            this._Status = status;
            this.CurrentDistance = new Distance(0);
            this.TotalDistance = totalDistnace;
            this.UnitPrice = price;
        }

        public void Rent()
        {
            _Status = Status.RENT;
        }

        public void Return()
        {
            _Status = Status.FREE;
        }

        public void Reserve()
        {
            _Status = Status.RESERVED;
        }
    }

}
