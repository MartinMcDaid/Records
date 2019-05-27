using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Records;

namespace Records.Models
{
    public class RecordsContext : DbContext
    {
        public RecordsContext (DbContextOptions<RecordsContext> options)
            : base(options)
        {
        }

        public DbSet<Records.Vinyl> Vinyl { get; set; }
    }
}
