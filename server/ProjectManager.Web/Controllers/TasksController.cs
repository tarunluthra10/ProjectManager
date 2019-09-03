using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.Web.Models;

namespace ProjectManager.Web.Controllers
{
    public class TasksController : ApiController
    {
        // GET api/<controller>
        public List<TaskItem> GetAllPriorityTasks()
        {
            return new List<TaskItem>();
        }

        // GET api/<controller>/5
        public List<TaskItem> GetAllTasks()
        {
            return new List<TaskItem>();
        }

        // POST api/<controller>
        public bool AddNewTask([FromBody]TaskItem objTask)
        {
            return true;
        }

        // PUT api/<controller>/5
        public bool UpdateTask([FromBody]TaskItem objTask)
        {
            return true;
        }

        // DELETE api/<controller>/5
        public void RemoveTask(TaskItem objTask)
        {

        }
    }
}