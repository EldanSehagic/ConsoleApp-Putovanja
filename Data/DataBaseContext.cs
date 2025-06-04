using Microsoft.EntityFrameworkCore;
using Zadatak.Models;


namespace Zadatak.Data
{
    internal class DataBaseContext:DbContext
    {
        public DbSet<Putovanje> Putovanja { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var databasePath = Path.Combine(AppContext.BaseDirectory, "Putovanjammm.db");
            optionsBuilder.UseSqlite($"Data Source = {databasePath}");
        }
    }
}
