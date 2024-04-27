using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using PPM.UI.Console;
using PPM.Domain;

namespace PPM.Main
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Menu menuobj = new Menu();

            int selectoption = 0;

            do
            {
                selectoption = menuobj.MenuChoices();

                //According to user input, performing functions as below

                switch (selectoption)
                {
                    case 1:
                        //Adding the project
                        Console.Clear();
                        menuobj.ProjectModule();
                        break;

                    case 2:
                        //Displaying all the projects available
                        menuobj.EmployeeModule();
                        break;

                    case 3:
                        //Adding the Roles
                        menuobj.RoleModule();
                        break;

                    case 4:
                        //Displaying the Project Details
                        menuobj.ViewProjectDetails();
                        break;

                    case 5:
                        //Saving the data in xml file
                        menuobj.SaveData();
                        break;

                    case 6:
                        //Exiting from the application
                        System.Console.WriteLine("Exiting from the application!!");
                        break;

                    default:
                        //Message when user selects the wrong option
                        System.Console.WriteLine(
                            "You selected the wrong option. Please try again!"
                        );
                        break;
                }
            } while (selectoption != 6);
        }
    }
}
