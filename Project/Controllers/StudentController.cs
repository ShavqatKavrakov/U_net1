using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Models.ModelViews.Student;

namespace Project.Controllers
{
    public class StudentController : Controller
    {
        public readonly U_NetContext db;

        public StudentController(U_NetContext db)
        {
            this.db = db;
        }
        #region Интерфейс+Сортировка+Поиск
        public async Task<IActionResult> Index(string? sortOrder, string? searchByName)
        {
            IQueryable<Studenti> studentis = db.Studenti.Include(s=>s.Specialnoct);

            //Поиск
            if (!String.IsNullOrEmpty(searchByName))
            {
                ViewBag.SearchByName = searchByName;
                searchByName = searchByName?.Trim(' ');
                studentis = studentis.Where(x => EF.Functions.Like(x.StudName, $"%{searchByName}%"));
            }

            //Сортировка
            ViewBag.SortByKurs = (String.IsNullOrEmpty(sortOrder)) ? "SortKurs_Desk" : "";

            switch (sortOrder)
            {
                case "SortKurs_Desk":
                    studentis = studentis.OrderByDescending(s => s.Kurs);
                    break;

                default:
                    studentis = studentis.OrderBy(s => s.Kurs);
                    break;
            }

            var viewIndex = new IndexView
            {
                SpecList = new SelectList(await db.Specialnocti.ToListAsync(), "Id", "Name"),
                Studentis = await studentis.ToListAsync()
            };

            return View(viewIndex);
        }
        #endregion

        #region Добавить Student
        public IActionResult Create()
        {
            var viewCreate = new EditView
            {
                SpecList = new SelectList(db.Specialnocti.ToList(), "Id", "SpecName")
            };

            return View(viewCreate);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Studenti student)
        {
            db.Studenti.Add(student);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Изменить Student
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var student = db.Studenti.FirstOrDefault(x => x.Id == id);
                if (student == null)
                    return NotFound();

                var viewEdit = new EditView
                {
                    Student = student,
                    SpecList = new SelectList(db.Specialnocti.ToList(), "Id", "SpecName")
                };

                return View(viewEdit);
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Studenti student)
        {
            db.Studenti.Update(student);
            await db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Удалить Student
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var student = await db.Studenti.FirstOrDefaultAsync(s => s.Id == id);

                if (student != null)
                {
                    db.Studenti.Remove(student);
                    await db.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }

                return NotFound();
            }

            return BadRequest();
        }
        #endregion
    }
}
