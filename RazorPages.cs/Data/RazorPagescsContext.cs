using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPages.cs.Modelo;

namespace RazorPages.cs.Data
{
    public class RazorPagescsContext : DbContext
    {
        public RazorPagescsContext (DbContextOptions<RazorPagescsContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPages.cs.Modelo.Filme> Filme { get; set; } = default!;
    }
}
