using Microsoft.AspNetCore.Mvc.Rendering;
namespace Project.Models.ModelViews.Predmet
{
    public class IndexView : SelectSpecialnoct
    {
        public IEnumerable<Predmeti> Predmetis { get; set; } = new List<Predmeti>();
    }



}
