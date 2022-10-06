using Microsoft.AspNetCore.Mvc.Rendering;
namespace Project.Models.ModelViews.Predmet
{
    public class IndexView
    {

        public IEnumerable<Predmeti> Predmetis { get; set; } = new List<Predmeti>();
        public SelectList Specialnoctis { get; set; } = new SelectList(new List<Specialnocti>(), "Id", "SpecName");
        public string? Name { get; set; }
    }

    
    
}
