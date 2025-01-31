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

namespace Proiect__Bia.Pages.Proveniente
{
    public class EditModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public EditModel(Proiect__Bia.Data.Proiect__BiaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Provenienta Provenienta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provenienta =  await _context.Provenienta.FirstOrDefaultAsync(m => m.ID == id);
            if (provenienta == null)
            {
                return NotFound();
            }
            Provenienta = provenienta;
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

            _context.Attach(Provenienta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvenientaExists(Provenienta.ID))
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

        private bool ProvenientaExists(int id)
        {
            return _context.Provenienta.Any(e => e.ID == id);
        }
    }
}
