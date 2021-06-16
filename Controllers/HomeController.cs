using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjMaster.Models;

namespace ProjMaster.Controllers
{
   public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Formulario()
        {
            if(HttpContext.Session.GetInt32("idUsuario") == null)
            return RedirectToAction("Login");
            ProdutosRepository medicamentoRepo = new ProdutosRepository();
            List<Produtos> medicamentos = medicamentoRepo.Lista();

            return View(); 
            
        }

        
        public IActionResult Listar(ItemPedido compra)
        {   
            Dados.PedidoAtual.lista(compra);
            List<ItemPedido> nova = Dados.PedidoAtual.Listar();
            return View(nova);
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            UsuarioRepository ur = new UsuarioRepository();
            ur.Insert(u);
            ViewBag.Mensagem = "Usuario Cadastrado com sucesso";
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            UsuarioRepository ur = new UsuarioRepository();
            Usuario usuario = ur.QueryLogin(u);
            if(usuario != null)
            {
                ViewBag.Mensagem = "Você está logado";
                HttpContext.Session.SetInt32("idUsuario", usuario.Id);
                HttpContext.Session.SetString("nomeUsuario", usuario.Nome);
                return View("Index");
            }
            else
            {
            ViewBag.Mensagem = "Falha no Login";
            return View();
            }
        }
           public IActionResult logout()
        {
            HttpContext.Session.Clear();//Limpar toda sessão
            return View("Index");
        }
    }
}
