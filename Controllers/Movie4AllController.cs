using Microsoft.AspNetCore.Mvc;
using Movie4All.Models;

namespace Movie4All.Controllers {

    public class Movie4AllController : Controller 
    {
        public IActionResult Index() {
            return View();              //controller actions
    }

    public IActionResult Create() {
        return View();
    } 

    [HttpPost]
    public IActionResult Create (Movie movie) {
        return RedirectToAction (nameof(Index));
    }

    public IActionResult Details (int id) {
        return View ();
    }

    public IActionResult Edit (int id, Movie movie) {
        return RedirectToAction
         (nameof(Details), new {id});
    }

    public IActionResult Delete (int id) {
        return View();
    }

    public IActionResult DeleteConfirmed (int id) {
        return RedirectToActions (nameof(Index));
        }
    }
}