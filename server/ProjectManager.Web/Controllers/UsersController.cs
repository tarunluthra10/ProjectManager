using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.Web.BC;
using ProjectManager.Web.Models;

namespace ProjectManager.Web.Controllers
{
    public class UsersController : ApiController
    {
        UsersBC userbc = null;
        public UsersController()
        {
             userbc = new UsersBC();

        }

        // GET api/<controller>
        public List<UserItem> GetAllUsers()
        {
            return userbc.GetAllUsers();
        }

        public bool AddNewUser([FromBody]UserItem objUser)
        {
            return userbc.AddNewUser(objUser);
        }

        // PUT api/<controller>/5
        public bool UpdateUser([FromBody]UserItem objUser)
        {
            return userbc.UpdateUser(objUser);
        }

        // DELETE api/<controller>/5
        public bool RemoveUser(UserItem objUser)
        {
            return userbc.RemoveUser(objUser);
        }
    }
}