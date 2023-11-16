namespace senac.projetoIntegrador.Domain.Models
{
    public class ListaDePedido
    {
        public class ListaDePedidos
        {
            public List<Pedido> Pedidos { get; set; }
            public ListaDePedidos()
            {
                Pedidos = new List<Pedido>();
            }
            public List<Pedido> BancoDePedidos()
            {
                return Pedidos;
            }
        }

    }

