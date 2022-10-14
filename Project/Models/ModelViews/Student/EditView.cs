using Microsoft.AspNetCore.Mvc.Rendering;

namespace Project.Models.ModelViews.Student
{
    public class EditView:  SelectList_Spec_Smes
    {
       public Studenti? Student { get; set;}
    }
}
