
using ProjMaster.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ProjMaster.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Lista()
        {
            ProdutosRepository produtosRepo = new ProdutosRepository();
            List<Produtos> medicamentos = produtosRepo.Lista();

            return View(medicamentos); 
        }
    }
}