using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect__Bia.Data;
using Proiect__Bia.Models;

namespace Proiect__Bia.Pages.Copii
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public DeleteModel(Proiect__Bia.Data.Proiect__BiaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Copil Copil { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copil = await _context.Copil.FirstOrDefaultAsync(m => m.ID == id);

            if (copil == null)
            {
                return NotFound();
            }
            else
            {
                Copil = copil;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copil = await _context.Copil.FindAsync(id);
            if (copil != null)
            {
                Copil = copil;
                _context.Copil.Remove(Copil);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
