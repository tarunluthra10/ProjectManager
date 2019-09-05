using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using ProjectManager.Web;
using System.Data.Entity;
using ProjectManager.Web.BC;
using System.Linq;
using System.Collections.Generic;
using ProjectManager.Web.Models;

namespace ProjectManager.Tests.BC
{
    [TestClass]
    public class ProjectUnitTest
    {
[Test]
        public void AddProjectTestMethod()
        {
            int expected = 1;
            var data = new List<Project>
            {
                new Project { End_Date=DateTime.Now,Priority=2,Project1="", Project_ID=1, Start_Date=DateTime.Now,
                    Tasks =new List<Task>{   new Task{ Start_Date=DateTime.Now},new Task{ Start_Date=DateTime.Now} },
                    Users=new List<User>{
                            new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =3,User_ID=1 },
                            new User { Employee_ID =2, First_Name="ABC1", Last_Name="XYZ1",Project=null, Project_ID=1, Task = null, Task_ID =2,User_ID=2 } } },
                 //new Project { End_Date=DateTime.Now,Priority=2,Project1="", Project_ID=2, Start_Date=DateTime.Now,
                 //   Tasks =new List<Task>{   new Task{ Start_Date=DateTime.Now},new Task{ Start_Date=DateTime.Now} },
                 //   Users=new List<User>{
                 //           new User { Employee_ID =4, First_Name="ABC2", Last_Name="XYZ2",Project=null, Project_ID=2, Task = null, Task_ID =3,User_ID=4 },
                 //           new User { Employee_ID =5, First_Name="ABC3", Last_Name="XYZ3",Project=null, Project_ID=2, Task = null, Task_ID =2,User_ID=5 } } },

            }.AsQueryable();
            var userData = new List<User>
            {
                new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC1", Last_Name="XYZ",Project=null, Project_ID=2, Task = null, Task_ID =2,User_ID=2 },

            }.AsQueryable();
            var mockSet = new Mock<DbSet<Project>>();
            mockSet.As<IQueryable<Project>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Project>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockSet1 = new Mock<DbSet<User>>();
            mockSet1.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockSet1.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockSet1.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockSet1.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<Project>()).Returns(mockSet.Object);

            mockContext.Setup(m => m.Projects).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<User>()).Returns(mockSet1.Object);
            mockContext.Setup(m => m.Users).Returns(mockSet1.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(expected);


            var objUserBC = new ProjectBC(mockContext.Object);
            ProjectItem abcItem = new ProjectItem()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ProjectName = "",
                Priority = 1,
                ManagerId = 1
            };
           var retrunedValue = objUserBC.AddNewProject(abcItem);

            NUnit.Framework.Assert.AreEqual(true, retrunedValue);

        }

        [Test]
        public void RemoveProjectTestMethod()
        {
            int expected = 1;
            var data = new List<Project>
            {
                new Project { End_Date=DateTime.Now,Priority=2,Project1="", Project_ID=1, Start_Date=DateTime.Now,
                    Tasks =new List<Task>{   new Task{ Start_Date=DateTime.Now},new Task{ Start_Date=DateTime.Now} },
                    Users=new List<User>{
                            new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =3,User_ID=1 },
                            new User { Employee_ID =2, First_Name="ABC1", Last_Name="XYZ1",Project=null, Project_ID=1, Task = null, Task_ID =2,User_ID=2 } } },
                
            }.AsQueryable();
            var userData = new List<User>
            {
                new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC1", Last_Name="XYZ",Project=null, Project_ID=2, Task = null, Task_ID =2,User_ID=2 },

            }.AsQueryable();

            var taskData = new List<Task>
            {
                new Task{ Start_Date=DateTime.Now,End_Date=DateTime.Now,Project_ID=1},
                 new Task{ Start_Date=DateTime.Now,End_Date=DateTime.Now,Project_ID=1}

            }.AsQueryable();
            var mockSet = new Mock<DbSet<Project>>();
            mockSet.As<IQueryable<Project>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Project>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockSet1 = new Mock<DbSet<User>>();
            mockSet1.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockSet1.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockSet1.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockSet1.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            var mockSet2 = new Mock<DbSet<Task>>();
            mockSet2.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(taskData.Provider);
            mockSet2.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(taskData.Expression);
            mockSet2.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(taskData.ElementType);
            mockSet2.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(taskData.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<Project>()).Returns(mockSet.Object);
            mockContext.Setup(m => m.Projects).Returns(mockSet.Object);

            mockContext.Setup(m => m.Set<User>()).Returns(mockSet1.Object);
            mockContext.Setup(m => m.Users).Returns(mockSet1.Object);

            mockContext.Setup(m => m.Set<Task>()).Returns(mockSet2.Object);
            mockContext.Setup(m => m.Tasks).Returns(mockSet2.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(expected);

            var objUserBC = new ProjectBC(mockContext.Object);
            ProjectItem abcItem = new ProjectItem()
            {
                ProjectId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ProjectName = "",
                Priority = 1,
                ManagerId = 1
            };

            var retrunedValue = objUserBC.RemoveProject(abcItem);

            NUnit.Framework.Assert.AreEqual(true, retrunedValue);

        }

        [Test]
        public void UpdateProjectTestMethod()
        {
            int expected = 1;
            var data = new List<Project>
            {
                new Project { End_Date=DateTime.Now,Priority=2,Project1="", Project_ID=1, Start_Date=DateTime.Now,
                    Tasks =new List<Task>{   new Task{ Start_Date=DateTime.Now},new Task{ Start_Date=DateTime.Now} },
                    Users=new List<User>{
                            new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =3,User_ID=1 },
                            new User { Employee_ID =2, First_Name="ABC1", Last_Name="XYZ1",Project=null, Project_ID=1, Task = null, Task_ID =2,User_ID=2 } } },
                 
            }.AsQueryable();
            var userData = new List<User>
            {
                new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC1", Last_Name="XYZ",Project=null, Project_ID=2, Task = null, Task_ID =2,User_ID=2 },

            }.AsQueryable();
            var mockSet = new Mock<DbSet<Project>>();
            mockSet.As<IQueryable<Project>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Project>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockSet1 = new Mock<DbSet<User>>();
            mockSet1.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockSet1.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockSet1.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockSet1.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<Project>()).Returns(mockSet.Object);
            mockContext.Setup(m => m.Projects).Returns(mockSet.Object);

            mockContext.Setup(m => m.Set<User>()).Returns(mockSet1.Object);
            mockContext.Setup(m => m.Users).Returns(mockSet1.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(expected);

            var objUserBC = new ProjectBC(mockContext.Object);
            ProjectItem abcItem = new ProjectItem()
            {
                ProjectId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ProjectName = "",
                Priority = 1,
                ManagerId = 1
            };

            var retrunedValue = objUserBC.UpdateProject(abcItem);

            NUnit.Framework.Assert.AreEqual(true, retrunedValue);

        }

      [Test]
        public void GetAllProjectTestMethod()
        {
            var data = new List<Project>
            {
                new Project { End_Date=DateTime.Now,Priority=2,Project1="", Project_ID=1, Start_Date=DateTime.Now,
                    Tasks =new List<Task>{   new Task{ Start_Date=DateTime.Now},new Task{ Start_Date=DateTime.Now,Status="true"}},
                    Users=new List<User>{
                            new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =3,User_ID=1 },
                            new User { Employee_ID =2, First_Name="ABC1", Last_Name="XYZ1",Project=null, Project_ID=1, Task = null, Task_ID =2,User_ID=2 } } },

            }.AsQueryable();

            var taskData = new List<Task> { new Task { Start_Date = DateTime.Now }, new Task { Start_Date = DateTime.Now, Status = "true" } }.AsQueryable();
            var userData = new List<User>
            {
                new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=2, Task = null, Task_ID =2,User_ID=2 },
                new User { Employee_ID =3, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=3, Task = null, Task_ID =3,User_ID=3 },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Project>>();
            mockSet.As<IQueryable<Project>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Project>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Project>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Project>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockSet1 = new Mock<DbSet<Task>>();
            mockSet1.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(taskData.Provider);
            mockSet1.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(taskData.Expression);
            mockSet1.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(taskData.ElementType);
            mockSet1.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(taskData.GetEnumerator());

            var mockSet2 = new Mock<DbSet<User>>();
            mockSet2.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockSet2.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockSet2.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockSet2.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<Project>()).Returns(mockSet.Object);
            mockContext.Setup(m => m.Projects).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<Task>()).Returns(mockSet1.Object);
            mockContext.Setup(m => m.Tasks).Returns(mockSet1.Object);
            mockContext.Setup(m => m.Set<User>()).Returns(mockSet2.Object);
            mockContext.Setup(m => m.Users).Returns(mockSet2.Object);
           

            var objProjectBC = new ProjectBC(mockContext.Object);
            ProjectItem abcItem = new ProjectItem()
            {
                ProjectId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ProjectName = "",
                Priority = 1,
                ManagerId = 1,
                Completed = "C"
            };

            var retrunedValue = objProjectBC.GetAllProjects();

            NUnit.Framework.Assert.GreaterOrEqual(retrunedValue.Count(),1);

        }
    }
}
