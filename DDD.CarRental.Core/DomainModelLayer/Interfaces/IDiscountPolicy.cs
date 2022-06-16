using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Interfaces
{
    public interface IDiscountPolicy
    {
        string Name { get; }
        public int CalculateDiscount(int numOfMinutes);
    }
}
