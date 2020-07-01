using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceAssignment.BusinessLayer
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeEmail { get; set; }
        public List<Place> EmployeePlace { get; set; }
    }
    public class Place
    {
        public string Places { get; set; }
        public List<Address> EmployeeAddress { get; set; }

    }
    public class Address
    {
        public string Pincodes { get; set; }

    }

}
