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

namespace PPM.Domain{

//Making a repo class for methods of role class
    public class RoleRepo : IEntityOperation<Role>
    {
       static readonly List<Role> roleList = new();

        public void Add(Role roles)
        {
            roleList.Add(roles);
        }

        public List<Role> ListAll()
        {
            return roleList;
        }

        public Role ListById(int id)
        {
            return roleList.Find(rid => rid.RoleId == id)!;
        }

        public void Delete(int id)
        {
            var deleterole = roleList.SingleOrDefault(rid => rid.RoleId == id);
            roleList.Remove(deleterole!);
        }

        //  Checking if deleting employee, role assigned to it or not
        public bool RoleExists(int roleid)
        {
            EmployeeRepo employeeRepo = new();
            return employeeRepo.ListAll().Exists(r => r.RoleId == roleid);
        }

        //Checking if role id already exists
        public bool AddRoleExists(int roleid)
        {
            return ListAll().Exists(role => role.RoleId == roleid);
        }
    }
}