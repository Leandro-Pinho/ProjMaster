using System.Linq;
using ProjMaster.Models;
using ProjMaster.Repositories;
using ProjMaster.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ProjMaster.Controllers;

namespace MvcMovie.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra )
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }
        public IActionResult Index()
        {
            Autenticacao.CheckLogin(this);
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraViewModel = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraViewModel);
        }
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra( int lancheId)
        {
            Autenticacao.CheckLogin(this);
            var lancheSelecionado = _lancheRepository.lanches.FirstOrDefault(p => p.Id == lancheId );

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);
            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoverItemNoCarrinhoCompra( int lancheId)
        {
            Autenticacao.CheckLogin(this);
            var lancheSelecionado = _lancheRepository.lanches.FirstOrDefault(p => p.Id == lancheId );

            if (lancheSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado, 1);
            }
            return RedirectToAction("Index");
        }
    }
}