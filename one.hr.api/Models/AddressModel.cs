using System.ComponentModel.DataAnnotations;

namespace one.hr.api.Models
{
    public class AddressModel
    {
        public int ID { get; set; }
        [Required]
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
    }
}
