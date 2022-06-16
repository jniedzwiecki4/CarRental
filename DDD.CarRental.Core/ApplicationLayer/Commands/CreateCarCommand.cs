using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.ApplicationLayer.Commands
{
    public enum CreateCarStatus
    {
        FREE = 0,
        RESERVED = 1,
        RENT = 2
    }
    public class CreateCarCommand
    {
        public long CarId { get; set; }
        public string RegistrationNumber { get; set; }

        public decimal CurrentDistance { get; set; }

        public decimal TotalDistance { get; set; }

        public CreateCarStatus _Status { get; set; }

        public decimal XCurrentPosition { get; set; }
        public decimal YCurrentPosition { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
