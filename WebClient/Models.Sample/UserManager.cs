using System;
using System.Linq;
using WebClient.Interfaces;
using static WebClient.Models.Hash;
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
            return ConvertUserToUserInfo(user);
        }

        public UserInfo Find(string mail, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Mail == mail && x.Hash == GetHash(password, x.Salt));
            return ConvertUserToUserInfo(user);
        }

        public bool CreateUser(
            string code,
            string name,
            string mail,
            string password,
            byte[] icon,
            string createUser)
        {
            if (!_context.Users.Any(x => x.Mail == mail))
            {
                var salt = GenerateSalt();
                var hashed = GetHash(password,salt);
                var user = new User{
                    Id = new Guid(),
                    CreateUser = createUser,
                    CreateDateTime = DateTime.UtcNow,
                    UpdateUser = createUser,
                    UpdateDateTime = DateTime.UtcNow,
                    Core = code,
                    Name = name,
                    Mail = mail,
                    Password = hashed,
                    Salt = salt,
                    Icon = icon
                }
                _context.Users.Add(user);
                return true;
            }

            return false;
        }

        private UserInfo ConvertUserToUserInfo(User usre)
        {
            return user == null ? default(UserInfo) : new UserInfo{ UserId = user.Id, UserName = user.Name ,Icon = user.Icon};
        }
    }
}