using System.Collections.Concurrent;

namespace One.HR.DataAccess
{
    public  class MockEmployeeRepository : IEmployeeRepository
    {
        private static ConcurrentDictionary<int, Employee> _employees = new ConcurrentDictionary<int, Employee>();
        private  object locker=new object();
        public MockEmployeeRepository()
        {
            init();
        }
        private  void init()
        {
            _employees.TryAdd(1, new Employee { Id = 1,FullName="john doe" , Department="HR" , Email="asjhkcv@gmail.com" });
            _employees.TryAdd(2, new Employee { Id = 2, FullName = "abbos ali", Department = "PM", Email = "ali23@gamil.com" });
            _employees.TryAdd(3, new Employee { Id = 3, FullName = "javlonbek", Department = "lead", Email = "javlon@gamil.com" });

        }
        public  async Task<IEnumerable<Employee>> GetAll()
        {
            return await Task.FromResult( _employees.Values);
        }
        public  async Task<Employee> GetById(int id)
        {
            return await Task.FromResult(_employees[id]);
        }

        public  Task<Employee> CreateEmployee(Employee employee)
        {
            int newid = 0;
            lock (locker)
            {
                newid = _employees.Keys.Max() + 1;
            }
            employee.Id = newid;
             _employees.TryAdd(newid, employee);
            return  Task.FromResult<Employee>(employee);
        }

        public async Task<Employee> UpdateEmployee(int id, Employee employee)
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
