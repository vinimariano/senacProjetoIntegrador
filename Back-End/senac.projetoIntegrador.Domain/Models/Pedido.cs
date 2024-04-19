namespace senac.projetoIntegrador.Domain.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public List<PedidoProduto> Produtos { get; set; }
        public decimal Total { get; set; }
        public string LoginUsuario { get; set; }
    }
}