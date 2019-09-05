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
    public class TaskUnitTest
    {
       [Test]
        public void GetAllTaskTestMethod()
        {
            var taskData = new List<Task>
            {
               new Task{End_Date=DateTime.Now,Start_Date=DateTime.Now,Parent_ID=1,Priority=1,Project_ID=1,Status="true",Task1="Task1",Task_ID=1,Users=new List<User>
               {
                   new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task =new Task{ } , Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC1", Last_Name="XYZ",Project=null, Project_ID=2, Task = new Task{ }, Task_ID =2,User_ID=2 },
               } }
            }.AsQueryable();
            var userData = new List<User>
            {
                new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task =new Task{ } , Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC1", Last_Name="XYZ",Project=null, Project_ID=2, Task = new Task{ }, Task_ID =2,User_ID=2 },

            }.AsQueryable();
            var mockSet = new Mock<DbSet<Task>>();
            mockSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(taskData.Provider);
            mockSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(taskData.Expression);
            mockSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(taskData.ElementType);
            mockSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(taskData.GetEnumerator());

            var mockSet1 = new Mock<DbSet<User>>();
            mockSet1.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockSet1.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockSet1.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockSet1.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<Task>()).Returns(mockSet.Object);

            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);
            mockContext.Setup(m => m.Set<User>()).Returns(mockSet1.Object);
            mockContext.Setup(m => m.Users).Returns(mockSet1.Object);


            var objTaskBC = new TasksBC(mockContext.Object);
            TaskItem abcItem = new TaskItem()
            {
                Completed="C",
                EndDate=DateTime.Now,
                IsParentTask=true,
                StartDate=DateTime.Now,
                TaskName="Task1",
                Priority=1
            };
            var retrunedValue = objTaskBC.GetAllTasks();

            NUnit.Framework.Assert.AreEqual(1, retrunedValue.Count());

        }

      [Test]
        public void GetAllProjectTaskTestMethod()
        {
            var taskData = new List<Task>
            {
               new Task{End_Date=DateTime.Now,Start_Date=DateTime.Now,Parent_ID=1,Priority=1,Project_ID=1,Status="true",Task1="Task1",Task_ID=1,Users=new List<User>
               {
                   new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task =new Task{ } , Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC1", Last_Name="XYZ",Project=null, Project_ID=2, Task = new Task{ }, Task_ID =2,User_ID=2 },
               } }
            }.AsQueryable();
            
            var mockSet = new Mock<DbSet<Task>>();
            mockSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(taskData.Provider);
            mockSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(taskData.Expression);
            mockSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(taskData.ElementType);
            mockSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(taskData.GetEnumerator());

          

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<Task>()).Returns(mockSet.Object);

            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);
          

            var objTaskBC = new TasksBC(mockContext.Object);
            TaskItem abcItem = new TaskItem()
            {
                ProjectId = 1
            };
            var retrunedValue = objTaskBC.GetAllTaskForProject(abcItem.ProjectId);

            NUnit.Framework.Assert.AreEqual(1, retrunedValue.Count());

        }

        [Test] 
        public void UpdateTaskTestMethod()
        {
            var taskData = new List<Task>
            {
               new Task{End_Date=DateTime.Now,Start_Date=DateTime.Now,Parent_ID=1,Priority=1,Project_ID=1,Status="true",Task1="Task1",Task_ID=1,Users=new List<User>
               {
                   new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task =new Task{ } , Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC1", Last_Name="XYZ",Project=null, Project_ID=2, Task = new Task{ }, Task_ID =2,User_ID=2 },
               } }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Task>>();
            mockSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(taskData.Provider);
            mockSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(taskData.Expression);
            mockSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(taskData.ElementType);
            mockSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(taskData.GetEnumerator());
            int expected = 1;

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<Task>()).Returns(mockSet.Object);

            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(expected);

            var objTaskBC = new TasksBC(mockContext.Object);
            TaskItem abcItem = new TaskItem()
            {
                ParentTaskId = 12,
                TaskName = "NewTAsk",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Priority = 2,
                TaskId = 1,
            };
            var retrunedValue = objTaskBC.UpdateTask(abcItem);
            NUnit.Framework.Assert.AreEqual(true, retrunedValue);

        }
        [Test]
        public void RemoveTaskTestMethod()
        {
            int expected = 1;
           
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
            var mockSet = new Mock<DbSet<Task>>();
            mockSet.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(taskData.Provider);
            mockSet.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(taskData.Expression);
            mockSet.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(taskData.ElementType);
            mockSet.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(taskData.GetEnumerator());

            var mockSet1 = new Mock<DbSet<User>>();
            mockSet1.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userData.Provider);
            mockSet1.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userData.Expression);
            mockSet1.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userData.ElementType);
            mockSet1.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userData.GetEnumerator());

            var mockContext = new Mock<ProjectManagerDBEntities2>();
            mockContext.Setup(m => m.Set<Task>()).Returns(mockSet.Object);
            mockContext.Setup(m => m.Tasks).Returns(mockSet.Object);

            mockContext.Setup(m => m.Set<User>()).Returns(mockSet1.Object);
            mockContext.Setup(m => m.Users).Returns(mockSet1.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(expected);

            var objTaskBC = new TasksBC(mockContext.Object);
            TaskItem abcItem = new TaskItem()
            {
                ParentTaskId = 12,
                TaskName = "NewTAsk",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Priority = 2,
                TaskId = 1,
            };

            var retrunedValue = objTaskBC.RemoveTask(abcItem);

            NUnit.Framework.Assert.AreEqual(true, retrunedValue);

        }

      

       [Test]
        public void AddTaskTestMethod()
        {
            int expected = 1;
            var taskData = new List<Task> { new Task { Start_Date = DateTime.Now,Task1="NewTask",Task_ID=1}, new Task { Start_Date = DateTime.Now, Status = "true" } }.AsQueryable();
            var userData = new List<User>
            {
                new User { Employee_ID =1, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=1, Task = null, Task_ID =1,User_ID=1 },
                new User { Employee_ID =2, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=2, Task = null, Task_ID =2,User_ID=2 },
                new User { Employee_ID =3, First_Name="ABC", Last_Name="XYZ",Project=null, Project_ID=3, Task = null, Task_ID =3,User_ID=3 },
            }.AsQueryable();

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
          
            mockContext.Setup(m => m.Set<Task>()).Returns(mockSet1.Object);
            mockContext.Setup(m => m.Tasks).Returns(mockSet1.Object);
            mockContext.Setup(m => m.Set<User>()).Returns(mockSet2.Object);
            mockContext.Setup(m => m.Users).Returns(mockSet2.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(expected);

            var objProjectBC = new TasksBC(mockContext.Object);
            TaskItem abcItem = new TaskItem()
            {
                ParentTaskId = 12,
                TaskName = "NewTask",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Priority = 2,
                TaskId = 1,
                ManagerId=1
            };

            var retrunedValue = objProjectBC.AddNewTask(abcItem);

            NUnit.Framework.Assert.AreEqual(true, retrunedValue);

        }

       [Test]
        public void GetAllPriorityTaskTestMethod()
        {
            var taskData = new List<Task> { new Task { Start_Date = DateTime.Now ,Task_ID=1, Task1="ParentTask",Priority=1}, new Task { Start_Date = DateTime.Now, Status = "true" } }.AsQueryable();
            var priorityTaskData = new List<Parent_Task> { new Parent_Task { Parent_Task1="ParentTask"} }.AsQueryable();

            var mockSet1 = new Mock<DbSet<Task>>();
            mockSet1.As<IQueryable<Task>>().Setup(m => m.Provider).Returns(taskData.Provider);
            mockSet1.As<IQueryable<Task>>().Setup(m => m.Expression).Returns(taskData.Expression);
            mockSet1.As<IQueryable<Task>>().Setup(m => m.ElementType).Returns(taskData.ElementType);
            mockSet1.As<IQueryable<Task>>().Setup(m => m.GetEnumerator()).Returns(taskData.GetEnumerator());

            var mockSet2 = new Mock<DbSet<Parent_Task>>();
            mockSet2.As<IQueryable<Parent_Task>>().Setup(m => m.Provider).Returns(priorityTaskData.Provider);
            mockSet2.As<IQueryable<Parent_Task>>().Setup(m => m.Expression).Returns(priorityTaskData.Expression);
            mockSet2.As<IQueryable<Parent_Task>>().Setup(m => m.ElementType).Returns(priorityTaskData.ElementType);
            mockSet2.As<IQueryable<Parent_Task>>().Setup(m => m.GetEnumerator()).Returns(priorityTaskData.GetEnumerator());


            var mockContext = new Mock<ProjectManagerDBEntities2>();
          
            mockContext.Setup(m => m.Set<Task>()).Returns(mockSet1.Object);
            mockContext.Setup(m => m.Tasks).Returns(mockSet1.Object);
            mockContext.Setup(m => m.Set<Parent_Task>()).Returns(mockSet2.Object);
            mockContext.Setup(m => m.Parent_Task).Returns(mockSet2.Object);


            var objProjectBC = new TasksBC(mockContext.Object);
            TaskItem abcItem = new TaskItem()
            {
                ProjectId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                ProjectName = "",
                Priority = 1,
                ManagerId = 1,
                Completed = "C",
                TaskName="ParentTask"
            };

            var retrunedValue = objProjectBC.GetAllParentTasks();

            NUnit.Framework.Assert.GreaterOrEqual(retrunedValue.Count(),1 );

        }
    }
}
