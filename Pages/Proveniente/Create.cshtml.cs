using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect__Bia.Data;
using Proiect__Bia.Models;

namespace Proiect__Bia.Pages.Proveniente
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
            return Page();
        }

        [BindProperty]
        public Provenienta Provenienta { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Provenienta.Add(Provenienta);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
