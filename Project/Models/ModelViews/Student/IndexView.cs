namespace Project.Models.ModelViews.Student
{
    public class IndexView : SelectSpecialnoct
    {
        public IEnumerable<Studenti> Studentis { get; set; } = new List<Studenti>();
    }
}
