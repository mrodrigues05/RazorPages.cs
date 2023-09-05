using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.cs.Data;
using RazorPages.cs.Modelo;

namespace RazorPages.cs.Pages.Filmes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPages.cs.Data.RazorPagescsContext _context;

        public IndexModel(RazorPages.cs.Data.RazorPagescsContext context)
        {
            _context = context;
        }

        public IList<Filme> Filme { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Filme != null)
            {
                Filme = await _context.Filme.ToListAsync();
            }
        }
    }
}
