using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ModelViews.Vedomost
{
    public class IndexView : SelectList_Spec_Smes
    {
        public SelectList PredmetList { get; set; } = new SelectList(new List<Predmeti>(), "Id", "Name");
        public SelectList PrepList { get; set; } = new SelectList(new List<Prepodavateli>(), "Id", "Name");
        public IEnumerable<Vedomosti> Vedomostis { get; set; }=new List<Vedomosti>();
    }
}
