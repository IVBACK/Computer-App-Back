using ComputerAPP.CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerAPP.DATA.DbContexts
{
    public class ComputerAppDbContext : DbContext
    {
        public ComputerAppDbContext(DbContextOptions<ComputerAppDbContext> options) : base(options)
        {
        }

        public DbSet<Desktop> Desktops { get; set; }

        public DbSet<NoteBook> NoteBooks { get; set; }
    }
}
