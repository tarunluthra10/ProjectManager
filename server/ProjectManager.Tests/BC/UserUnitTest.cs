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
    public class UserUnitTest
    {
        [Test] 
        public void RemoveUserTestMethod()
        {
            int expected = 1;
            var data = new List<User>
            {
                new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=2, Task = null, Task_ID =2,User_ID=2 },
                new User { Employee_ID =3, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=3, Task = null, Task_ID =3,User_ID=3 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<User>()).Returns(mockSet.Object);
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(expected);

            var objUserBC = new UsersBC(mockContext.Object);
            UserItem abcItem = new UserItem() { UserId = 2, EmployeeId = 2, FirstName = "ABC", LastName = "XYZ" };
            var retrunedValue = objUserBC.RemoveUser(abcItem);

            NUnit.Framework.Assert.AreEqual(true, retrunedValue);

        }

       [Test]
        public void GetAllUserTestMethod()
        {
            var data = new List<User>
            {
                new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=2, Task = null, Task_ID =2,User_ID=2 },
                new User { Employee_ID =3, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=3, Task = null, Task_ID =3,User_ID=3 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<User>()).Returns(mockSet.Object);
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            var objUserBC = new UsersBC(mockContext.Object);
            var retrunedValue = objUserBC.GetAllUsers();

            NUnit.Framework.Assert.GreaterOrEqual(retrunedValue.Count(),1);

        }

        [Test] 
        public void AddUserTestMethod()
        {
            int expected = 1;
            var data = new List<User>
            {
                new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=2, Task = null, Task_ID =2,User_ID=2 },
                new User { Employee_ID =3, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=3, Task = null, Task_ID =3,User_ID=3 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<User>()).Returns(mockSet.Object);
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(expected);

            var objUserBC = new UsersBC(mockContext.Object);
            UserItem abcItem = new UserItem() { UserId = 2, EmployeeId = 2, FirstName = "ABC", LastName = "XYZ" };
            var retrunedValue = objUserBC.AddNewUser(abcItem);

            NUnit.Framework.Assert.AreEqual(true, retrunedValue);

        }

       [Test] 
        public void UpdateUserTestMethod()
        {
            int expected = 1;
            var data = new List<User>
            {
                new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=2, Task = null, Task_ID =2,User_ID=2 },
                new User { Employee_ID =3, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=3, Task = null, Task_ID =3,User_ID=3 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<User>()).Returns(mockSet.Object);
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(expected);

            var objUserBC = new UsersBC(mockContext.Object);
            UserItem abcItem = new UserItem() { UserId = 2, EmployeeId = 2, FirstName = "ABC1", LastName = "XYZ1" };
            var retrunedValue = objUserBC.UpdateUser(abcItem);

            NUnit.Framework.Assert.AreEqual(true, retrunedValue);

        }
    }
}
