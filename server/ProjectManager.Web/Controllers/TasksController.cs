using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.Web.Models;
using ProjectManager.Web.BC;

namespace ProjectManager.Web.Controllers
{
    public class TasksController : ApiController
    {
        private ITasksBC refITasksBC;
        public TasksController()
        {
            refITasksBC = new TasksBC();
        }

        public TasksController(ITasksBC injectedTask)
        {
            refITasksBC = injectedTask;
        }


        // GET api/<controller>
        public List<TaskItem> GetAllPriorityTasks()
        {
            return refITasksBC.GetAllPriorityTasks();
        }

        // GET api/<controller>/5
        public List<TaskItem> GetAllTasks()
        {
            return refITasksBC.GetAllTasks();
        }

        public List<TaskItem> GetAllTaskForProject(string projectId)
        {
            return refITasksBC.GetAllTaskForProject(Convert.ToInt32(projectId));
        }

        // POST api/<controller>
        public bool AddNewTask([FromBody]TaskItem objTask)
        {
            return refITasksBC.AddNewTask(objTask);
        }

        // PUT api/<controller>/5
        public bool UpdateTask([FromBody]TaskItem objTask)
        {
            return refITasksBC.UpdateTask(objTask);
        }

        // DELETE api/<controller>/5
        public bool RemoveTask(TaskItem objTask)
        {
            return refITasksBC.RemoveTask(objTask);
        }



    }
}