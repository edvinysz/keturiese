using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace serveris.Models
{
    public class BlockInGameContext : DbContext
    {
        public BlockInGameContext(DbContextOptions<BlockInGameContext> options) : base(options)
        {

        }

        public DbSet<BlockInGame> BlocksInGame { get; set; }
    }
}
