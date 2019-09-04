using ProjectManager.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManager.Web.BC
{
    public class UsersBC : IUsersBC
    {
        ProjectManagerDBEntities2 entity = null;
        public UsersBC()
        {
            entity = new ProjectManagerDBEntities2();
        }

        public List<UserItem> GetAllUsers()
        {
            List<UserItem> userItem = new List<UserItem>();
            try
            {
                List<User> userList = (from user in entity.Users
                                       select user) != null ? (from user in entity.Users
                                                               select user).ToList() : new List<User>();
                userItem = userList.Select(i =>
                   new UserItem
                   {
                       EmployeeId = i.Employee_ID ?? 0,
                       FirstName = i.First_Name,
                       LastName = i.Last_Name,
                       UserId = i.User_ID
                   }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return userItem;
        }

        public bool AddNewUser(UserItem objUser)
        {
            try
            {
                var userContext = entity.Set<User>();
                userContext.Add(new User
                {
                    Employee_ID = objUser.EmployeeId,
                    First_Name = objUser.FirstName,
                    Last_Name = objUser.LastName,
                });

            }
            catch (Exception ex)
            {
                return false;
            }

            return entity.SaveChanges() == 1;
        }


        public bool UpdateUser(UserItem objUser)
        {
            try
            {
                var userContext = entity.Set<User>();
                var std = userContext.Where(x => x.User_ID == objUser.UserId).First<User>();
                std.Employee_ID = objUser.EmployeeId;
                std.First_Name = objUser.FirstName;
                std.Last_Name = objUser.LastName;

            }
            catch (Exception ex)
            {
                return false;
            }

            return entity.SaveChanges() == 1;
        }


        public bool RemoveUser(UserItem objUser)
        {
            try
            {
                var userContext = entity.Set<User>();

                var std = userContext.Where(x => x.User_ID == objUser.UserId).First<User>();
                userContext.Remove(std);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return entity.SaveChanges() == 1;
        }
    }
}