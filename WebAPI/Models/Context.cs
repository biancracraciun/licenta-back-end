using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class Context: DbContext
    {
        public DbSet<Solax> Solax { get; set; }
        public DbSet<User> Users { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder  optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=DESKTOP-BAV7B3N;initial catalog=SolaxDB;trusted_connection=true");
        }

    }
}
