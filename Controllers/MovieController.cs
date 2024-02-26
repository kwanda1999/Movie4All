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

        public async  Task<IActionResult>  Index(string movieGenre, string searchString) {
           if (_context.Movie == null) {
            return Problem("Entity set 'Movie4AllContext.movie' is null");
           } 
           IQueryable <string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.movie
                         select m;

            if (!string.IsNullOrEmpty(searchString))  {
                movies = movies.Where (s=> s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))  {
                movies = movies.Where(x=> x.Genre == movieGenre);
            }
            var movieGenreVM = newMovieGenreViewModel {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return View(movieGenreVM)
        }

        public IActionResult Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")]Movie movie) {
            return View();
        } 

        [HttpPost]
        public IActionResult Create (Movie movie) {
            
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details (int? id) {

            if (id == null) {
                return NotFound ();
            }

                var movie = await _context.Movie
                    .FirstOrDefaultAsync(m => m.Id == id);
                    if (movie == null) {
                        return NotFound();
                        }
            return View (movie);
        }

        public IActionResult Edit (int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")]Movie movie) {
        
            _context.Movies.Update(movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Details), new { id });
        }

        public IActionResult Delete (int id) {

            if (id=-null) {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m=> m.Id == id);

            if (movie == null) {
                
                return View(movie);
            }
            
        }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed (int id) {

             var movie = await _context.Movie.FindAsync(id);
             if (movie != null) {
                _context.Movie.Remove(movie);
             }
             await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
            }
        }
    


