using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.cs.Data;
using RazorPages.cs.Modelo;

namespace RazorPages.cs.Pages.Filmes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPages.cs.Data.RazorPagescsContext _context;

        //injeção de dependência//
        public IndexModel(RazorPages.cs.Data.RazorPagescsContext context)
        {
            _context = context;
        }

        //Carrega o objeto filme que depois é apresentado em tela//
        public IList<Filme> Filme { get; set; } = default!;


        //Implementando o metodo de busca//

        [BindProperty(SupportsGet = true)]
        public string TermoBusca { get; set; }


        [BindProperty(SupportsGet = true)]
        public string FilmeGenero { get; set; }


        public SelectList Generos { get; set; }

        public async Task OnGetAsync()
        {
            var filmes = from m in _context.Filme
                         select m;

            if (!string.IsNullOrWhiteSpace(TermoBusca))
            {
                filmes = filmes.Where(f => f.Titulo.Contains(TermoBusca));
            }

            Filme = await filmes.ToListAsync();
        }
    }
}
