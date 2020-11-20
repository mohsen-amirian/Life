using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeService.Models
{
    public class LifeContext : DbContext
    {
        public LifeContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Word> Words { get; set; }
    }
}
