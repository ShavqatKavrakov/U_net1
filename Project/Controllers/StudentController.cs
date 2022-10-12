using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    public class StudentController : Controller
    {
        public readonly U_NetContext db;
        
        public StudentController(U_NetContext db)
        {
            this.db = db;
        } 
        public async Task<IActionResult> Index()
        {
            return View(await db.Studenti.ToListAsync());
        }


    }
}
