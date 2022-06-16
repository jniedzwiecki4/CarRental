using DDD.CarRental.Core.ApplicationLayer.DTOs;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.InfrastructureLayer.EF;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace DDD.CarRental.Core.ApplicationLayer.Mappers
{
    public class Mapper
    {
        CarRentalDbContext _context;

        public Mapper(CarRentalDbContext context)
        {
            _context = context;
        }
        public CarDTO Map(Car car)
        {
            return new CarDTO()
            {
                Id = car.Id,
                RegistrationNumber = car.RegistrationNumber,
                Status = (CarDTO.StatusDTO)car._Status,
                UnitPrice_Currency = car.UnitPrice.Amount.ToString() + " " + car.UnitPrice.Currency
            };
        }

        public DriverDTO Map(Driver driver)
        {
            return new DriverDTO()
            {
                Id = driver.Id,
                LicenceNumber = driver.LicenceNumber,
                Name = driver.FirstName + " " + driver.LastName,
                FreeMinutes = driver.FreeMinutes
            };
        }

        public RentalDTO Map(Rental rental)
        {
            Driver driver = _context.Drivers.Find(rental.DriverId);

            Car car = _context.Cars.Find(rental.CarId);
            Nullable<DateTime> finished;
            if (rental.Finished != null)
            {
                finished = (DateTime)rental.Finished;
            }
            else
            {
                finished = DateTime.Now;
            }
   

            RentalDTO rentalDTO = new RentalDTO()
            {
                Id = rental.Id,
                CarId = rental.CarId,
                DriverId = rental.DriverId,
                Started = rental.Started,
                Finished = (DateTime)finished,
                Total_Currency = rental.Total.Amount + " " + rental.Total.Currency,
                DriverName = Map(driver).Name,
                CarRegistrationNumber = Map(car).RegistrationNumber
            };
            return rentalDTO;
        }

    }
}
