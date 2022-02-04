#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcOmegaSport.Models;

namespace MvcOmegaSport.Data
{
    public class MvcOmegaSportContext : DbContext
    {
        public MvcOmegaSportContext (DbContextOptions<MvcOmegaSportContext> options)
            : base(options)
        {
        }

        public DbSet<MvcOmegaSport.Models.Jersey> Jersey { get; set; }
    }
}
