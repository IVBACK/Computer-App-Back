using ComputerAPP.CORE.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerAPP.SERVICE.IRepos
{
    interface IUserRepo
    {
        Task<bool> CheckEmailExists(string mail);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<bool> CreateUser(User user);
        Task<UserLoginResponse> GetUserByMail(UserLoginRequest userLoginRequest);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
