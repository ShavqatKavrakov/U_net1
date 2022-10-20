using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.ModelViews.Vedomost;

namespace Project.Controllers
{
    public class VedomostController : Controller
    {
        private readonly U_NetContext db;
        List<Vedomosti> foundVedomost = new List<Vedomosti>();

        public VedomostController(U_NetContext db)
        {
            this.db = db;
        }

        public IActionResult Index(int specId,int semestr,int predId,string? TipAttes,int prepId)
        {
            
            var vedomosti = db.Vedomosti.ToList();
            
            foreach (var v in vedomosti)
            {
                if(v.SpecId== specId && v.Semestr==semestr && v.PredId == predId)
                {
                    foundVedomost.Add(v);
                }
            }

            if (foundVedomost.Count == 0 && specId>0)
            {
                ViewBag.Visable = "true";
                bool tipAttes = (TipAttes == "Зачет") ? false : true;

                   var students=db.Studenti.Where(s=>s.SpecId==specId).ToList();

                foreach (var s in students)
                {
                    foundVedomost.Add(new Vedomosti
                    {
                        Semestr = semestr,
                        PredId = predId,
                        SpecId = s.SpecId,
                        Student = s,
                        StudentId = s.Id,
                        TipAttes = tipAttes,
                        PrepId = prepId,
                    }); ; 
                }
            }
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
