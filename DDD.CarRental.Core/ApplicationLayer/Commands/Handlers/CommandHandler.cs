﻿using DDD.CarRental.Core.DomainModelLayer.Factories;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.InfrastructureLayer;
using DDD.CarRental.Core.InfrastructureLayer.EF;
using DDD.CarRentalLib.DomainModelLayer.Models;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using static DDD.CarRental.Core.DomainModelLayer.Models.Car;

namespace DDD.CarRental.Core.ApplicationLayer.Commands.Handlers
{
    public class CommandHandler
    {
        private CarRentalDbContext _dbContext;
        private ICarRentalUnitOfWork _unitOfWork;
        private CarFactory _carFactory;
        private RentalFactory _rentalFactory;
        private DiscountPolicyFactory _discountPolicyFactory;
        private PositionService _positionService;
       

        public CommandHandler(CarRentalDbContext context,ICarRentalUnitOfWork unitOfWork, CarFactory carFactory, RentalFactory rentalFactory, DiscountPolicyFactory discountPolicyFactory, PositionService positionService)
        {
            _dbContext = context;
            _unitOfWork = unitOfWork;
            _rentalFactory = rentalFactory;
            _carFactory = carFactory;
            _discountPolicyFactory = discountPolicyFactory;
            _positionService = positionService;
            
        }

        public void Execute(CreateCarCommand command)
        {
            Car car = _unitOfWork.CarRepository.Get(command.CarId);
            if(car != null)
            {
                throw new Exception($"Car '{command.CarId}' already exists.");
            }

            car = _unitOfWork.CarRepository.GetCarByRegistrationNumber(command.RegistrationNumber);
            if(car != null)
                throw new Exception($"Car '{command.RegistrationNumber}' already exists.");

            car = _carFactory.Create(command.CarId, command.RegistrationNumber, (Status)command._Status, new Distance(command.CurrentDistance), new Money(command.UnitPrice));
            _unitOfWork.CarRepository.Insert(car);
            _unitOfWork.Commit();
        }

        public void Execute(CreateDriverCommand command)
        {
            Driver driver = _unitOfWork.DriverRepository.Get(command.DriverId);
            if (driver != null)
                throw new Exception($"Driver '{command.DriverId}' already exists.");


            driver = _unitOfWork.DriverRepository.GetDriverByLicenceNumber(command.LicenceNumber);
            if (driver != null)
                throw new Exception($"Driver '{command.LicenceNumber}' already exists.");

            driver = new Driver(command.DriverId, command.LicenceNumber, command.FirstName, command.LastName);
            _unitOfWork.DriverRepository.Insert(driver);
            _unitOfWork.Commit();
        }

        public void Execute(RentCarCommand command)
        {
            Rental rental = _unitOfWork.RentalRepository.Get(command.RentalId);
            if(rental != null)
                throw new Exception($"Rental '{command.RentalId}' already exists.");

            Car car = _unitOfWork.CarRepository.Get(command.CarId);
            if(car == null)
                throw new Exception($"Car '{command.CarId}' does not exist.");

            Driver driver = _unitOfWork.DriverRepository.Get(command.DriverId);
            if(driver == null)
                throw new Exception($"Driver '{command.DriverId}' does not exist.");

            rental = _rentalFactory.Create(command.RentalId, command.Started, car, driver);
            rental.RegisterPolicy(_discountPolicyFactory.Create(rental));
            car.Rent();

            _unitOfWork.RentalRepository.Insert(rental);
            _unitOfWork.Commit();
        }

        public void Execute(ReturnCarCommand command)
        {
            Rental rental = _unitOfWork.RentalRepository.Get(command.RentalId);
            if(rental == null)
                throw new Exception($"Rental '{command.RentalId}' does not exist.");


            Car car = _unitOfWork.CarRepository.Get(rental.CarId);
            if(car == null)
                throw new Exception($"Car '{rental.CarId}' does not exist.");

            Driver driver = _unitOfWork.DriverRepository.Get(rental.DriverId);
            if (driver == null)
                throw new Exception($"Driver '{rental.DriverId}' does not exist.");

            rental.StopRental(command.Finished, car.UnitPrice);
            car.Return();
            Position position = _positionService.GetPosition();
            car.Return();

            driver.AddFreeMinutes(rental.GiveFreeMinutes());

            
            _unitOfWork.Commit();
        }



    }
}
