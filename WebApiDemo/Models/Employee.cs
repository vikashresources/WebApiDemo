using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiDemo.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }

        //    public string FirstName { get; set; }
        //    public string LastName { get; set; }
        //    public string Department { get; set; }
        //}
    }
}