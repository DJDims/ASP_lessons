using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusiciansInBands.Models
{
    public class MusicContext:DbContext
    {
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Band> Bands { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
    }
}