using ProjectManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Web.BC
{
    public interface IProjectBC
    {
        List<ProjectItem> GetAllProjects();


        bool AddNewProject(ProjectItem objProject);


        bool UpdateProject(ProjectItem objProject);


        bool RemoveProject(ProjectItem objProject);
        
    }
}