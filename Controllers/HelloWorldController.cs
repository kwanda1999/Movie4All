using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Movie4All.Controllers;

public class HelloWorldController : Controller {


    public IActionResult Index () {                        //Default action method within controller class
        return View();
    }   
    public IActionResult Welcome (string name, int numTimes = 1) {                      // Action method  within a controller class
    ViewData ["Message"] = "Hello" + name;
    ViewData ["NumTimes"] = numTimes;
    return View();
        }

}