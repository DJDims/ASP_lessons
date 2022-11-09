using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MusiciansInBands.Models
{
    public class Band
    {
        public int Id { get; set; }
        [Display(Name = "Название группы")]
        public string Name { get; set; }
        [Display(Name = "Сайт")]
        public string Website { get; set; }
        public ICollection<Musician> Musicians { get; set; }
        public Band()
        {
            Musicians = new List<Musician>();
        }
    }
}