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

namespace Proiect__Bia.Pages.Adoptatori
{
    public class EditModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public EditModel(Proiect__Bia.Data.Proiect__BiaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Adoptator Adoptator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptator =  await _context.Adoptator.FirstOrDefaultAsync(m => m.ID == id);
            if (adoptator == null)
            {
                return NotFound();
            }
            Adoptator = adoptator;
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

            _context.Attach(Adoptator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptatorExists(Adoptator.ID))
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

        private bool AdoptatorExists(int id)
        {
            return _context.Adoptator.Any(e => e.ID == id);
        }
    }
}
