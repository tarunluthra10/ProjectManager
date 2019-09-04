using ProjectManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Web.BC
{
    public class TasksBC : ITasksBC
    {
        ProjectManagerDBEntities2 entity = null;
        public TasksBC()
        {
            entity = new ProjectManagerDBEntities2();
        }

        public TasksBC(ProjectManagerDBEntities2 instanceProjectManagerDBEntities2)
        {
            entity = instanceProjectManagerDBEntities2;
        }


        public List<TaskItem> GetAllPriorityTasks()
        {
            List<TaskItem> taskItem = new List<TaskItem>();
            try
            {
                List<int> pTaskList = (from pTask in entity.Parent_Task
                                       select pTask.Parent_ID) != null ? (from pTask in entity.Parent_Task
                                                                select pTask.Parent_ID).ToList() : new List<int>();
                List<Task> taskObj = new List<Task>();

                taskObj = ((from task in entity.Tasks
                               select task) != null ? (from task in entity.Tasks
                                                       select task).ToList() : new List<Task>()).Where(m => pTaskList.Contains((int)m.Parent_ID)).ToList();
                
                taskItem = TaskMapping(taskObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taskItem;
        }



        // GET api/<controller>/5
        public List<TaskItem> GetAllTasks()
        {
            List<TaskItem> taskItem = new List<TaskItem>();
            try
            {
                List<Task> taskList = (from task in entity.Tasks
                                       select task) != null ? (from task in entity.Tasks
                                                               select task).ToList() : new List<Task>();
                taskItem = TaskMapping(taskList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taskItem;
        }

        private List<TaskItem> TaskMapping(List<Task> taskList)
        {
            List<TaskItem> taskItem = new List<TaskItem>();
            taskItem = taskList.Select(i =>
                 new TaskItem
                 {
                     Completed = i.Status,
                     EndDate = i.End_Date ?? DateTime.Now,
                     StartDate = i.Start_Date ?? DateTime.Now,
                     IsParentTask = IsParentTask(i.Task_ID),
                     TaskName = i.Task1,
                     Priority = (int)i.Priority,


                 }).ToList();
            return taskItem;
        }
        private List<Task> GetProjectTaskDetails(int projectId)
        {
            List<Task> taskObj = new List<Task>();
            try
            {
                taskObj = (from task in entity.Tasks
                           where task.Project_ID==(projectId)
                           select task) != null ? (from task in entity.Tasks
                                                   where task.Project_ID==(projectId)
                                                   select task).ToList() : new List<Task>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taskObj;
        }
        private Project GetProjectDetails(string projectName)
        {
            Project projectObj = new Project();
            try
            {
                var projectContext = entity.Set<Project>();
                projectObj = projectContext.FirstOrDefault(x => x.Project1.Equals(projectName));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return projectObj;
        }
        private bool IsParentTask(int taskId)
        {
            var taskContext = entity.Set<Parent_Task>();

            var std = taskContext != null ? taskContext.Where(x => x.Parent_ID == taskId).FirstOrDefault<Parent_Task>() : null;
            return std != null ? true : false;
        }
        // POST api/<controller>
        public bool AddNewTask(TaskItem objTask)
        {
            try
            {
                var taskContext = entity.Set<Task>();
                if(objTask.ParentTaskId > 0)
                {
                    taskContext.Add(new Task
                    {
                        Parent_ID = objTask.ParentTaskId,
                        Project_ID = objTask.ProjectId,
                        Task1 = objTask.TaskName,
                        Start_Date = objTask.StartDate,
                        End_Date = objTask.EndDate,
                        Status = "NC",
                        Priority = objTask.Priority
                    });

                }
                else
                {
                    taskContext.Add(new Task
                    {
                        Project_ID = objTask.ProjectId,
                        Task1 = objTask.TaskName,
                        Start_Date = objTask.StartDate,
                        End_Date = objTask.EndDate,
                        Status = "NC",
                        Priority = objTask.Priority
                    });
                }
                

                if (objTask.IsParentTask)
                {
                    var parentTaskContext = entity.Set<Parent_Task>();
                    parentTaskContext.Add(new Parent_Task
                    {
                        Parent_Task1 = objTask.TaskName
                    });
                }
                entity.SaveChanges();
                Task projectObj = GetTaskDetails(objTask.TaskName);
                var user = entity.Set<User>().FirstOrDefault(p => p.User_ID == objTask.ManagerId);
                user.Task_ID = projectObj.Task_ID;
            }
            catch (Exception ex)
            {
                return false;
            }

            return entity.SaveChanges() == 1;
        }
        private Task GetTaskDetails(string taskName)
        {
            Task taskObj = new Task();
            try
            {
                taskObj = (from task in entity.Tasks
                           where task.Task1.Equals(taskName)
                           select task).FirstOrDefault() != null ? (from task in entity.Tasks
                                                                    select task).FirstOrDefault() : new Task();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return taskObj;
        }
        // PUT api/<controller>/5
        public bool UpdateTask(TaskItem objTask)
        {
            try
            {
                var taskContext = entity.Set<Task>();
                var std = taskContext.Where(x => x.Task_ID == objTask.TaskId).First<Task>();
                std.Parent_ID = objTask.ParentTaskId;

                std.Task1 = objTask.TaskName;
                std.Start_Date = objTask.StartDate;
                std.End_Date = objTask.EndDate;
                std.Priority = objTask.Priority;
            }
            catch (Exception ex)
            {
                return false;
            }

            return entity.SaveChanges() == 1;
        }

        // DELETE api/<controller>/5
        public bool RemoveTask(TaskItem objTask)
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
                throw ex;
            }
            return entity.SaveChanges() == 1;
        }

        public List<TaskItem> GetAllTaskForProject(int ProjectId)
        {
            List<TaskItem> listTask = new List<TaskItem>();
            try
            {
                List<Task> taskLst = GetProjectTaskDetails(ProjectId);
                listTask = TaskMapping(taskLst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listTask;
        }
    }
}