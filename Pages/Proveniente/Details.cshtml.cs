using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect__Bia.Data;
using Proiect__Bia.Models;

namespace Proiect__Bia.Pages.Proveniente
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public DetailsModel(Proiect__Bia.Data.Proiect__BiaContext context)
        {
            _context = context;
        }

        public Provenienta Provenienta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var provenienta = await _context.Provenienta.FirstOrDefaultAsync(m => m.ID == id);
            if (provenienta == null)
            {
                return NotFound();
            }
            else
            {
                Provenienta = provenienta;
            }
            return Page();
        }
    }
}
