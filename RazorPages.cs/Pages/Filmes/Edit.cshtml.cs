﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPages.cs.Data;
using RazorPages.cs.Modelo;

namespace RazorPages.cs.Pages.Filmes
{
    public class EditModel : PageModel
    {
        private readonly RazorPages.cs.Data.RazorPagescsContext _context;

        public EditModel(RazorPages.cs.Data.RazorPagescsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Filme Filme { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Filme == null)
            {
                return NotFound();
            }

            var filme =  await _context.Filme.FirstOrDefaultAsync(m => m.ID == id);
            if (filme == null)
            {
                return NotFound();
            }
            Filme = filme;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Filme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmeExists(Filme.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FilmeExists(int id)
        {
          return (_context.Filme?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
