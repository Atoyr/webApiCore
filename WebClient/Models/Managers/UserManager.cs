using System;
using System.Linq;
using WebClient.Interfaces;
using static WebClient.Models.Hash;
using WebClient.Models.Database;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace WebClient.Models.Managers
{
    public class UserManager : IUserManager
    {
        private Context _context;
        private const int ITERATION_COUNT = 1000;
        private const int NUM_BYTES = 256/8;
        private const KeyDerivationPrf KEY_DERIVATION_PRF = KeyDerivationPrf.HMACSHA1;

        public UserManager(Context context)
        {
            _context = context;
        }

        public UserInfo GetUser(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return ConvertUserToUserInfo(user);
        }

        public UserInfo Find(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email );
            user = user?.Hash == GetHash(password, user.Salt, KEY_DERIVATION_PRF, ITERATION_COUNT, NUM_BYTES) ? user: null;
            return ConvertUserToUserInfo(user);
        }

        public byte[] GetUserIcon(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id)?.Icon;
        }

        public bool CreateUser(
            string code,
            string name,
            string email,
            string password,
            byte[] icon,
            string createUser)
        {
            if (!_context.Users.Any(x => x.Email == email))
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
                    Email = email,
                    Hash = hashed,
                    Salt = salt,
                    Icon = icon
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        private UserInfo ConvertUserToUserInfo(User user)
        {
            return user == null ? default(UserInfo) : new UserInfo{ Id = user.Id, Name = user.Name };
        }
    }
}