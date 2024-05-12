using senac.projetoIntegrador.Domain.Models;

namespace senac.projetoIntegrador.Domain.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> List();
        List<Produto> ListByKeyword(string palavraChave);
        int Create(Produto produto);
        void Delete(int id);
    }
}
