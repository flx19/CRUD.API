using one.hr.api.Models;
using System.Collections.Concurrent;

namespace one.hr.api
{
    public  class MockEmployeeRepository : IEmployeeRepository
    {
        private static ConcurrentDictionary<int, EmployeeModel> _employees = new ConcurrentDictionary<int, EmployeeModel>();
        private  object locker=new object();
        public MockEmployeeRepository()
        {
            init();
        }
        private  void init()
        {
            _employees.TryAdd(1, new EmployeeModel { Id = 1,FullName="john doe" , Department="HR" , Email="asjhkcv@gmail.com" });
            _employees.TryAdd(2, new EmployeeModel { Id = 2, FullName = "abbos ali", Department = "PM", Email = "ali23@gamil.com" });
            _employees.TryAdd(3, new EmployeeModel { Id = 3, FullName = "javlonbek", Department = "lead", Email = "javlon@gamil.com" });

        }
        public  async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            return await Task.FromResult( _employees.Values);
        }
        public  async Task<EmployeeModel> GetById(int id)
        {
            return await Task.FromResult(_employees[id]);
        }

        public  Task<EmployeeModel> CreateEmployee(EmployeeModel employee)
        {
            int newid = 0;
            lock (locker)
            {
                newid = _employees.Keys.Max() + 1;
            }
            employee.Id = newid;
             _employees.TryAdd(newid, employee);
            return  Task.FromResult<EmployeeModel>(employee);
        }

        public async Task<EmployeeModel> UpdateEmployee(int id, EmployeeModel employee)
        {
            await Task.FromResult(_employees[id] = employee);
            return employee; 
        }

        public Task<bool> DeleteEmployee(int id)
        {
            if(_employees.ContainsKey(id))
            {
                _employees.TryRemove(id, out _);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }
    }
}
