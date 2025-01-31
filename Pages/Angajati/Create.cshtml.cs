using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect__Bia.Data;
using Proiect__Bia.Models;

namespace Proiect__Bia.Pages.Angajati
{
    public class CreateModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public CreateModel(Proiect__Bia.Data.Proiect__BiaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CentruID"] = new SelectList(_context.Set<Locatie>(), "ID", "NumeCentru");
            return Page();
        }

        [BindProperty]
        public Angajat Angajat { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Angajat.Add(Angajat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
