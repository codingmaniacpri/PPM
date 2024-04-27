using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml.Serialization;
using PPM.Domain;
using PPM.Model;

namespace PPM.UI.Console
{
    public class Menu
    {
        readonly ProjectsRepo projectsRepoobj = new ProjectsRepo();
        readonly EmployeeRepo employeeRepoobj = new EmployeeRepo();
        readonly RoleRepo roleRepoobj = new RoleRepo();
        readonly Save saveddata = new Save();

        public int MenuChoices()
        {
            int selectoption = 0;

            System.Console.ForegroundColor = ConsoleColor.DarkBlue;

            System.Console.WriteLine("----------PROLIFICS PROJECT MANAGER------------------");

            System.Console.WriteLine("-------------------------------------");
            System.Console.WriteLine("               MENU                  ");
            System.Console.WriteLine("-------------------------------------");
            System.Console.WriteLine("1. Project Module");
            System.Console.WriteLine("2. Employee Module");
            System.Console.WriteLine("3. Role Module");
            System.Console.WriteLine("4. View All Details");
            System.Console.WriteLine("5. Save Data");
            System.Console.WriteLine("6. Quit");
            System.Console.WriteLine("-------------------------------------");

            System.Console.ResetColor();
            //Taking input from user from above menu options
            System.Console.WriteLine("Enter any option from above menu: ");
            selectoption = int.Parse(System.Console.ReadLine()!);

            return selectoption;
        }

        public void ProjectModule()
        {
            int projectoption = 0;

            do
            {
                System.Console.WriteLine("***************************************");
                System.Console.WriteLine("             PROJECT MENU              ");
                System.Console.WriteLine("***************************************");
                System.Console.WriteLine();
                System.Console.WriteLine("1. Add Project");
                System.Console.WriteLine("2. List All the Project");
                System.Console.WriteLine("3. List By Id");
                System.Console.WriteLine("4. Delete the Project");
                System.Console.WriteLine("5. Add Employee in the Project");
                System.Console.WriteLine("6. Remove Employee from the Project");
                System.Console.WriteLine("7. Return to Main Menu");
                System.Console.WriteLine("***************************************");

                System.Console.WriteLine("Enter any option from above menu:");

                projectoption = int.Parse(System.Console.ReadLine()!);

                switch (projectoption)
                {
                    case 1:
                        Projects projectsobj = new Projects();
                        //Taking input of project data from user
                        System.Console.WriteLine("Enter the Project details to add the project: ");

                        //Project Id Validation
                        System.Console.WriteLine("Enter the Project Id: ");
                        int projectId;

                        //TryParse used to check whether projectid contains string or not
                        if (!int.TryParse(System.Console.ReadLine(), out projectId))
                        {
                            System.Console.WriteLine("The Format is incorrect. Please enter numeric value!");
                            break;
                        }

                        //Check if project already exists
                        if (projectsRepoobj.IsProjectId(projectId))
                        {
                            System.Console.WriteLine("The project id already exists. Enter different id");
                            return;
                        }

                        System.Console.WriteLine("Enter the Project Name: ");
                        string projectName = System.Console.ReadLine()!;

                        //Project start and end date validation
                        System.Console.WriteLine("Enter the Start Date: ");
                        var startDateString = System.Console.ReadLine()!;
                        DateTime startDate = DateTime.Parse(startDateString, new CultureInfo("en-US"));

                        System.Console.WriteLine("Enter the End Date: ");
                        var endDateString = System.Console.ReadLine()!;
                        DateTime endDate = DateTime.Parse(endDateString, new CultureInfo("en-US"));

                        if (startDate.Date >= endDate.Date)
                        {
                            System.Console.WriteLine("The Start date is greater than End date. Enter the correct date again!");
                            return;
                        }

                        projectsobj.ProjectId = projectId;
                        projectsobj.ProjectName = projectName;
                        projectsobj.StartDate = startDate;
                        projectsobj.EndDate = endDate;
                        projectsRepoobj.Add(projectsobj);

                        while (true)
                        {
                            System.Console.WriteLine("Do you want to add employee to the project: [yes/no]");
                            string addemployee = System.Console.ReadLine()!;

                            if (addemployee == "yes")
                            {
                                System.Console.WriteLine("Enter the employee id: ");
                                int addemployeeid = int.Parse(System.Console.ReadLine()!);

                                //Checking if employee already exists in the project
                                if (projectsRepoobj.EmployeeExistsinProject(addemployeeid))
                                {
                                    System.Console.WriteLine("The employee already exists in the project!");
                                    return;
                                }

                                projectsRepoobj.AddEmployeeToProject(addemployeeid,projectsobj.ProjectId);
                                System.Console.WriteLine("The Employee is added to the Project");
                            }
                            else
                            {
                                System.Console.WriteLine("Returning to the Main Menu............");
                                return;
                            }
                        }

                    case 2:
                        //Displaying the project details of project
                        if(projectsRepoobj.ListAll().Count == 0)
                        {
                            System.Console.WriteLine("No projects exists!!");
                            break;
                        }

                        System.Console.WriteLine("The Project details are as follows: ");

                        System.Console.ForegroundColor = ConsoleColor.DarkYellow;

                        var projectdetails = projectsRepoobj.ListAll();

                        foreach (var project in projectdetails)
                        {
                            System.Console.WriteLine(project.ToString());
                        }

                        System.Console.ResetColor();
                        break;

                    case 3:
                        System.Console.WriteLine("Enter the Project Id for details: ");
                        int projectid = int.Parse(System.Console.ReadLine()!);


                        if (projectsRepoobj.ListById(projectid) == null)
                        {
                            System.Console.WriteLine("No Projects exists!!");
                            break;
                        }

                        System.Console.WriteLine($"The Project details of {projectid} are: ");
                        var projectdetailbyid = projectsRepoobj.ListById(projectid);

                        System.Console.ForegroundColor = ConsoleColor.DarkGreen;

                        System.Console.WriteLine(projectdetailbyid.ToString());
                        System.Console.ResetColor();
                        break;

                    case 4:
                        System.Console.WriteLine("Enter the Project Id for deleting the project: ");
                        int deleteprojectid = int.Parse(System.Console.ReadLine()!);

                        if (projectsRepoobj.ListAll() == null)
                        {
                            System.Console.WriteLine("No Projects exists!!");
                        }

                        projectsRepoobj.Delete(deleteprojectid);
                        System.Console.WriteLine("The Project is deleted successfully!");
                        break;

                    case 5:
                        System.Console.WriteLine("Enter the project id: ");
                        int project_id = int.Parse(System.Console.ReadLine()!);

                        System.Console.WriteLine("Enter the employee id you want to add: ");
                        int employee_id = int.Parse(System.Console.ReadLine()!);

                        if (projectsRepoobj.EmployeeExistsinProject(employee_id))
                        {
                            System.Console.WriteLine("The employee already exists in the project!");
                        }
                        else
                        {
                            projectsRepoobj.AddEmployeeToProject(employee_id, project_id);
                            System.Console.WriteLine("Employee added in Project!!");
                        }

                        break;

                    case 6:
                        System.Console.WriteLine("Enter the project id: ");
                        int deleteproject = int.Parse(System.Console.ReadLine()!);

                        System.Console.WriteLine("Enter the employee id: ");
                        int employeeid = int.Parse(System.Console.ReadLine()!);

                        projectsRepoobj.DeleteEmployeefromProject(employeeid, deleteproject);

                        System.Console.ForegroundColor = ConsoleColor.DarkRed;

                        System.Console.WriteLine($"Employee of employee id : {employeeid} is removed from project having project id : {deleteproject}");

                        System.Console.ResetColor();
                        break;

                    case 7:
                        System.Console.WriteLine("Returning to the Main Menu............");
                        return;

                    default:
                        System.Console.WriteLine("You selected the wrong option!");
                        break;
                }
            } while (projectoption != 7);
        }

        public void EmployeeModule()
        {
            int employeeoption = 0;

            do
            {
                System.Console.WriteLine("***************************************");
                System.Console.WriteLine("             EMPLOYEE MENU             ");
                System.Console.WriteLine("***************************************");
                System.Console.WriteLine();
                System.Console.WriteLine("1. Add Employee");
                System.Console.WriteLine("2. List All the Employees");
                System.Console.WriteLine("3. List Employee by Id");
                System.Console.WriteLine("4. Delete Employee");
                System.Console.WriteLine("5. Return to Main Menu");
                System.Console.WriteLine("***************************************");

                System.Console.WriteLine("Enter any option from above menu: ");

                employeeoption = int.Parse(System.Console.ReadLine()!);

                switch (employeeoption)
                {
                    case 1:
                        Employees employeeobj = new Employees();

                        //Taking input of employees data from user
                        System.Console.WriteLine("Enter the employee details: ");

                        //Employee Id Validation
                        System.Console.WriteLine("Enter the Employee Id: ");
                        int employeeId = int.Parse(System.Console.ReadLine()!);

                        if (employeeRepoobj.IsIdExists(employeeId))
                        {
                            System.Console.WriteLine("The employee already exists. Please try again!");
                            return;
                        }

                        System.Console.WriteLine("Enter the Employee First Name: ");
                        string firstName = System.Console.ReadLine()!;

                        //Checking if name contains any numeric values
                        if (employeeRepoobj.NameNumericValue(firstName))
                        {
                            System.Console.WriteLine("Name can't contain numeric values!");
                            break;
                        }

                        //Checking if name length is correct
                        if (employeeRepoobj.NameLength(firstName))
                        {
                            System.Console.WriteLine("Name should be greater than 3 characters!");
                            break;
                        }

                        System.Console.WriteLine("Enter the Employee Last Name: ");
                        string lastName = System.Console.ReadLine()!;

                        //Checking if name contains any numeric values
                        if (employeeRepoobj.NameNumericValue(lastName))
                        {
                            System.Console.WriteLine("Name can't contain numeric values!");
                            break;
                        }

                        //Checking if name length is correct
                        if (employeeRepoobj.NameLength(lastName))
                        {
                            System.Console.WriteLine("Name should be greater than 3 characters!");
                            break;
                        }

                        //Employee Email Validation
                        System.Console.WriteLine("Enter the Employee Email: ");
                        string email = System.Console.ReadLine()!;

                        if (employeeRepoobj.IsEmailFormat(email))
                        {
                            System.Console.WriteLine("Incorrect email format.Please try again!");
                            return;
                        }

                        if (employeeRepoobj.EmailExists(email))
                        {
                            System.Console.WriteLine("The email already exists. Enter different email!");
                            return;
                        }

                        //Employee Contact Number Validation
                        System.Console.WriteLine("Enter the Employee Contact Number: ");
                        string employeeContactNumber = System.Console.ReadLine()!;

                        if (employeeRepoobj.IsContactFormat(employeeContactNumber))
                        {
                            System.Console.WriteLine("Incorrect format for contact number. Try Again!");
                            return;
                        }

                        if (employeeRepoobj.ContactNumberExists(employeeContactNumber))
                        {
                            System.Console.WriteLine("Contact number already exists. Try Again!");
                            return;
                        }

                        //Employee Address Validation
                        System.Console.WriteLine("Enter the Employee Address: ");
                        string address = System.Console.ReadLine()!;
                        if (address.Length < 10)
                        {
                            System.Console.WriteLine("Address should be greater than 10 words!");
                            return;
                        }

                        //Role Id Validation
                        System.Console.WriteLine("Enter the Role Id: ");
                        int roleId = int.Parse(System.Console.ReadLine()!);
                        if (!roleRepoobj.ListAll().Exists(id => id.RoleId == roleId))
                        {
                            System.Console.WriteLine("Role Id does not exists!");
                            return;
                        }

                        employeeobj.EmployeeId = employeeId;
                        employeeobj.FirstName = firstName;
                        employeeobj.LastName = lastName;
                        employeeobj.Email = email;
                        employeeobj.EmployeeContactNumber = employeeContactNumber;
                        employeeobj.Address = address;
                        employeeobj.RoleId = roleId;
                        employeeRepoobj.Add(employeeobj);

                        System.Console.WriteLine("The employee is added!");
                        break;

                    case 2:
                        System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                        System.Console.WriteLine("The Employees details are: ");
                        var employeedetails = employeeRepoobj.ListAll();

                        foreach (var employee in employeedetails)
                        {
                            System.Console.WriteLine(employee.ToString());
                        }
                        System.Console.ResetColor();
                        break;

                    case 3:
                        System.Console.WriteLine("Enter the Employee Id for details: ");
                        int employeeid = int.Parse(System.Console.ReadLine()!);

                        if (employeeRepoobj.ListById(employeeid) == null)
                        {
                            System.Console.WriteLine("No Employee exists!!");
                            break;
                        }

                        System.Console.WriteLine($"The details of {employeeid} are: ");
                        var employeedetailbyid = employeeRepoobj.ListById(employeeid);
                        System.Console.WriteLine(employeedetailbyid.ToString());
                        break;

                    case 4:
                        System.Console.WriteLine("Enter the Employee Id to delete employee: ");
                        int deleteid = int.Parse(System.Console.ReadLine()!);

                        if (projectsRepoobj.EmployeeExistsinProject(deleteid))
                        {
                            System.Console.WriteLine("The Employee is assigned to the project already");
                            return;
                        }
                        else
                        {
                            employeeRepoobj.Delete(deleteid);
                            System.Console.WriteLine("Employee is deleted successfully!");
                            break;
                        }

                    case 5:
                        System.Console.WriteLine("Returning to the Main Menu...............");
                        return;
                }
            } while (employeeoption != 5);
        }

        public void RoleModule()
        {
            int roleoption = 0;
            do
            {
                System.Console.WriteLine("***************************************");
                System.Console.WriteLine("               ROLE MENU               ");
                System.Console.WriteLine("***************************************");
                System.Console.WriteLine();
                System.Console.WriteLine("1. Add Role");
                System.Console.WriteLine("2. List All Roles");
                System.Console.WriteLine("3. List Role By Id");
                System.Console.WriteLine("4. Delete Role");
                System.Console.WriteLine("5. Return to the Main Menu");
                System.Console.WriteLine("***************************************");

                System.Console.WriteLine("Enter any option from above menu: ");
                roleoption = int.Parse(System.Console.ReadLine()!);

                switch (roleoption)
                {
                    case 1:
                        //Taking input of roles data from user
                        System.Console.WriteLine("Enter the roles: ");

                        System.Console.WriteLine("Enter the Role Id: ");
                        int roleId = int.Parse(System.Console.ReadLine()!);

                        if (roleRepoobj.AddRoleExists(roleId))
                        {
                            System.Console.WriteLine("Role Id already exists!!");
                            break;
                        }

                        System.Console.WriteLine("Enter the Role Name: ");
                        string roleName = System.Console.ReadLine()!;

                        Role roleobj = new Role();
                        roleobj.RoleId = roleId;
                        roleobj.RoleName = roleName;

                        roleRepoobj.Add(roleobj);
                        break;

                    case 2:
                        System.Console.ForegroundColor = ConsoleColor.DarkGreen;
                        System.Console.WriteLine("The Roles are as follows: ");
                        var roledetails = roleRepoobj.ListAll();

                        foreach (var roles in roledetails)
                        {
                            System.Console.WriteLine(roles.ToString());
                        }
                        System.Console.ResetColor();
                        break;

                    case 3:
                        System.Console.WriteLine("Enter the role id for details: ");
                        int roleid = int.Parse(System.Console.ReadLine()!);

                        if (roleRepoobj.ListById(roleid) == null)
                        {
                            System.Console.WriteLine("No Role exists!!");
                            break;
                        }

                        System.Console.WriteLine($"The role detail of {roleid} are: ");
                        var roledetailbyid = roleRepoobj.ListById(roleid);

                        System.Console.WriteLine(roledetailbyid.ToString());
                        break;

                    case 4:
                        System.Console.WriteLine("Enter the role id for deleting role: ");
                        int deleterole = int.Parse(System.Console.ReadLine()!);

                        if (roleRepoobj.RoleExists(deleterole))
                        {
                            System.Console.WriteLine("Role assigned to an employee already!");
                            break;
                        }

                        roleRepoobj.Delete(deleterole);
                        System.Console.WriteLine("The Role is deleted successfully!");
                        break;

                    case 5:
                        System.Console.WriteLine("Returning to the Main Menu..............");
                        return;
                }
            } while (roleoption != 5);
        }

        public void ViewProjectDetails()
        {
            System.Console.ForegroundColor = ConsoleColor.DarkGreen;
            System.Console.WriteLine("Enter the project id: ");
            int projectid = int.Parse(System.Console.ReadLine()!);

            var projectDetails = projectsRepoobj.ListAll().SingleOrDefault(pid => pid.ProjectId == projectid);

            System.Console.WriteLine(projectDetails!.ToString());
            System.Console.WriteLine();

            foreach (var i in projectDetails.employeeprojectlist)
            {
                Employees? employeeDetails = employeeRepoobj.ListAll().SingleOrDefault(e => e.EmployeeId == i);
                Role? roledetails = roleRepoobj.ListAll().SingleOrDefault(pid => pid.RoleId == employeeDetails!.RoleId);

                System.Console.WriteLine(employeeDetails!.ToString());

                System.Console.WriteLine();

                System.Console.WriteLine(roledetails!.ToString());
            }
            System.Console.ResetColor();
        }

        public void SaveData()
        {
            saveddata.SaveToXML();
            System.Console.WriteLine("The Data is saved!!");
        }
    }
}
