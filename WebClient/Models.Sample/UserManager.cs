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

        public UserInfo GetUser(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            return user == null ? default(UserInfo) : new UserInfo{ UserId = user.Id, UserName = user.Name ,Icon = user.Icon};
        }

        public bool CreateUser()
        {
            return false;
        }
    }
}