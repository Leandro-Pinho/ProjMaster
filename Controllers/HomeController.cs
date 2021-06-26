using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjMaster.Models;
using ProjMaster.ViewModels;

namespace ProjMaster.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            if(Autenticacao.verificaLoginSenha(login,senha,this))
            {
                return RedirectToAction("IndexMain", "Lanche");
            }
            else
            {
                ViewData["Erro"] = "Senha inválida";
                return View();
            }
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();//Limpar toda sessão
            return RedirectToAction("IndexMain", "Lanche");
        }
    }
}
