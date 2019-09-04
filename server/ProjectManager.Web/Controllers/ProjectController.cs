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
    public class ProjectController : ApiController
    {
        private IProjectBC refProjectBc;
        public ProjectController()
        {
            refProjectBc = new ProjectBC();
        }

        // GET api/<controller>
        public List<ProjectItem> GetAllProjects()
        {
            return refProjectBc.GetAllProjects();
        }

        public bool AddNewProject([FromBody]ProjectItem objProject)
        {
            return refProjectBc.AddNewProject(objProject);
        }

        // PUT api/<controller>/5
        public bool UpdateProject([FromBody]ProjectItem objProject)
        {
            return refProjectBc.UpdateProject(objProject);
        }

        // DELETE api/<controller>/5
        public bool RemoveProject(ProjectItem objProject)
        {
            return refProjectBc.RemoveProject(objProject);
        }
    }
}