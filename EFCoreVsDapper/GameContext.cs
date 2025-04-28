using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreVsDapper
{
    public class GameContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BISTECNB179;Database=GameDb;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<GameCharacter> GameCharacters { get; set; }
    }
}
