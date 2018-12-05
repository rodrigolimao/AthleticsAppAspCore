using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtleticaEco.Models;

namespace AtleticaEco.Models
{
    public class AtleticaModel : DbContext
    {
        public AtleticaModel(DbContextOptions<AtleticaModel>options): base(options)
        {
        }

        public DbSet<Athlete> Athletes { get; set; }

    }
}
