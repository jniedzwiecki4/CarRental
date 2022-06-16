//using DDD.SharedKernel.DomainModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public class RentalDTO
    {
        public long Id { get; set; }

        public DateTime Started { get;  set; }

        public DateTime Finished { get;  set; }

        public long CarId { get;  set; }

        public long DriverId { get;  set; }

        public decimal Total { get;  set; }
        public string Total_Currency { get; internal set; }
        public object DriverName { get; internal set; }
        public string CarRegistrationNumber { get; internal set; }
    }
}
