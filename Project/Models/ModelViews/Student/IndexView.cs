namespace Project.Models.ModelViews.Student
{
    public class IndexView : SelectList_Spec_Smes
    {
        public IEnumerable<Studenti> Studentis { get; set; } = new List<Studenti>();
    }
}
