using System.Collections.Generic;

namespace ProjMaster.Models
{
     public class Pedido
    {
        
        private List<ItemPedido> demanda = new List<ItemPedido>();

        public void lista(ItemPedido compra)
        {
            demanda.Add(compra);
        }
        
        public List<ItemPedido> Listar()
        {
            return demanda;
        }
        
        public double saida()
        {
            double total = 0;

            for(int i=0; i < demanda.Count; i++)
            {
                total = total + demanda[i].quantidade * demanda[i].valor;
            }

            return total;
        }

    }
}