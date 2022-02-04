using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcOmegaSport.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /HelloWorld/

        /*  -----Este método Index devuelve una cadena con un mensaje en la clase del controlador.
          
        public string Index()
        {
            return "This is my default action...";
        }
        */


        //Llama al método View del controlador.
        //Utiliza una plantilla de vista para generar una respuesta HTML.
        public IActionResult Index()
        {
            return View();
        }


        /* 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
        

        // GET: /HelloWorld/Welcome/ -----método para incluir dos parámetros
        public string Welcome(string name, int numTimes = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
        }
        */
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}


