using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.Web.Models;

namespace ProjectManager.Web.Controllers
{
    public class ProjectController : ApiController
    {
        // GET api/<controller>
        public List<ProjectItem> GetAllProjects()
        {
            return new List<ProjectItem>();
        }

        public bool AddNewTask([FromBody]ProjectItem objProject)
        {
            return true;
        }

        // PUT api/<controller>/5
        public bool UpdateTask([FromBody]ProjectItem objProject)
        {
            return true;
        }

        // DELETE api/<controller>/5
        public void RemoveTask(ProjectItem objProject)
        {

        }
    }
}