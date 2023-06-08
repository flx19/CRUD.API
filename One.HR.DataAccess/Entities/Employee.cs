using One.HR.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace One.HR.DataAccess
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string FullName { get; set; }
       
        public string Department { get; set; }
        
        public string Email { get; set; }
        public decimal Salary { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }

        public Address Address { get; set; }
       
    }
}
