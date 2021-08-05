using ComputerAPP.CORE.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerAPP.DATA.DbContexts
{
    public class ComputerAppDBContext : DbContext
    {
        public ComputerAppDBContext(DbContextOptions<ComputerAppDBContext> options) : base(options)
        {
        }

        public DbSet<Desktop> Desktops { get; set; }

        public DbSet<Notebook> NoteBooks { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
