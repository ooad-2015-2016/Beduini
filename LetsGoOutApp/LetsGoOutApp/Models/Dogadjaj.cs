using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LetsGoOutApp.Models
{
    
        public class Dogadjaj
        {
            public int ID { get; set; }
            public DateTime datum { get; set; }
            public string naziv { get; set; }
            public string opis { get; set; }
            public float cijena { get; set; }
        }
        public class DogadjajDbContext : DbContext
        {
            public DbSet<Dogadjaj> Dogadjaj { get; set; }
        }

    
}