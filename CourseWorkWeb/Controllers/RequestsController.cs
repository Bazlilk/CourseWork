using CourseWorkWeb.Data;
using CourseWorkWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseWorkWeb.Controllers
{
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RequestsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Requests> objRequestsList = _db.Requests;
            return View(objRequestsList);
        }
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Requests obj)
        {
            if (ModelState.IsValid)
            {
                _db.Requests.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var requestFromDb = _db.Requests.Find(id);
            if (requestFromDb == null)
            {
                return NotFound();
            }
            return View(requestFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Requests obj)
        {
            if (ModelState.IsValid)
            {
                _db.Requests.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //POST
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var requestFromDb = _db.Requests.Find(id);
            if (requestFromDb == null)
            {
                return NotFound();
            }
            return View(requestFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Requests.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Requests.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
