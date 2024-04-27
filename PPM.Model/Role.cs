using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PPM.Model;
[Serializable]
//Role class containing the properties of roles
    public class Role
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public override string ToString()
        {
            return string.Format("Role Id : {0}, Role Name : {1}", RoleId, RoleName);
        }
    }
