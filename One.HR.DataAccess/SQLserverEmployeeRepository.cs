using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.HR.DataAccess
{
    public class SQLserverEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbcontext _dbcontext;
        public SQLserverEmployeeRepository(AppDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async  Task<Employee> CreateEmployee(Employee employee)
        {
            await _dbcontext.Employees.AddAsync(employee);
            await _dbcontext.SaveChangesAsync();
            return employee;
        }

        public async  Task<bool> DeleteEmployee(int id)
        {
            var employee = await _dbcontext.FindAsync<Employee>(id); 
            if(employee != null)
            {
                _dbcontext.Employees.Remove(employee);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
           return await _dbcontext.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
           return await _dbcontext.Employees.FindAsync(id);
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
        {
            var updated = _dbcontext.Employees.Attach(employee);
            updated.State= EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return employee;
        }
    }
}
