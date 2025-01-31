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
    public class DetailsModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public DetailsModel(Proiect__Bia.Data.Proiect__BiaContext context)
        {
            _context = context;
        }

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
    }
}
