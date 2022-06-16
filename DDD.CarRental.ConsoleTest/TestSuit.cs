using DDD.CarRental.Core.ApplicationLayer.Commands;
using DDD.CarRental.Core.ApplicationLayer.Commands.Handlers;
using DDD.CarRental.Core.ApplicationLayer.Queries;
using DDD.CarRental.Core.ApplicationLayer.Queries.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.ConsoleTest
{
    public class TestSuit
    {
        private IServiceProvider _serviceProvide;

        private CommandHandler _commandHandler;
        private QueryHandler _queryHandler;

        public TestSuit(IServiceCollection serviceCollection)
        {
            _serviceProvide = serviceCollection.BuildServiceProvider();

            _commandHandler = _serviceProvide.GetRequiredService<CommandHandler>();
            _queryHandler = _serviceProvide.GetRequiredService<QueryHandler>();
        }

        public void Run()
        {
            long carId = 1;
            long driver1Id = 1;
            long driver2Id = 2;
            long rental1Id = 1;
            long rental2Id = 2;

            _commandHandler.Execute(new CreateCarCommand()
            {
                CarId = carId,
                RegistrationNumber = "KR ABC",
                _Status = CreateCarStatus.FREE,
                XCurrentPosition = 1m,
                YCurrentPosition = 1m,
                TotalDistance = 200m,
                UnitPrice = 10m

            });
            Console.WriteLine("Samochód utworzony");
            var cars = _queryHandler.Execute(new GetAllCarsQuery());
            foreach (var car in cars)
            {
                Console.WriteLine($"Id samochodu: {car.Id}, Rejestracja: {car.RegistrationNumber}, Status: {car.Status} \r\n");
            }
            _commandHandler.Execute(new CreateDriverCommand()
            {
                DriverId = driver1Id,
                LicenceNumber = "12345",
                FirstName = "Jan",
                LastName = "Kowalski"

            });

            _commandHandler.Execute(new CreateDriverCommand()
            {
                DriverId = driver2Id,
                LicenceNumber = "54321",
                FirstName = "Piotr",
                LastName = "Nowak"
            });
            Console.WriteLine("Dwóch kierowców utworzonych");
            var drivers = _queryHandler.Execute(new GetAllDriversQuery());
            foreach (var driver in drivers)
            {
                Console.WriteLine($"Id kierowcy: {driver.Id}, Imię i Nazwisko: {driver.Name}, Wolne minuty: {driver.FreeMinutes}");
            }
            _commandHandler.Execute(new RentCarCommand()
            {
                RentalId = rental1Id,
                Started = DateTime.Now,
                CarId = carId,
                DriverId = driver1Id
            });
            Console.WriteLine("Kierowca o id 1 wypożycza samochód");
            var Rentals = _queryHandler.Execute(new GetAllRentalsQuery());
            foreach (var Rental in Rentals)
            {
                Console.WriteLine($"Id wypożyczenia: {Rental.Id}, Id kierowcy: {Rental.DriverId}, Rozpoczęcie: {Rental.Started}, Zakończenie: W trakcie jazdy, Do zapłaty: {Rental.Total_Currency} \r\n");
            }
            _commandHandler.Execute(new ReturnCarCommand()
            {
                RentalId = rental1Id,
                Finished = DateTime.Now.AddHours(1).AddMinutes(15)
            });
            Console.WriteLine("Kierowca o id 1 oddaje samochód");
            Rentals = _queryHandler.Execute(new GetAllRentalsQuery());
            foreach (var Rental in Rentals)
            {
                Console.WriteLine($"Id wypożyczenia: {Rental.Id}, Id kierowcy: {Rental.DriverId}, Rozpoczęcie: {Rental.Started}, Zakończenie: {Rental.Finished}, Do zapłaty: {Rental.Total_Currency} \r\n");
            }
 

            Console.WriteLine("Kierowca o id 2 wypożycza samochód");
            _commandHandler.Execute(new RentCarCommand()
            {
                RentalId = rental2Id,
                Started = DateTime.Now,
                CarId = carId,
                DriverId = driver2Id
            });
            Console.WriteLine("Informacje o samochodzie");
            cars = _queryHandler.Execute(new GetAllCarsQuery());
            foreach (var car in cars)
            {
                Console.WriteLine($"Id samochodu: {car.Id}, Rejestracja: {car.RegistrationNumber}, Status: {car.Status} \r\n");
            }
  
            Rentals = _queryHandler.Execute(new GetAllRentalsQuery());
            foreach (var Rental in Rentals)
            {
                Console.WriteLine($"Id wypożyczenia: {Rental.Id}, Id kierowcy: {Rental.DriverId}, Rozpoczęcie: {Rental.Started}  \r\n");
            }
            _commandHandler.Execute(new ReturnCarCommand()
            {
                RentalId = rental2Id,
                Finished = DateTime.Now.AddHours(4).AddMinutes(30)
            });
            Console.WriteLine("Kierowca o id 2 oddaje samochód");
            Rentals = _queryHandler.Execute(new GetAllRentalsQuery());
            foreach (var Rental in Rentals)
            {
                Console.WriteLine($"Id wypożyczenia: {Rental.Id}, Id kierowcy: {Rental.DriverId}, Rozpoczęcie: {Rental.Started}, Zakończenie: {Rental.Finished}, Do zapłaty: {Rental.Total_Currency} \r\n");
            }

            Console.WriteLine("Informacje o samochodzie");
            cars = _queryHandler.Execute(new GetAllCarsQuery());
            foreach (var car in cars)
            {
                Console.WriteLine($"Id samochodu: {car.Id}, Rejestracja: {car.RegistrationNumber}, Status: {car.Status} \r\n");
            }
            Console.WriteLine("Dane kierowców");
            drivers = _queryHandler.Execute(new GetAllDriversQuery());
            foreach (var driver in drivers)
            {
                Console.WriteLine($"Id kierowcy: {driver.Id}, Imię i Nazwisko: {driver.Name}, Wolne minuty: {driver.FreeMinutes}");
            }
        }
    }
}
