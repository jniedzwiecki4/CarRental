using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Policies
{
    public class FreeMinutesDiscountPolicy : IDiscountPolicy
    {
        public string Name { get; protected set; }
        private readonly int divisor;

        public FreeMinutesDiscountPolicy()
        {
            Name = "Free Minutes Discount Policy";
            divisor = 10;
        }

        public int CalculateDiscount(int numOfMinutes)
        {
            return numOfMinutes / divisor;
        }
    }
}
