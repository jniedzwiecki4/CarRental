using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.InfrastructureLayer;

namespace DDD.CarRental.Core.DomainModelLayer.Interfaces
{
    public interface IDriverRepository : IRepository<Driver>
    {
        public Driver GetDriverByLicenceNumber(string licenceNumber);
    }

}
