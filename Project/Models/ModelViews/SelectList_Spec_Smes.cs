using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ModelViews
{
    public class SelectList_Spec_Smes
    {

        public SelectList SpecList { get; set; } = new SelectList(new List<Specialnocti>(), "Id", "Name");
        public SelectList SemestList { get; set; } = new SelectList(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });
    }
}
