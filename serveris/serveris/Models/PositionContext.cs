using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace serveris.Models
{
    public class PositionContext : DbContext
    {
        public PositionContext(DbContextOptions<PositionContext> options) : base(options)
        {

        }

        public DbSet<Position> Positions { get; set; }
    }
}
