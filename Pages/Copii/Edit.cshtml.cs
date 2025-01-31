using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect__Bia.Data;
using Proiect__Bia.Models;

namespace Proiect__Bia.Pages.Copii
{
    public class EditModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public EditModel(Proiect__Bia.Data.Proiect__BiaContext context)
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

            var copil =  await _context.Copil.FirstOrDefaultAsync(m => m.ID == id);
            if (copil == null)
            {
                return NotFound();
            }
            Copil = copil;
           ViewData["LocatieID"] = new SelectList(_context.Set<Locatie>(), "ID", "NumeCentru");
           ViewData["ProvenientaID"] = new SelectList(_context.Set<Provenienta>(), "ID", "TipProvenienta");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Copil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CopilExists(Copil.ID))
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

        private bool CopilExists(int id)
        {
            return _context.Copil.Any(e => e.ID == id);
        }
    }
}
