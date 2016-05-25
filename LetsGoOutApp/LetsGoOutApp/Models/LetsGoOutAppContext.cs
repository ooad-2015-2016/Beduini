using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LetsGoOutApp.Models
{
    public class LetsGoOutAppContext : DbContext
    {
        public LetsGoOutAppContext() : base("LetsGoOutAppContext")
        { }

        public DbSet<Dogadjaj> Dogadjaji { get; set; }
        public DbSet<Komentar> Komentari { get; set; }
        public DbSet<Lokal> Lokali { get; set; }
        public DbSet<Nalog> Nalozi { get; set; }
    }
}