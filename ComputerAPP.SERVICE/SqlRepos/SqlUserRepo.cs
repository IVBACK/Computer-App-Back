using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.IRepos;
using ComputerAPP.SERVICE.Security;
using ComputerAPP.SERVICE.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerAPP.SERVICE.SqlRepos
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly ComputerAppDBContext db_Context;

        private UserRegisterValidation userValidation = new UserRegisterValidation();

        public SqlUserRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            if (await db_Context.Users.FirstOrDefaultAsync(p => p.Email == email) != null)
                return false;

            return true;
        }
        
        public async Task<bool> CreateUser(User user)
        {           
            if (userValidation.IsNameValid(user.Name) && userValidation.IsEmailValid(user.Email))
            {
                await db_Context.Users.AddAsync(user);
                await db_Context.SaveChangesAsync();
                return true;
            }
            return false;           
        }

        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await db_Context.Users.FindAsync(id);
                db_Context.Users.Remove(user);
                await db_Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }          
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await db_Context.Users.ToListAsync();
        }

        public async Task<UserLoginResponse> GetUserByMail(UserLoginRequest userLoginRequest)
        {

            User user = await db_Context.Users.FirstOrDefaultAsync(p => p.Email == userLoginRequest.Email);
            
            if (user.Password == userLoginRequest.Password)
            {
                TokenHandler tokenHandler = new TokenHandler();
                UserLoginResponse userLoginResponse = new UserLoginResponse();
                userLoginResponse.Email = user.Email;
                userLoginResponse.Name = user.Name;
                userLoginResponse.UserId = Convert.ToString(user.UserId);
                userLoginResponse.Token = tokenHandler.GenerateToken(userLoginResponse.Email);
                return userLoginResponse;
            }
            else
            {
                return null;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            return await db_Context.Users.FirstOrDefaultAsync(p => p.UserId == id);
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                db_Context.Entry(user).State = EntityState.Modified;
                await db_Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw new ArgumentNullException(nameof(user));
            }
        }
    }
}
