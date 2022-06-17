using DDD.CarRental.Core.ApplicationLayer.Commands.Handlers;
using DDD.CarRental.Core.ApplicationLayer.Mappers;
using DDD.CarRental.Core.ApplicationLayer.Queries.Handlers;
using DDD.CarRental.Core.DomainModelLayer.Factories;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.InfrastructureLayer;
using DDD.CarRental.Core.InfrastructureLayer.EF;
using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.InfrastructureLayer.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace DDD.CarRental.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var testSuit = new TestSuit(serviceCollection);
            testSuit.Run();
        }

        static private void ConfigureServices(IServiceCollection serviceCollection)
        {
            var context = TestUtils.InitializeCarRentalContext();
            serviceCollection.AddSingleton(context);
            serviceCollection.AddSingleton<CommandHandler>();
            serviceCollection.AddSingleton<QueryHandler>();
            serviceCollection.AddSingleton<IDomainEventPublisher, SimpleEventPublisher>();
            serviceCollection.AddSingleton<ICarRentalUnitOfWork, CarRentalUnitOfWork>();
            serviceCollection.AddSingleton<ICarRepository, CarRepository>();
            serviceCollection.AddSingleton<IDriverRepository, DriverRepository>();
            serviceCollection.AddSingleton<IRentalRepository, RentalRepository>();
            serviceCollection.AddSingleton<Mapper>();
            serviceCollection.AddSingleton<CarFactory>();
            serviceCollection.AddSingleton<DiscountPolicyFactory>();
            serviceCollection.AddSingleton<RentalFactory>();
            serviceCollection.AddSingleton<PositionService>();


        }
    }
}
