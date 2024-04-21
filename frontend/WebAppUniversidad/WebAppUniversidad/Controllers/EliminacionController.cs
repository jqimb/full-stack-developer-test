using Microsoft.AspNetCore.Mvc;

namespace WebAppUniversidad.Controllers
{
    public class EliminacionController : Controller
    {
        private IConfiguration _configuration;

        public EliminacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // Se busca la configuracion del URL base de las APIs
            string apiURL = _configuration["UrlAPIBackend"] ?? "";
            ViewData["apiURL"] = apiURL;
            return View();
        }
    }
}
