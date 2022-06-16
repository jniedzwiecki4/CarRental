using DDD.CarRental.Core.ApplicationLayer.DTOs;
using DDD.CarRental.Core.ApplicationLayer.Mappers;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.InfrastructureLayer.EF;
using DDD.CarRentalLib.ApplicationLayer.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDD.CarRental.Core.ApplicationLayer.Queries.Handlers
{
    public class QueryHandler
    {
        private CarRentalDbContext _context;
        private Mapper _mapper;

        public QueryHandler(CarRentalDbContext context, Mapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<CarDTO> Execute(GetAllCarsQuery query)
        {
            var cars = _context.Cars
                .AsNoTracking()
                .ToList();

            return cars.Select(c => _mapper.Map(c)).ToList();
        }

        public IList<DriverDTO> Execute(GetAllDriversQuery query)
        {
            var drivers = _context.Drivers
                .AsNoTracking()
                .ToList();

            return (IList<DriverDTO>)drivers.Select(d => _mapper.Map(d)).ToList();
        }

        public IList<RentalDTO> Execute(GetAllRentalsQuery query)
        {
            var rentals = _context.Rentals
                .AsNoTracking()
                .ToList();

            return (IList<RentalDTO>)rentals.Select(r => _mapper.Map(r)).ToList();
        }

        public CarDTO Execute(GetCarQuery query)
        {
            Car car = _context.Cars
                .AsNoTracking()
                .Where(c => c.Id == query.CarId)
                .FirstOrDefault();

            return _mapper.Map(car);
        }

        public DriverDTO Execute(GetDriverQuery query)
        {
            Driver driver = _context.Drivers
                .AsNoTracking()
                .Where(d => d.Id == query.DriverId)
                .FirstOrDefault();

            return _mapper.Map(driver);
        }

        public RentalDTO Execute(GetRentalQuery query)
        {
            Rental rental = _context.Rentals
                .AsNoTracking()
                .Where(r => r.Id == query.RentalId)
                .FirstOrDefault();

            return _mapper.Map(rental);
        }

    }
}
