using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        bool ValidateUser(string userName,string password);
        List<Users> GetUsers();
        void AddUser();
        int GetUserIdByName(string userName);
    }
}
