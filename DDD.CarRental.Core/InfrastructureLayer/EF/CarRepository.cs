using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.InfrastructureLayer.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DDD.CarRental.Core.InfrastructureLayer.EF
{
    public class CarRepository : Repository<Car>, ICarRepository
    { 
        public CarRepository(CarRentalDbContext context)
            :base(context)
        { }

        public Car GetCarByRegistrationNumber(string RegistrationNumber)
        {
            return _context.Cars
                .Where(c => c.RegistrationNumber == RegistrationNumber)
                .FirstOrDefault();
        }

        public IList<Car> GetAllCars()
        {
            return _context.Cars
                .ToList();
        }

    }
}
