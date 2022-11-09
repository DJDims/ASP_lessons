using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MusiciansInBands.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        [Display(Name = "Инструмент")]
        public string Name { get; set; }
    }
}