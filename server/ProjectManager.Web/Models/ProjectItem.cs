using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Web.Models
{
    public class ProjectItem
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public int ManagerId { get; set; }

        public string ManagerName { get; set; }

        public int Priority { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Completed { get; set; }

        public int NumberOfTasks { get; set; }
    }
}