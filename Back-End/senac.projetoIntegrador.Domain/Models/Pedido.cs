namespace senac.projetoIntegrador.Domain.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public List<Produto> Produtos { get; set; }
        public decimal Total { get; set; }
    }
}
