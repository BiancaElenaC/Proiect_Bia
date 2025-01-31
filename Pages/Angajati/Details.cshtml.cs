using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect__Bia.Data;
using Proiect__Bia.Models;

namespace Proiect__Bia.Pages.Angajati
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public DetailsModel(Proiect__Bia.Data.Proiect__BiaContext context)
        {
            _context = context;
        }

        public Angajat Angajat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var angajat = await _context.Angajat.FirstOrDefaultAsync(m => m.ID == id);
            if (angajat == null)
            {
                return NotFound();
            }
            else
            {
                Angajat = angajat;
            }
            return Page();
        }
    }
}
