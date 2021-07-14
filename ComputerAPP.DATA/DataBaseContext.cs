using ComputerAPP.CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerAPP.DATA
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<NoteBook> NoteBooks { get; set; }
    }
}
