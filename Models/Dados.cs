namespace ProjMaster.Models
{
    public static class Dados
     {
        public static Pedido PedidoAtual { get; set;}
        static Dados()
           {
               PedidoAtual = new Pedido();
           }
     }
}