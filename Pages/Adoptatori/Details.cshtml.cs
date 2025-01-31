using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect__Bia.Data;
using Proiect__Bia.Models;

namespace Proiect__Bia.Pages.Adoptatori
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public DetailsModel(Proiect__Bia.Data.Proiect__BiaContext context)
        {
            _context = context;
        }

        public Adoptator Adoptator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptator = await _context.Adoptator.FirstOrDefaultAsync(m => m.ID == id);
            if (adoptator == null)
            {
                return NotFound();
            }
            else
            {
                Adoptator = adoptator;
            }
            return Page();
        }
    }
}
