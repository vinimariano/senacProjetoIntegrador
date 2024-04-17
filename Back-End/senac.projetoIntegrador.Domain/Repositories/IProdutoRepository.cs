using senac.projetoIntegrador.Domain.Models;

namespace senac.projetoIntegrador.Domain.Repositories
{
    public interface IProdutoRepository
    {
        List<Produto> List();
        int Create(Produto produto);
    }
}
