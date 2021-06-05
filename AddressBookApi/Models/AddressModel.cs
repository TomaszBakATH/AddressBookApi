using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookApi.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CityName { get; set; }
        public string Street { get; set; }
        public string PhoneNumber { get; set; }
    }
}
