using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ModelViews.Predmet
{
    public class IndexView : SelectList_Spec_Smes
    {
        public IEnumerable<Predmeti> Predmetis { get; set; } = new List<Predmeti>();
    }



}
