using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;
using PPM.Model;

namespace PPM.Domain
{
public class EmployeeRepo : IEntityOperation<Employees>
{
    static readonly List<Employees> employeeList = new();
    public void Add(Employees employee)
    {
        
        employeeList.Add(employee);
    }

    public List<Employees> ListAll()
    {
        return employeeList;
       
    }

    public Employees ListById(int id)
    {
        return employeeList.Find(eid => eid.EmployeeId == id)!;
    }

    public void Delete(int id)
    {
        var employeedelete = employeeList.Find(eid => eid.EmployeeId == id);
        employeeList.Remove(employeedelete!);
    }
    
        
    //ID Validation method
    public bool IsIdExists(int employeeid)
    {
        if(employeeList.Exists(id => id.EmployeeId == employeeid))
        {
            return true;
        }
        return false;
    }

    //Email validation method
    public bool IsEmailFormat(string email)
    {
        string emailvalid = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        if (Regex.IsMatch(email, emailvalid))
        {
            return false;
        }
        return true;
    }

    //Contact Validation method
    public bool IsContactFormat(string contactnumber)
    {
        if(Regex.IsMatch(contactnumber, @"^[0-9]{10}$"))
        {
            return false;
        }
        return true;
    }

    //Contact Number Exists Validation
    public bool ContactNumberExists(string contactnumber)
    {
        if(employeeList.Exists(cn => cn.EmployeeContactNumber == contactnumber))
        {
            return true;
        }

        return false;
    }

    //Email Exists Validation
    public bool EmailExists(string email)
    {
        if(employeeList.Exists(em => em.Email == email))
        {
            return true;
        }

        return false;
    }

    //Name Numeric Value
    public bool NameNumericValue(string name)
    {
        if(name.Any(c => char.IsDigit(c)))
        {
            return true;
        }

        return false;

    }

    //Name Length checking
    public bool NameLength(string name)
    {
        if(name.Length < 3)
        {
            return true;
        }

        return false;
    }

}
}
