using senac.projetoIntegrador.Domain.Models;
using senac.projetoIntegrador.Domain.Repositories;

namespace senac.projetoIntegrador.Repositories.EmMemoria
{
    public class PedidoRepository : IPedidoRepository
    {
        private static List<Pedido> _bancoDeDados = new List<Pedido>
        {
        };

        public int Create(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
