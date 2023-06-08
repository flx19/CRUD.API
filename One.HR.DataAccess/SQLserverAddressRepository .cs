using Microsoft.EntityFrameworkCore;
using One.HR.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.HR.DataAccess
{
    public class SQLserverAddressRepository : IAddressRepository
    {
        private readonly AppDbcontext _dbcontext;
        public SQLserverAddressRepository(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Address> CreateAddress(Address Address)
        {
            await _dbcontext.Addresses.AddAsync(Address);
            await _dbcontext.SaveChangesAsync();
            return Address;
        }

        public async Task<bool> DeleteAddress(int id)
        {
            var address = await _dbcontext.FindAsync<Address>(id);
            if (address != null)
            {
                _dbcontext.Addresses.Remove(address);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }

       public async Task<Address> UpdateAddress(int id, Address Address)
       {
            var updated = _dbcontext.Addresses.Attach(Address);
            updated.State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return Address;
       }
       public async Task<IEnumerable<Address>> GetAll()
       {
           return await _dbcontext.Addresses.ToListAsync();
       }

       public async Task<Address> GetById(int id)
       {
            return await _dbcontext.Addresses.FindAsync(id);
       }
    }
}
