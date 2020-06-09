using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User.Models
{
    public class UserManager
    {
        private Dictionary<string, User> session_users;
        public UserManager()
        {
            session_users = new Dictionary<string, User>();
        }
        public void Login(string sessionid, User user)
        {
            session_users.Add(sessionid, user);
        }
        public void Logout(string sessionid)
        {
            session_users.Remove(sessionid);
        }
        public User GetUser(string sessionid)
        {
            if (session_users.ContainsKey(sessionid))
            {
                return session_users[sessionid];
            }
            return null;
        }
    }
}
