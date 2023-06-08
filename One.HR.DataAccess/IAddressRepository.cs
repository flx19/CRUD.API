
using One.HR.DataAccess.Entities;

namespace One.HR.DataAccess
{
    public interface IAddressRepository
    {
      public Task<IEnumerable<Address>> GetAll();
      public  Task<Address> GetById(int id);

      public  Task<Address> CreateAddress(Address Address);
      public Task<Address> UpdateAddress(int id, Address Address);
      public Task<bool> DeleteAddress(int id);
    }
}