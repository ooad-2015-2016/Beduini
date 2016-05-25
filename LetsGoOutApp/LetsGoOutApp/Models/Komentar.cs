using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LetsGoOutApp.Models
{
    public class Komentar
    {
        public int ID { get; set; }
        public string Sadrzaj { get; set; }
        public float Ocjena { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public int DogadjajID { get; set; }
        public virtual Dogadjaj Dogadjaj { get; set; }
    }
}