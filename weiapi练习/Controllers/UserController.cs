using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using weiapi练习.Models;
using Newtonsoft.Json;


namespace weiapi练习.Controllers
{
    public class UserController : ApiController
    {
        /// <summary>
        /// User Data List
        /// </summary>
        private readonly List<Users> _userList = new List<Users>
        {
            new Users {UserID=1,UserName="Supperman",UserEmail="Supperman@cnblogs.com" },
            new Users {UserID=2,UserName="Spiderman",UserEmail="Spiderman@cnblogs.com" },
            new Users {UserID=3,UserName="Batman",UserEmail="Batman@cnblogs.com" }
        };

        //Get api/users
        public IEnumerable<Users> Get()
        {
            return _userList;
        }

        //Get api/Users/5
        public Users GetUserByID (int id)
        {
            var user = _userList.FirstOrDefault(p => p.UserID == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound); 
            }
            return user;
        }

        //GET api/Users/?username==xx
        public IEnumerable<Users> GetUserByName (string userName)
        {
            return _userList.Where(p => string.Equals(p.UserName, userName, StringComparison.OrdinalIgnoreCase)||p.UserName.ToLower().Contains(userName.ToLower()));
        }
        
        public IEnumerable<Users> GetUserByNameAndID(string userName,int userID)
        {     
            return _userList.Where(p => (string.Equals(p.UserName, userName, StringComparison.OrdinalIgnoreCase)||p.UserName.ToLower().Contains(userName.ToLower()))&&p.UserID==userID);
        }
        //POST api/Users/Users Entity Json
        public Users Add(int UserID,string UserName,string UserEmail)
        {
            Users users = new Users();
            users.UserID = UserID;
            users.UserName = UserName;
            users.UserEmail = UserEmail;
            if (User == null)
            {
                throw new HttpRequestException();
            }
            _userList.Add(users);
            return users;
        }
    }
}
