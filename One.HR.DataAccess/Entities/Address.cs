using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One.HR.DataAccess.Entities
{
    public class Address
    {
        public int ID { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set;}

        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
