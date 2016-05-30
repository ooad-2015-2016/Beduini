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
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int PostanskiBroj { get; set; }
        public string Grad { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Opis { get; set; }
        public virtual ICollection<Slika> Slike { get; set; }
        public virtual ICollection<Komentar> Komentari { get; set; }
    }
}