using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Movie4All.Controllers;

public class HelloWorldController : Controller {


    public string Index () {                        //Default action method within controller class
        return "This is my default action...";
    }   
    public string Welcome ( string name, int ID=1) {                      // Action method  within a controller class
    return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}"); 
        }

}