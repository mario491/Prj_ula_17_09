using Microsoft.AspNetCore.Mvc;
using projecto_Aula_16_09.Models;
using System.Diagnostics;

namespace projecto_Aula_16_09.Controllers
   
{
    public class HomeController : Controller
    {

        public static List<Pessoa> Cadastros = new List<Pessoa>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    


        public IActionResult Cadastrar()
        {
          
            var provincias = new List<string>
    {
        "Maputo", "Gaza", "Inhambane", "Manica", "Sofala",
        "Tete", "Zambézia", "Nampula", "Niassa", "Cabo Delgado"
    };

            ViewBag.Provincias = provincias;

            return View();
        }



        [HttpPost]
        public IActionResult Cadastrar(Pessoa pessoa)
        {

            if (ModelState.IsValid)
            {
                Cadastros.Add(pessoa);
                ViewBag.messagem = "Cadastro realizado com sucesso";
                return RedirectToAction("Visualizar");
            }
            else
            {
                ViewBag.messagem = "Erro no cadastro. Verifique os dados.";


                return View();
            }

        }
      
        
        


        [HttpGet]

        public IActionResult Visualizar()
        {


            return View(Cadastros);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
