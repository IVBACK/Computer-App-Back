using ComputerAPP.CORE.Models;
using ComputerAPP.DATA.DbContexts;
using ComputerAPP.SERVICE.IRepos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerAPP.SERVICE.SqlRepos
{
    public class SqlUserRepo : IUserRepo
    {
        private readonly ComputerAppDBContext db_Context;

        public SqlUserRepo(ComputerAppDBContext db)
        {
            this.db_Context = db;
        }
        
        public void CreateUser(User user)
        {
            db_Context.Users.Add(user);
        }

        public void DeleteUser(int id)
        {
            var user = db_Context.Users.Find(id);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            db_Context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db_Context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return db_Context.Users.FirstOrDefault(p => p.UserId == id);
        }

        public void SaveChanges()
        {
            db_Context.SaveChanges();
        }

        public void UpdateUser(int id, User user)
        {
            db_Context.Entry(user).State = EntityState.Modified;
            SaveChanges();
        }
    }
}
