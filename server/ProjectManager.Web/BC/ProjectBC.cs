using ProjectManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Web.BC
{
    public class ProjectBC
    {
        ProjectManagerDBEntities2 entity = null;
        public ProjectBC()
        {
            entity = new ProjectManagerDBEntities2();
        }

        // GET api/<controller>
        public List<ProjectItem> GetAllProjects()
        {
            List<ProjectItem> projectItem = new List<ProjectItem>();
            try
            {
                List<Project> projectList = (from project in entity.Projects
                                             select project) != null ? (from project in entity.Projects
                                                                        select project).ToList() : new List<Project>();
                projectItem = projectList.Select(i =>
                   new ProjectItem
                   {
                       //  Completed=i, ?????????????????????????????????????????check all task status
                       EndDate = i.End_Date ?? DateTime.Now,
                       ManagerId = GetManagerDetails(i.Project_ID).User_ID,
                       ManagerName = String.Format(" ", GetManagerDetails(i.Project_ID).First_Name, GetManagerDetails(i.Project_ID).Last_Name),
                       //Priority=i.Priority, change data type in db
                       ProjectId = i.Project_ID,
                       ProjectName = i.Project1,
                       StartDate = i.Start_Date ?? DateTime.Now,
                       NumberOfTasks = GetTasks(i.Project_ID).Count()
                   }).ToList();
            }
            catch (Exception ex)
            {

            }
            return projectItem;
        }

        private List<Task> GetTasks(int ProjectId)
        {
            var projectContext = entity.Set<Project>();
            List<Task> task = entity.Set<Task>().Where(p => p.Parent_ID == ProjectId).ToList();
            return task;
        }
        private User GetManagerDetails(int ProjectId)
        {
            var projectContext = entity.Set<Project>();
            var user = entity.Set<User>().FirstOrDefault(p => p.Project_ID == ProjectId);
            return user;
        }

        private Project GetProjectDetails(string projectName)
        {
            Project projectObj = new Project();
            try
            {
                projectObj = (from project in entity.Projects
                              where project.Project1.Equals(projectName)
                              select project).FirstOrDefault() != null ? (from project in entity.Projects
                                                                          select project).FirstOrDefault() : new Project();
            }
            catch (Exception ex)
            {

            }
            return projectObj;
        }
        public bool AddNewTask(ProjectItem objProject)
        {
            try
            {
                var projectContext = entity.Set<Project>();
                projectContext.Add(new Project
                {
                    Start_Date = objProject.StartDate,
                    End_Date = objProject.EndDate,
                    Project1 = objProject.ProjectName,
                    // Priority= objProject.Priority,
                });
                entity.SaveChanges();
                Project projectObj = GetProjectDetails(objProject.ProjectName);
                var user = entity.Set<User>().FirstOrDefault(p => p.User_ID == objProject.ManagerId);
                user.Project_ID = projectObj.Project_ID;
                entity.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        // PUT api/<controller>/5
        public bool UpdateTask(ProjectItem objProject)
        {
            try
            {
                var projectContext = entity.Set<Project>();

                var std = projectContext.Where(x => x.Project_ID == objProject.ProjectId).First<Project>();
                std.Start_Date = objProject.StartDate;
                std.End_Date = objProject.EndDate;
                std.Project1 = objProject.ProjectName;
                // Priority= objProject.Priority,
                var user = entity.Set<User>().FirstOrDefault(p => p.Project_ID == objProject.ProjectId);
                user.Project_ID = user.User_ID != objProject.ManagerId ? 0 : objProject.ProjectId;
                var updatedManager = entity.Set<User>().FirstOrDefault(p => p.User_ID == objProject.ManagerId);
                user.Project_ID = objProject.ProjectId;
                entity.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        // DELETE api/<controller>/5
        public void RemoveTask(ProjectItem objProject)
        {
            try
            {
                var projectContext = entity.Set<Project>();

                var std = projectContext.Where(x => x.Project_ID == objProject.ProjectId).First<Project>();
                var user = entity.Set<User>().FirstOrDefault(p => p.User_ID == objProject.ManagerId);
                user.Project_ID = 0;
                projectContext.Remove(std);
            }
            catch (Exception ex)
            {

            }
            entity.SaveChanges();
        }
    }
}