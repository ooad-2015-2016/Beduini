using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppLetsGoOut.Models
{
    public class Nalog
    {
        public int ID { get; set; }
        public string korisnickoIme { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public DateTime datumKreiranja { get; set; }
    }
    public class NalogDbContext : DbContext
    {
        public DbSet<Nalog>Nalog { get; set; }
    }

}