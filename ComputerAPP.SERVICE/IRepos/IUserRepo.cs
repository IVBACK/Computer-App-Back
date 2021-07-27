using ComputerAPP.CORE.Models;
using System.Collections.Generic;

namespace ComputerAPP.SERVICE.IRepos
{
    interface IUserRepo
    {
        void SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(int id, User user);
        void DeleteUser(int id);
    }
}
