using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Server.Models
{
    public class BlockInGameContext : DbContext
    {
        public BlockInGameContext(DbContextOptions<BlockInGameContext> options) : base(options)
        {

        }

        public DbSet<BlockInGame> BlocksInGame { get; set; }
    }
}
