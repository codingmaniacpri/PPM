using NUnit.Framework;
using PPM.Domain;
using PPM.Model;
using System.Text.RegularExpressions;

namespace NUnitTestProject
{
    [TestFixture]
    public class EmployeeRepoTests
    {
       public readonly EmployeeRepo employeeRepo = new EmployeeRepo();

        [Test]
        public void Add_ValidEmployee_AddsToEmployeeList()
        {
            // Arrange
            var employee = new Employees()
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Michael",
                Email = "johndoe@example.com",
                EmployeeContactNumber = "1234567890",
                Address = "djakhdjksahdjkahjkasd",
                RoleId = 1
            };

            // Act
            employeeRepo.Add(employee);

            // Assert
            Assert.IsTrue(employeeRepo.IsIdExists(1));
        }

        [Test]
        public void ListAll_ReturnAllEmployees()
        {
            // Arrange
            var employee1 = new Employees()
            {
                EmployeeId = 1,
                FirstName = "Tom",
                LastName = "Murphy",
                Email = "tm@gmail.com",
                EmployeeContactNumber = "7412589630",
                Address = "street 7, washington",
                RoleId = 1
            };

            Employees employee2 = new Employees()
            {
                EmployeeId = 2,
                FirstName = "Jack",
                LastName = "James",
                Email = "jj@example.com",
                EmployeeContactNumber = "7894561230",
                Address = "street 1, washington",
                RoleId = 1
            };

            employeeRepo.Add(employee1);
            employeeRepo.Add(employee2);

            // Act
            var employees = employeeRepo.ListAll();

            // Assert
            Assert.AreEqual(2, employees.Count);
            Assert.Contains(employee1, employees);
            Assert.Contains(employee2, employees);
        }
        [Test]
        public void ListById_ReturnsExistingId_ReturnsEmployee()
        {
            //Arrange
            var employee = new Employees()
            {
                EmployeeId = 1,
                FirstName = "Tom",
                LastName = "Murphy",
                Email = "tm@gmail.com",
                EmployeeContactNumber = "7412589630",
                Address = "street 7, washington",
                RoleId = 1
            };
            employeeRepo.Add(employee);

            //Act
            var existingid = employeeRepo.ListById(1);

            //Assert
            Assert.IsNotNull(existingid);
            Assert.AreEqual(employee.EmployeeId, existingid.EmployeeId);
        }

        [Test]
        public void ListById_NonExistingEmployeeId_ReturnsNull()
        {
            // Act
            var result = employeeRepo.ListById(99);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
