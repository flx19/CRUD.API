using System.ComponentModel.DataAnnotations;

namespace one.hr.api.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50 , MinimumLength =2)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50 , MinimumLength =2)]
        public string Department { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public decimal Salary { get; set; }

        public int  AddresssID { get; set; }
    }
}
