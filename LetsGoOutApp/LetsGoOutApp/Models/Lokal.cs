using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LetsGoOutApp.Models
{
    public class Lokal
    {
        public int ID { get; set; }
        public string naziv { get; set; }
        public string adresa { get; set; }
        public int postanskiBroj { get; set; }
        public string grad { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string opis { get; set; }
        
    }
    public class LokalDbContext : DbContext
    {
        public DbSet<Lokal> Lokal { get; set; }
    }
}