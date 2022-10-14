using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers
{
    public class VedomostController : Controller
    {
        public IActionResult Index(int? Spec_Id,int? Semestr,int? Pred_Id)
        {



            return View();
        }
    }
}
