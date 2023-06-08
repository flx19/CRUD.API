
namespace One.HR.DataAccess
{
    public interface IEmployeeRepository
    {
      public Task<IEnumerable<Employee>> GetAll();
      public  Task<Employee> GetById(int id);

      public  Task<Employee> CreateEmployee(Employee employee);
      public Task<Employee> UpdateEmployee(int id, Employee employee);
      public Task<bool> DeleteEmployee(int id);
    }
}