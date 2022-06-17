﻿using DDD.CarRental.Core.InfrastructureLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.ConsoleTest
{
    public class TestUtils
    {
        public static CarRentalDbContext InitializeCarRentalContext()
        {

            var sqliteConnectionString = @"Data Source=CarRental_DDD.db";
            var options = new DbContextOptionsBuilder<CarRentalDbContext>()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()))  
                .UseSqlite(sqliteConnectionString)
                .Options;


            var context = new CarRentalDbContext(options);

            return context;
        }
    }
}
