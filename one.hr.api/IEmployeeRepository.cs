using one.hr.api.Models;

namespace one.hr.api
{
    public interface IEmployeeRepository
    {
      public Task<IEnumerable<EmployeeModel>> GetAll();
      public  Task<EmployeeModel> GetById(int id);

      public  Task<EmployeeModel> CreateEmployee(EmployeeModel employee);
      public Task<EmployeeModel> UpdateEmployee(int id, EmployeeModel employee);
      public Task<bool> DeleteEmployee(int id);
    }
}