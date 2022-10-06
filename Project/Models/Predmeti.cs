using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public partial class Predmeti
    {
        public int Id { get; set; }
        public string PredmetName { get; set; } = null!;
        public int SpecId { get; set; }
        public int Semesetr { get; set; }
        [ForeignKey("SpecId")]
        public Specialnocti? Specialnocti { get; set; }
    }
}
