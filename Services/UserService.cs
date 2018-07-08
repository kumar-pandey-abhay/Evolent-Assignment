using Common;
using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private static Repository<Users> _userRepo;

        static UserService() => _userRepo = new Repository<Users>(new ApplicationDbContext());

        public bool ValidateUser(string userName, string password)
        {
            return _userRepo.GetAll().Any(u => u.UserName.Equals(userName) && u.Password.Equals(password));
        }
        public List<Users> GetUsers()
        {
            return _userRepo.GetAll().ToList();
        }
        public void AddUser()
        {
            var user = new Users()
            {
                UserName = "abhay",
                Password = "password",
                CreatedByUserId = 1,
                CreatedDate = DateTime.Now,
            };
            _userRepo.Insert(user);
        }

        public int GetUserIdByName(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                var user = _userRepo.GetAll().FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
                return user.Id;
            }
            throw new UnauthorizedAccessException();
        }
    }
}
