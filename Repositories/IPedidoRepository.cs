using ProjMaster.Models;

namespace ProjMaster.Repositories
{
    public interface IPedidoRepository
    {
        void CriarPedido(Pedido pedido);
    }
}