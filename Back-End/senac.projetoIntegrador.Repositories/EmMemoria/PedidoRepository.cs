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
            //Incrementa o Id
            int maximoId = _bancoDeDados.Any() ? _bancoDeDados.Max(x => x.Id) : 0;
            pedido.Id = maximoId + 1;

            //Salva o pedido
            _bancoDeDados.Add(pedido);

            //Retorna o Id
            return pedido.Id;
        }

        public List<Pedido> List(string loginUsuario)
        {
            return _bancoDeDados.Where(t => t.LoginUsuario == loginUsuario)
                .OrderByDescending(t => t.Id).ToList();
        }
    }
}
