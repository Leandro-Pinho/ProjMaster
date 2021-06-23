using Microsoft.EntityFrameworkCore;
using ProjMaster.Models;

namespace ProjMaster.Data
{
    public class ProjMasterContext : DbContext
    {
        public ProjMasterContext (DbContextOptions<ProjMasterContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> usuarios {get; set;}
        public DbSet<Lanche> Lanches { get; set; }
        public DbSet<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}