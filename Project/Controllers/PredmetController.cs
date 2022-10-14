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
        #region Интерфейс Предмет + Сортировка + Фильтр 
        public IActionResult Index(string? sortOrder, int? specId, string? searchByName)
        {
            IQueryable<Predmeti> predmets = db.Predmeti.Include(s => s.Specialnocti);

            //Поиск 
            if (specId != null)
            {
                predmets = predmets.Where(p => p.SpecId == specId);
            }

            if (!String.IsNullOrEmpty(searchByName))
            {
                ViewBag.SearchByName = searchByName;
                searchByName = searchByName.Trim(' ');
                predmets = predmets.Where(x => EF.Functions.Like(x.PredmetName, $"%{searchByName}%"));
            }

            //Сортировка
            ViewBag.SemestSortParam = (String.IsNullOrEmpty(sortOrder)) ? "SortSemestr_Desc" : "";

            switch (sortOrder)
            {
                case "SortSemestr_Desc":
                    predmets = predmets.OrderByDescending(x => x.Semesetr);
                    break;

                default:
                    predmets = predmets.OrderBy(x => x.Semesetr);
                    break;
            }

            var viewModel = new IndexView
            {
                Predmetis = predmets.ToList(),
                SpecList = new SelectList(db.Specialnocti.ToList(), "Id", "SpecName")
            };

            return View(viewModel);
        }
        #endregion

        #region Добавить Предмет
        [HttpGet]
        public IActionResult Create()
        {
            var viewCreate = new EditView
            {
                SpecList = new SelectList(db.Specialnocti.ToList(), "Id", "SpecName")
            };

            return View(viewCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Predmeti predmet)
        {

            db.Predmeti.Add(predmet);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Изменить Предмет

        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id != null)
            {
                var prep = await db.Predmeti.FirstOrDefaultAsync(p => p.Id == Id);

                if (prep == null)
                    return NotFound();

                    var viewEdit = new EditView
                    {
                        SpecList = new SelectList(db.Specialnocti.ToList(), "Id", "SpecName"),
                      
                        Predmet = prep
                    };

                    return View(viewEdit);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Predmeti predmet)
        {
            db.Predmeti.Update(predmet);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Удалить Предмет
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var pred = await db.Predmeti.FirstOrDefaultAsync(p => p.Id == id);

                if (pred != null)
                {
                    db.Predmeti.Remove(pred);
                    await db.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }

            return NotFound();
        }

        #endregion

    }
}
