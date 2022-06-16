using DDD.SharedKernel.DomainModelLayer.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    [Keyless]
    public class Distance : ValueObject
    {

        public static readonly string DefaultUnit = "km";
        public static readonly Distance Zero = new Distance(0);

        public decimal Total { get; protected set; }

        public string Unit { get; protected set; }

        
        protected Distance()
        { }

        public Distance(decimal Total, string Unit)
        {
            this.Total = Total;
            this.Unit = Unit;
        }

        public Distance(decimal Total)
        {
            this.Total = Total;
            this.Unit = DefaultUnit;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Math.Round(Total, 2);
            yield return Unit.ToUpper();
        }

        public static Distance operator +(Distance m, Distance m2)
        {
            if (!AreCompatibleCurrencies(m, m2))
            {
                throw new ArgumentException("Unit mismatch");
            }
            return new Distance(m.Total + m2.Total, m.Unit);
        }

        public static Distance operator -(Distance m, Distance m2)
        {
            if (!AreCompatibleCurrencies(m, m2))
            {
                throw new ArgumentException("Unit mismatch");
            }
            return new Distance( m.Total - m2.Total, m.Unit);
        }

        public Distance MultiplyBy(double multiplier)
        {
            return MultiplyBy((decimal)multiplier);
        }
        public Distance MultiplyBy(int multiplier)
        {
            return MultiplyBy((decimal)multiplier);
        }

        public Distance MultiplyBy(decimal multiplier)
        {
            return new Distance(Total * multiplier, Unit);
        }

        private static bool AreCompatibleCurrencies(Distance m, Distance m2)
        {
            return IsZero(m.Total) || IsZero(m2.Total) || m.Unit.Equals(m2.Unit);
        }

        private static bool IsZero(decimal testedValue)
        {
            return decimal.Zero.CompareTo(testedValue) == 0;
        }

        public static bool operator <(Distance m, Distance m2)
        {
            return m.Total.CompareTo(m2.Total) < 0;
        }

        public static bool operator >(Distance m, Distance m2)
        {
            return m.Total.CompareTo(m2.Total) > 0;
        }

        public static bool operator >=(Distance m, Distance m2)
        {
            return m.Total.CompareTo(m2.Total) >= 0;
        }

        public static bool operator <=(Distance m, Distance m2)
        {
            return m.Total.CompareTo(m2.Total) <= 0;
        }

        public override string ToString()
        {
            return string.Format("{0}.2f {1}", Total, Unit);
        }
    }

}
