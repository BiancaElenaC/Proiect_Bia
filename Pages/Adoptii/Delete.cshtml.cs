using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect__Bia.Data;
using Proiect__Bia.Models;

namespace Proiect__Bia.Pages.Adoptii
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public DeleteModel(Proiect__Bia.Data.Proiect__BiaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Adoptie Adoptie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptie = await _context.Adoptie.FirstOrDefaultAsync(m => m.ID == id);

            if (adoptie == null)
            {
                return NotFound();
            }
            else
            {
                Adoptie = adoptie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptie = await _context.Adoptie.FindAsync(id);
            if (adoptie != null)
            {
                Adoptie = adoptie;
                _context.Adoptie.Remove(Adoptie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
