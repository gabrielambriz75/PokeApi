using Microsoft.EntityFrameworkCore;
using MiPrimeraApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimeraApi.Infrastructure
{
    public class CatalogoDbContext : DbContext
    {
        public CatalogoDbContext(DbContextOptions<CatalogoDbContext>options):base (options)
        {

        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
