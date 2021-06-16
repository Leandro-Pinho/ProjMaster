﻿using System.Collections.Generic;
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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            if(Autenticacao.verificaLoginSenha(login,senha,this))
            {
                return RedirectToAction("Index");
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
            return View("Index");
        }
    }
}
