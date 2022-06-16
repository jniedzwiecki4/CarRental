
using DDD.CarRentalLib.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.DomainModelLayer;
using DDD.CarRental.Core.DomainModelLayer.Models;

namespace DDD.CarRentalLib.DomainModelLayer.Services
{
   public  class PositionService //: IDomainService
    {
        private ICarRentalUnitOfWork _unitOfWork;
        private IDomainEventPublisher _domainEventPublisher;

        public PositionService(ICarRentalUnitOfWork unitOfWork,
           IDomainEventPublisher domainEventPublisher)
        {
            this._unitOfWork = unitOfWork;
            this._domainEventPublisher = domainEventPublisher;
        }

        public void SetPosition(Car car, int xPosition, int yPosition, string unit)
        {
            Position position = new Position(xPosition, yPosition, unit);

            Random rnd = new Random();
            position.XPosition = rnd.Next(0, 101);
            position.YPosition = rnd.Next(0, 101);

            car.CurrentPosition = position;

            this._unitOfWork.Commit();

        }
    }
}
