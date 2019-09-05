using ProjectManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Web.BC
{
    public interface ITasksBC
    {

        List<TaskItem> GetAllParentTasks();

        List<TaskItem> GetAllTasks();

        bool AddNewTask(TaskItem objTask);
        bool UpdateTask(TaskItem objTask);
        bool RemoveTask(TaskItem objTask);

        List<TaskItem> GetAllTaskForProject(int objProjectItem);

    }
}