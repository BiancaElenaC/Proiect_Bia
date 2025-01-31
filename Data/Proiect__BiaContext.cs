using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect__Bia.Models;

namespace Proiect__Bia.Data
{
    public class Proiect__BiaContext : DbContext
    {
        public Proiect__BiaContext (DbContextOptions<Proiect__BiaContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect__Bia.Models.Copil> Copil { get; set; } = default!;
        public DbSet<Proiect__Bia.Models.Adoptator> Adoptator { get; set; } = default!;
        public DbSet<Proiect__Bia.Models.Adoptie> Adoptie { get; set; } = default!;
        public DbSet<Proiect__Bia.Models.Angajat> Angajat { get; set; } = default!;
        public DbSet<Proiect__Bia.Models.Locatie> Locatie { get; set; } = default!;
        public DbSet<Proiect__Bia.Models.Provenienta> Provenienta { get; set; } = default!;
    }
}
