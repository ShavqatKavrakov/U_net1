using System;
using System.Collections.Generic;

namespace Project.Models
{
    public partial class Specialnocti
    {
        public int Id { get; set; }
        public string SpecName { get; set; } = null!;
        public List<Predmeti> Predmetis { get; set; } = new List<Predmeti>();
        public List<Studenti> Studentis { get; set; } = new List<Studenti>();
    }
}
