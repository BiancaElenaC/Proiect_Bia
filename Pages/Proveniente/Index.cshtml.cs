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
    public class IndexModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public IndexModel(Proiect__Bia.Data.Proiect__BiaContext context)
        {
            _context = context;
        }

        public IList<Provenienta> Provenienta { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Provenienta = await _context.Provenienta.ToListAsync();
        }
    }
}
