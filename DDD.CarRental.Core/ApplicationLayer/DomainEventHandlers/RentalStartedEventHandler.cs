using DDD.CarRental.Core.DomainModelLayer.Events;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.ApplicationLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.ApplicationLayer.DomainEventHandlers
{
    class RentalStartedEventHandler :IEventHandler<RentalStartedEvent>
    {
        private ICarRepository _carRepository;
        public RentalStartedEventHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void Handle(RentalStartedEvent eventData)
        {
            var car = _carRepository.Get(eventData.Rental.CarId);

            car.Rent();
        }
    }
}
