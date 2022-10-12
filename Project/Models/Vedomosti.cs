using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public partial class Vedomosti
    {
        public int Id { get; set; }
        [ForeignKey("SpecId")]
        public int SpecId { get; set; }
        public int Semestr { get; set; }
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        [ForeignKey("PredId")]
        public int PredId { get; set; }
        [ForeignKey("PrepId")]
        public int PrepId { get; set; }
        public bool? TipAttes { get; set; }
        public int? Ball { get; set; }
    }
}
