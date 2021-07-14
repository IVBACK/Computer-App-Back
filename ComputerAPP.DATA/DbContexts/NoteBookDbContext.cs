using ComputerAPP.CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerAPP.DATA
{
    public class NoteBookDbContext : DbContext
    {
        public NoteBookDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<NoteBook> NoteBooks { get; set; }
    }
}
