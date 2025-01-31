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

namespace Proiect__Bia.Pages.Adoptii
{
    public class EditModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public EditModel(Proiect__Bia.Data.Proiect__BiaContext context)
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

            var adoptie =  await _context.Adoptie.FirstOrDefaultAsync(m => m.ID == id);
            if (adoptie == null)
            {
                return NotFound();
            }
            Adoptie = adoptie;
           ViewData["AdoptatorID"] = new SelectList(_context.Adoptator, "ID", "FullName");
           ViewData["CopilID"] = new SelectList(_context.Copil, "ID", "FullName");
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

            _context.Attach(Adoptie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptieExists(Adoptie.ID))
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

        private bool AdoptieExists(int id)
        {
            return _context.Adoptie.Any(e => e.ID == id);
        }
    }
}
