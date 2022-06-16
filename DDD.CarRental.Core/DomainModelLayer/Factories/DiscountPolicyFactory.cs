using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.DomainModelLayer.Policies;
using DDD.SharedKernel.DomainModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.DomainModelLayer.Factories
{
    public class DiscountPolicyFactory
    {
        private IDomainEventPublisher _domainEventPublisher;

        public DiscountPolicyFactory(IDomainEventPublisher domainEventPublisher)
        {
            _domainEventPublisher = domainEventPublisher;
        }

        public IDiscountPolicy Create(Rental rental)
        {
            IDiscountPolicy discountPolicy = new FreeMinutesDiscountPolicy();
            return discountPolicy;
        }
    }
}
