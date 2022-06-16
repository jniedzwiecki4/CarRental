using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.ApplicationLayer.DTOs
{
    public class CarDTO
    {
        public enum StatusDTO
        {
            FREE = 0,
            RESERVED = 1,
            RENT = 2
        }


        public long Id { get; set; }

        public string RegistrationNumber { get; set; }

        public StatusDTO Status { get; set; }

        public string CurrentPosition { get; set; }

        public string UnitPrice_Currency { get; set; }

        public string TotalDistance { get; set; }
    }
}
