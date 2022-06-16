using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.ApplicationLayer.Commands
{
    public class ReturnCarCommand
    {
        public long RentalId { get; set; }
        public DateTime Finished { get; set; }
    }
}
