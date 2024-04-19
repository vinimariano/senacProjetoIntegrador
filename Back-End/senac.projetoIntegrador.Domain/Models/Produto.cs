namespace senac.projetoIntegrador.Domain.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string CaminhoImagem { get; set; }
        public string PalavrasChave { get; set; }
    }
}