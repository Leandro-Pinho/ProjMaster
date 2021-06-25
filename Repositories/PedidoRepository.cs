using System;
using ProjMaster.Data;
using ProjMaster.Models;

namespace ProjMaster.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ProjMasterContext _Context;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoRepository(ProjMasterContext Context, CarrinhoCompra carrinhoCompra)
        {
            _Context = Context;
            _carrinhoCompra = carrinhoCompra;
        }
        public void CriarPedido(Pedido pedido)
        {
            pedido.PedidoEnviado = DateTime.Now;
            _Context.Pedidos.Add(pedido);
            _Context.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach(var carrinhoItem in carrinhoCompraItens)
            {
                var PedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    LancheId = carrinhoItem.Lanche.Id,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Lanche.Preco
                };
                _Context.PedidoDetalhes.Add(PedidoDetail);
            }
            _Context.SaveChanges();
        }
    }
}