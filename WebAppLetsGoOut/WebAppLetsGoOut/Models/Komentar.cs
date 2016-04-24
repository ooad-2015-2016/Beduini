﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppLetsGoOut.Models
{
    public class Komentar
    {
        public int ID { get; set; }
        public DateTime datum { get; set; }
        public string sadrzaj { get; set; }
        public float ocjena { get; set; }
        public DateTime datumKreiranja { get; set; }
    }
    public class KomentarDbContext : DbContext
    {
        public DbSet<Komentar> Komentar { get; set; }
    }
}