using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PPM.Model
{
    [Serializable]
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? EmployeeContactNumber { get; set; }
        public string? Address { get; set; }
        public int RoleId { get; set; }
        public int ProjectId { get; set; }

        public override string ToString()
        {
            return string.Format("Employee Id : {0}, First Name : {1}, Last Name : {2}, Email : {3}, Employee Contact Number : {4}, Address : {5}, Role Id : {6}, Project Id : {7}", EmployeeId, FirstName, LastName, Email, EmployeeContactNumber, Address, RoleId, ProjectId);
        }

    }
}
