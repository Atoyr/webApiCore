using System;
using System.Linq;
using WebClient.Interfaces;
using WebClient.Models.Database;

namespace WebClient.Models.Sample
{
    public class UserManager
    {
        private Context _context;

        public UserManager(Context context)
        {
            _context = context;
        }

        public User GetUser()
        {
            return _context.Users.FirstOrDefault();
        }

        public bool CreateUser()
        {
            return false;
        }
    }
}