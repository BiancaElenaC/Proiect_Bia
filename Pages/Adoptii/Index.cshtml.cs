using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Proiect__Bia.Data;
using Proiect__Bia.Models;

namespace Proiect__Bia.Pages.Adoptii
{
    public class IndexModel : PageModel
    {
        private readonly Proiect__Bia.Data.Proiect__BiaContext _context;

        public IndexModel(Proiect__Bia.Data.Proiect__BiaContext context)
        {
            _context = context;
        }

        public IList<Adoptie> Adoptie { get; set; } = default!;

        public string? DateSort { get; set; } // Variabila pentru sortarea dupa DataAdoptie

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; } // Variabila pentru cautare

        public async Task OnGetAsync(string? sortOrder, string? searchString)
        {
            // Setam variabila pentru sortare (ascendenta sau descendenta)
            DateSort = sortOrder == "date_desc" ? "date_asc" : "date_desc";

            Adoptie = await _context.Adoptie
                .Include(a => a.Adoptator)
                .Include(a => a.Copil).ToListAsync();

            // De aici incepe cautarea
            var adoptii = _context.Adoptie
                 .Include(a => a.Copil)
                 .Include(a => a.Adoptator)
                 .AsQueryable();

            // Aplică filtrul doar daca utilizatorul a introdus ceva
            if (!string.IsNullOrEmpty(SearchString))
            {
                adoptii = adoptii.Where(a =>
                    a.Copil.Nume.Contains(SearchString) ||
                    a.Copil.Prenume.Contains(SearchString) ||
                    a.Adoptator.Nume.Contains(SearchString) ||
                    a.Adoptator.Prenume.Contains(SearchString));
            }

            // Aplicăm sortarea in functie de sortOrder
            switch (sortOrder)
            {
                case "date_asc":
                    adoptii = adoptii.OrderBy(a => a.DataAdoptiei);
                    break;
                case "date_desc":
                    adoptii = adoptii.OrderByDescending(a => a.DataAdoptiei);
                    break;
            }
            Adoptie = await adoptii.ToListAsync();
        }

    }
}

