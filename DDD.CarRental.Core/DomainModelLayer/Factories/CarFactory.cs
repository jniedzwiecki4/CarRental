using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using static DDD.CarRental.Core.DomainModelLayer.Models.Car;

namespace DDD.CarRental.Core.DomainModelLayer.Factories
{
    public class CarFactory
    {
        private IDomainEventPublisher _domainEventPublisher;

        public CarFactory(IDomainEventPublisher domainEventPublisher)
        {
            _domainEventPublisher = domainEventPublisher;
        }

        public Car Create(long carId, string registrationNumber, Status status, Distance totalDistance, Money price)
        {
            CheckRegistrationNumber(registrationNumber);
            CheckTotalDistance(totalDistance);

            return new Car(carId, registrationNumber, status, totalDistance, price);
        }

        private void CheckRegistrationNumber(string registrationNumber)
        {
            if (string.IsNullOrEmpty(registrationNumber)) throw new ArgumentNullException("Numer rejestracji jest pusty");
        }

        private void CheckTotalDistance(Distance totalDistance)
        {
            if (Distance.Zero > totalDistance) throw new ArgumentNullException("Odległosc nie moze byc mniejsza niz zero");
        }


    }
}
