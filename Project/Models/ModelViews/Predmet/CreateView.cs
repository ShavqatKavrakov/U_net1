using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ModelViews.Predmet
{
    public class CreateView
    {
        public SelectList SelectList { get; set; } = new SelectList(new List<Specialnocti>(), "Id", "Name");
    }
}
