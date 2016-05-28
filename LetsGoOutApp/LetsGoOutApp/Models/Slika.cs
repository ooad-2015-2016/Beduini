using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LetsGoOutApp.Models
{
    public class Slika
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int LokalID { get; set; }
        public virtual Lokal Lokal { get; set; }
    }
}