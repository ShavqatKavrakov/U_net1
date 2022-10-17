using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using Project.Models.ModelViews.Vedomost;

namespace Project.Controllers
{
    public class VedomostController : Controller
    {
        private readonly U_NetContext db;

        public VedomostController(U_NetContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int? specId,int? semestr,int? predId)
        {
            
            if (specId == null || semestr == null || predId == null)
                return BadRequest();

            var vedomosti = db.Vedomosti.ToList();
            var foundVedomost = new List<Vedomosti>();

            foreach (var v in vedomosti)
            {
                if(v.SpecId== specId && v.Semestr==semestr && v.PredId == predId)
                {
                    foundVedomost.Add(v);
                }
            }

            if (foundVedomost.Count == 0)
                ViewBag.Visable ="true";
            else
                ViewBag.Visable = "false";

            var indexView = new IndexView
            {
                SpecList = new SelectList(db.Specialnocti.ToList(), "Id", "SpecName"),
                PredmetList = new SelectList(db.Predmeti.ToList(), "Id", "PredmetName"),
                Vedomostis = foundVedomost,
                PrepList=new SelectList(db.Prepodavateli.ToList(),"Id", "PrepName")
            };

            return View(indexView);
        }
    }
}
