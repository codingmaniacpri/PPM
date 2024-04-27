// using NUnit.Framework;
// using PPM.Domain;
// using PPM.Model;

// namespace NUnitTestProject
// {

// [TestFixture]
// public class ProjectsRepoTests
// {
//     [Test]
//     public void ProjectsRepo_AddProject_ReturnsList()
//     {
//         //Arrange
//         Projects projectobj = new Projects(){ProjectId = 1, ProjectName = "Cloud", StartDate = new DateOnly(2023,08,08), EndDate = new DateOnly(2024,09,10)};

//         //Act
//         ProjectsRepo.Add(projectobj);

//         //Assert
//         CollectionAssert.Contains(ProjectsRepo.projectList,projectobj);
//     }

//     [Test]
//     public void ProjectsRepo_DeleteProjectTests()
//     {
//         //Arrange
//         Projects projectobj = new Projects(){ProjectId = 1, ProjectName = "Cloud", StartDate = new DateOnly(2023,08,08), EndDate = new DateOnly(2024,09,10)};

//         //Act 
//         ProjectsRepo.projectList.Remove(projectobj);

//         //Assert
//         CollectionAssert.DoesNotContain(ProjectsRepo.projectList,projectobj);
//     }

//     [Test]
//     public void AddEmployeeToProjectTests()
//     {
//         //Arrange
//         var ProjectsRepo = new ProjectsRepo();
//         var projectId = 1;
//         var employeeId = 1;

//         ProjectsRepo.projectList.Add(new Projects { ProjectId = projectId, ProjectName = "Cloud", StartDate = new DateOnly(2023,08,08), EndDate = new DateOnly(2024,09,10)});

//         //Act
//         ProjectsRepo.AddEmployeeToProject(employeeId,projectId);

//         //Assert
//         var project = ProjectsRepo.projectList.SingleOrDefault(pid => pid.ProjectId == projectId);
//         Assert.IsNotNull(project, "Project not found");
//         Assert.IsTrue(project!.employeeprojectlist.Contains(employeeId));
//     }

//     public void DeleteEmployeeFromProjectTests()
//     {
//         //Arrange
//         var ProjectsRepo = new ProjectsRepo();
//         var projectId = 1;
//         var employeeId = 1;

//         ProjectsRepo.projectList.Add(new Projects { ProjectId = projectId, ProjectName = "App", StartDate = new DateOnly(2024, 12, 12), EndDate = new DateOnly(2025, 11, 13)});

//         //Act
//         ProjectsRepo.DeleteEmployeefromProject(employeeId, projectId);

//         //Assert
//         var deleteproject = ProjectsRepo.projectList.SingleOrDefault(pid => pid.ProjectId == projectId);
//         Assert.IsNotNull(deleteproject, "Project not found");
//         Assert.IsTrue(deleteproject!.employeeprojectlist.Contains(employeeId));
//     }
// }
// }