using senac.projetoIntegrador.Domain.Models;

namespace senac.projetoIntegrador.Domain.Repositories
{
    public interface IPedidoRepository
    {
        int Create(Pedido pedido);
        List<Pedido> List(string loginUsuario);
    }
}
