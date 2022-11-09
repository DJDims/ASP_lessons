using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MusiciansInBands.Models
{
    public class Musician
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string Firstname { get; set; }
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        [Display(Name = "Фото")]
        public byte[] Photo { get; set; }
        public string PhotoType { get; set; }
        public int? InstrumentId { get; set; }
        [Display(Name = "Инструмент")]
        public Instrument Instrument { get; set; }
        public int? BandId { get; set; }
        [Display(Name = "Группа")]
        public Band Band { get; set; }
    }
}