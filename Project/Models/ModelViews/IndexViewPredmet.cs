namespace Project.Models.ModelViews
{
    public class CreateViewPredmet
    {
        public IEnumerable<Specialnocti> Spec { get; set; } = new List<Specialnocti>();
        public Predmeti? Predmet { get; set; }
        public CreateViewPredmet(IEnumerable<Specialnocti> spec, Predmeti? predmet)
        {
            Spec = spec;
            Predmet = predmet;
        }
    }
}
