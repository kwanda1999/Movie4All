using Microsoft.AspNetCore.Mvc;
using Movie4All.Models;

namespace Movie4All.Controllers {

    public class Movie4AllController : Controller 
    {
        private readonly Movie4AllContext _context;

        public Movie4AllController(Movie4AllContext context)
        {
            _context = context;
        }

        public IActionResult Index() {
            return View();              //controller actions
        }

        public IActionResult Create() {
            return View();
        } 

        [HttpPost]
        public IActionResult Create (Movie movie) {
            
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details (int id) {
            return View ();
        }

        public IActionResult Edit (int id, Movie movie) {
        
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Details), new { id });
        }

        public IActionResult Delete (int id) {
            return View();
        }

        public IActionResult DeleteConfirmed (int id) {
            
            var movie = _context.Movies.Find(id);
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id) {
            if (id==null) {
                if (id==null) {
                    return NotFound();
                }
                var movie = await _context.Movie
                .FirstOrDefaultAsync (m=> m.Id == id);
                if (movie == null) {
                    return NotFound ();
                }

                return View(movie);
            }
        }
    }
}
