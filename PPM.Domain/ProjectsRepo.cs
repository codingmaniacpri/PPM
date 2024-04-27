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
    //Making a repo class for methods of projects class
    public class ProjectsRepo : IEntityOperation<Projects>
    {
        static readonly List<Projects> projectList = new();
        readonly EmployeeRepo empobj = new();

        public void Add(Projects project)
        {
            projectList.Add(project);
        }

        public List<Projects> ListAll()
        {
            return projectList;
        }

        public Projects ListById(int id)
        {
            return projectList.Find(pid => pid.ProjectId == id)!;
        }

        public void Delete(int id)
        {
            var projectdelete = projectList.SingleOrDefault(pid => pid.ProjectId == id);
            projectList.Remove(projectdelete!);
        }

        public void AddEmployeeToProject(int employeeid, int projectid)
        {
            var projobj = projectList.SingleOrDefault(pid => pid.ProjectId == projectid);

            if (projobj != null)
            {
                var employeeobj = empobj.ListAll().SingleOrDefault(e => e.EmployeeId == employeeid);

                if(employeeobj != null)
                {
                   employeeobj.ProjectId = projectid;
                   projobj.employeeprojectlist.Add(employeeid);
                }
                
            }
            else
            {
                System.Console.WriteLine($"Project with project id {projectid} is not found");
            }
        }

        public void DeleteEmployeefromProject(int employeeid, int projectid)
        {
            var projobj = projectList.SingleOrDefault(pid => pid.ProjectId == projectid);

            if (projobj != null)
            {
                projobj!.employeeprojectlist.Remove(employeeid);
            }

            System.Console.WriteLine($"Project with project id {projectid} is not found");
        }

        //Checking if project id already exists
        public bool IsProjectId(int projectid)
        {
            if (projectList.Exists(id => id.ProjectId == projectid))
            {
                return true;
            }
            return false;
        }

        public bool IsIdInteger(string id)
        {
            if (Regex.IsMatch(id, @"^[0-9]$"))
            {
                return true;
            }
            return false;
        }

        //Checking Employee Exists in the Project
        public bool EmployeeExistsinProject(int empid)
        {
            var isExists = projectList.Find(p => p.employeeprojectlist.Contains(empid));
            if (isExists != null)
            {
                return true;
            }

            return false;
        }
    }
}
