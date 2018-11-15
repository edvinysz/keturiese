using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace serveris.Models
{
    public class GameInfoContext : DbContext
    {
        public GameInfoContext(DbContextOptions<GameInfoContext> options) : base(options)
        {

        }

        public DbSet<GameInfo> GameInfos { get; set; }
    }
}
