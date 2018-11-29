using System;
using System.Collections.Generic;

namespace Outlook_Signatures_Management.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}