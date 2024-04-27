// using NUnit.Framework;
// using PPM.Domain;
// using PPM.Model;

// namespace NUnitTestProject
// {
//     [TestFixture]

//     public class RoleRepoTests
//     {
//         [Test]

//         public void AddRoleTests()
//         {
//             //Arrange
//             Role roleobj = new Role(){RoleId = 1, RoleName = "Developer"};

//             //Act
//             RoleRepo.roleList.Add(roleobj);

//             //Assert
//             CollectionAssert.Contains(RoleRepo.roleList, roleobj);
//         }

//         [Test]

//         public void ViewRoleTests()
//         {
//             //Arrange
//             Role roleobj = new Role(){RoleId = 1, RoleName = "Tester"};
            
//             //Act
//             RoleRepo.roleList.Add(roleobj);

//             //Assert
//             Assert.That(RoleRepo.roleList.Contains(roleobj));
//         }

//     }
// }