using Microsoft.EntityFrameworkCore.Metadata.Internal;
using one.hr.api.Models;
using One.HR.DataAccess;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace one.hr.api.Services
{
    public class EmployeeCRUDService : IGenericCRUDService<EmployeeModel>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAddressRepository ? _addressRepository;
        private readonly IAccountNumberValidationService _accountNumberValidationService;
        public EmployeeCRUDService(IEmployeeRepository employeeRepository, IAddressRepository addressRepository, IAccountNumberValidationService accountNumberValidationService)
        {
            _employeeRepository = employeeRepository;
            _addressRepository = addressRepository;
            _accountNumberValidationService = accountNumberValidationService;
        }

        public async Task<EmployeeModel> Create(EmployeeModel model)
        {
            if(!string.IsNullOrWhiteSpace(model.AccountNumber) && !_accountNumberValidationService.IsValid(model.AccountNumber))
            {
                throw new ArgumentException("invalid number");
            }
            var exisistingaddress = await _addressRepository.GetById(model.AddresssID);
            var employee = new Employee()
            {
                FullName = model.FullName,
                Department= model.Department,
                Email= model.Email,
                Salary= model.Salary,
            };
            if(exisistingaddress != null)
            {
                employee.Address.ID = exisistingaddress.ID;
            }
            var createdEployee = await _employeeRepository.CreateEmployee(employee);
            var result = new EmployeeModel()
            {
                FullName = createdEployee.FullName,
                Department = createdEployee.Department,
                Email = createdEployee.Email,
                Id = createdEployee.Id,
                Salary = createdEployee.Salary,
                AddresssID = createdEployee.Address.ID,
            };
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }

        public async  Task<IEnumerable<EmployeeModel>> GetAll()
        {
           var result = new List<EmployeeModel>();
           var employees = await _employeeRepository.GetAll();
            foreach (var employee in employees)
            {
                var model = new EmployeeModel()
                {
                    FullName = employee.FullName,
                    Department = employee.Department,
                    Email = employee.Email,
                    Id = employee.Id,
                    Salary= employee.Salary,
                    AddresssID = employee.AddressId,
                };
               
                result.Add(model);
            }
            return result;
        }

        public async Task<EmployeeModel> GetById(int id)
        {
            var employee =  await _employeeRepository.GetById(id);
            var model = new EmployeeModel()
            {
                Id = employee.Id,
                FullName = employee.FullName,
                Department = employee.Department,
                Email = employee.Email,
                Salary = employee.Salary,
                AddresssID= employee.AddressId,
            };
            return model;
        }

        public async  Task<EmployeeModel> Update(int id, EmployeeModel model)
        {
            var employee = new Employee()
            {
                FullName = model.FullName,
                Department = model.Department,
                Email = model.Email,
                Id = model.Id,
                Salary = model.Salary,
            };
            var exisistingaddress = await _addressRepository.GetById(model.AddresssID);
            if(exisistingaddress != null)
            {
                employee.Address = exisistingaddress;
            }

            var createdEployee = await _employeeRepository.UpdateEmployee(id ,employee);
            var result = new EmployeeModel()
            {
                FullName = createdEployee.FullName,
                Department = createdEployee.Department,
                Email = createdEployee.Email,
                Id = createdEployee.Id,
                Salary = createdEployee.Salary,
                AddresssID = createdEployee.Address.ID,
            };
            return result;
        }
    }
}
