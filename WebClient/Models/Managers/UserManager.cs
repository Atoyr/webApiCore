using System;
using System.Linq;
using WebClient.Interfaces;
using static WebClient.Models.Hash;
using WebClient.Models.Database;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace WebClient.Models.Managers
{
    public class UserManager
    {
        private Context _context;
        private const int ITERATION_COUNT = 1000;
        private const int NUM_BYTES = 256/8;
        private const KeyDerivationPrf KEY_DERIVATION_PRF = KeyDerivationPrf.HMACSHA1;

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
            var user = _context.Users.FirstOrDefault(x => x.Mail == mail && x.Hash == GetHash(password, x.Salt, KEY_DERIVATION_PRF, ITERATION_COUNT, NUM_BYTES));
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
                var hashed = GetHash(password, salt, KEY_DERIVATION_PRF, ITERATION_COUNT, NUM_BYTES);
                var user = new User{
                    Id = new Guid(),
                    CreateUser = createUser,
                    CreateDateTime = DateTime.UtcNow,
                    UpdateUser = createUser,
                    UpdateDateTime = DateTime.UtcNow,
                    Code = code,
                    Name = name,
                    Mail = mail,
                    Hash = hashed,
                    Salt = salt,
                    Icon = icon
                };
                _context.Users.Add(user);
                return true;
            }

            return false;
        }

        private UserInfo ConvertUserToUserInfo(User user)
        {
            return user == null ? default(UserInfo) : new UserInfo{ UserId = user.Id, UserName = user.Name ,Icon = user.Icon};
        }
    }
}