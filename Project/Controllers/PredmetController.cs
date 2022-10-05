using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models.ModelViews.Predmet;

namespace Project.Controllers
{
    public class PredmetController : Controller
    {

        private readonly U_NetContext db;
        public PredmetController(U_NetContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Добавить предмет
        [HttpGet]
        public IActionResult Create()
        {
            CreateView viewPredmet = new CreateView
            {
                SelectList=new SelectList(db.Specialnocti.ToList(), "Id", "SpecName")
            };
            
            return View(viewPredmet);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Predmeti predmet)
        {

            db.Predmeti.Add(predmet);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
