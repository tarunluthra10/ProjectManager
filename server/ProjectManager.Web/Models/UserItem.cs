using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Web.Models
{
    public class UserItem
    {
        public int UserId { get; set; }

        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}