using ProjectManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Web.BC
{
    public class TasksBC
    {
        ProjectManagerDBEntities2 entity = null;
        public TasksBC()
        {
            entity = new ProjectManagerDBEntities2();
        }
        public List<TaskItem> GetAllPriorityTasks()
        {
            return new List<TaskItem>();
        }

        // GET api/<controller>/5
        public List<TaskItem> GetAllTasks()
        {
            List<TaskItem> taskItem = new List<TaskItem>();
            try
            {
                List<Task> projectList = (from task in entity.Tasks
                                          select task) != null ? (from task in entity.Tasks
                                                                  select task).ToList() : new List<Task>();
                taskItem = projectList.Select(i =>
                   new TaskItem
                   {
                       //Completed=i. update db add column status
                       EndDate = i.End_Date ?? DateTime.Now,
                       StartDate = i.Start_Date ?? DateTime.Now,
                       IsParentTask = IsParentTask(i.Task_ID),
                       ProjectName = GetProjectDetails(i.Task_ID).Project1,
                       TaskName = i.Task1,
                       // Priority = i.Priority, Update datatype in db


                   }).ToList();
            }
            catch (Exception ex)
            {

            }
            return taskItem;
        }
        private Project GetProjectDetails(int taskId)
        {
            Project projectObj = new Project();
            try
            {
                var projectContext = entity.Set<Project>();
                //projectObj = projectContext.Where(x=>x.Tasks.Where(y=>y.Task_ID== taskId));

            }
            catch (Exception ex)
            {

            }
            return projectObj;
        }
        private bool IsParentTask(int taskId)
        {
            var taskContext = entity.Set<Parent_Task>();

            var std = taskContext.Where(x => x.Parent_ID == taskId).First<Parent_Task>();
            return std != null ? true : false;
        }
        // POST api/<controller>
        public bool AddNewTask(TaskItem objTask)
        {
            try
            {
                var taskContext = entity.Set<Task>();
                taskContext.Add(new Task
                {
                    Parent_ID = objTask.ParentTaskId,
                    Project_ID = objTask.ProjectId,
                    Task1 = objTask.TaskName,
                    Start_Date = objTask.StartDate,
                    End_Date = objTask.EndDate
                });

                entity.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        // PUT api/<controller>/5
        public bool UpdateTask(TaskItem objTask)
        {
            try
            {
                var taskContext = entity.Set<Task>();
                var std = taskContext.Where(x => x.Task_ID == objTask.TaskId).First<Task>();

                entity.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        // DELETE api/<controller>/5
        public void RemoveTask(TaskItem objTask)
        {
            try
            {
                var taskContext = entity.Set<Task>();

                var std = taskContext.Where(x => x.Task_ID == objTask.TaskId).First<Task>();
                var user = entity.Set<User>().FirstOrDefault(p => p.Task_ID == objTask.TaskId);
                user.Task_ID = 0;
                taskContext.Remove(std);
            }
            catch (Exception ex)
            {

            }
            entity.SaveChanges();
        }
    }
}