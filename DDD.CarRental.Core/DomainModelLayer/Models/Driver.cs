using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Driver : Entity, IAggregateRoot
    {

        public string LicenceNumber { get; protected set; }
        
        public string FirstName{ get; protected set; }
        
        public string LastName { get; protected set; }

        public int FreeMinutes { get; protected set; }

        protected Driver()
        {

        }

        public Driver(long driverId, string licenceNumber, string firstName, string lastName) 
            : base(driverId)
        {
            if (string.IsNullOrEmpty(licenceNumber)) throw new ArgumentNullException("Numer rejestracji jest pusty");

            this.LicenceNumber = licenceNumber;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FreeMinutes = 0;
        }

        public void AddFreeMinutes(int minutes)
        {
            FreeMinutes += minutes;
        }
    }

}
