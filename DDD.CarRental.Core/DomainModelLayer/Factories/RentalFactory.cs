using System;
using System.Collections.Generic;
using System.Text;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.DomainModelLayer;

namespace DDD.CarRental.Core.DomainModelLayer.Factories
{
    public class RentalFactory
    {

        private IDomainEventPublisher _domainEventPublisher;

        public RentalFactory(IDomainEventPublisher domainEventPublisher)
        {
            this._domainEventPublisher = domainEventPublisher;
        }

        public Rental Create(long rentalId, DateTime started, Car car, Driver driver)
        {
            CheckIfCarIsActive(car);
            

            return new Rental(rentalId, started, car.Id, driver.Id);
        }



        private void CheckIfCarIsActive(Car car)
        {
            if (car._Status != Car.Status.FREE)
                throw new Exception($"Car {car.Id} is not free.");
        }

        private void CheckIfCarIsReserved(Car car)
        {
            if (car._Status != Car.Status.RESERVED)
                throw new Exception($"Car {car.Id} is not reserved.");
        }

    }
}
