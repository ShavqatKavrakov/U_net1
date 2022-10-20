using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public partial class Vedomosti
    {
        public int Id { get; set; }
        public int SpecId { get; set; }
        public int Semestr { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Studenti? Student { get; set; }
        public int PredId { get; set; }
        public int PrepId { get; set; }
        public bool? TipAttes { get; set; }
        public int? Ball { get; set; }
    }
}
