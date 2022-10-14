using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ModelViews.Predmet
{
    public class EditView : SelectList_Spec_Smes
    {
        public Predmeti? Predmet { get; set; }
    }
}
