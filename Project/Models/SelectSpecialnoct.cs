using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models
{
    public class SelectSpecialnoct
    {
        public SelectList SelectList { get; set; } = new SelectList(new List<Specialnocti>(), "Id", "Name");
    }
}
