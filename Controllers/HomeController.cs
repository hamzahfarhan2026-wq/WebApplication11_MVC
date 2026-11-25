using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication11_MVC.Data;
using WebApplication11_MVC.Models;

namespace WebApplication11_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student std)
        {
            if(std != null)
            {
            _context.Students.Add(std);
            _context.SaveChanges();

            }

            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var Findstudent = _context.Students.Find(id);
            if (Findstudent == null)
            {
                return NotFound();
            }

            return View(Findstudent);
        }
        [HttpPost]
        public IActionResult Edit(int id, Student std)
        {
            var Findstudent = _context.Students.Find(id);
            if (Findstudent == null)
            {
                return NotFound();
            }

            _context.Students.Update(std);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var findstd = _context.Students.Find(id);
            if (findstd == null)
            {
                NotFound();
            }

            return View(findstd);
        }

        [HttpDelete]
        public IActionResult Delete(int id, Student student)
        {
            var findstd = _context.Students.Find(id);
            if (findstd != null)
            {
                _context.Students.Remove(findstd);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var findstd = _context.Students.Find(id);
            if (findstd == null)
            {
                NotFound();
            }

            return View(findstd);
        }

    }
}
