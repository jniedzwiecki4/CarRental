using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRentalLib.ApplicationLayer.DTOs
{
    public class DriverDTO
    {
        public long Id { get; set; }

        public string LicencenNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int FreeMinutes { get; set; }
        public string LicenceNumber { get; internal set; }
        public string Name { get; internal set; }
    }
}
