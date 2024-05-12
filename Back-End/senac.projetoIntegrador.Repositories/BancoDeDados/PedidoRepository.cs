using Microsoft.Extensions.Options;
using senac.projetoIntegrador.Domain.Models;
using senac.projetoIntegrador.Domain.Repositories;
using System.Data.SqlClient;
using Dapper;
using senac.projetoIntegrador.Repositories.Models;

namespace senac.projetoIntegrador.Repositories.BancoDeDados
{
    public class PedidoRepository : BaseRepository, IPedidoRepository
    {
        public PedidoRepository(IOptions<ConfigurationModel> configuration)
        {
            this.db = new SqlConnection(configuration.Value.ConnectionString);
        }

        public int Create(Pedido pedido)
        {
            //Cria o pedido
            string sql = @"INSERT INTO [VersaoFinal].[Pedido]
           ([Total]
           ,[LoginUsuario]
           ,[DataPedido])
                VALUES
                (
                   @Total,
                   @LoginUsuario,
                   @DataPedido
                );
                SELECT SCOPE_IDENTITY();";

            int id = this.db.ExecuteScalar<int>(sql, new
            {
                Total = pedido.Total,
                LoginUsuario = pedido.LoginUsuario,
                DataPedido = pedido.DataPedido
            });

            //Cria os registros na pedido produto
            foreach (PedidoProduto produto in pedido.Produtos)
            {
                CreatePedidoProduto(produto, id);
            }

            return id;
        }

        public List<Pedido> List(string loginUsuario)
        {
            string where =
                (
                    loginUsuario.ToLower() == "atendente" ||
                    loginUsuario.ToLower() == "administrador"
                ) ?
                "" 
                : "WHERE" +
                "       [LoginUsuario] = @LoginUsuario";

            string sql = $@"
                   SELECT 
                       [Id]
                        ,[Total]
                        ,[LoginUsuario]
                        ,[DataPedido]
                    FROM 
                        [ProjetoIntegrador].[VersaoFinal].[Pedido]
                    {where}
                ";

            List<Pedido> listTabelaPedido =
              this.db.Query<Pedido>
              (sql, new
              {
                  LoginUsuario = loginUsuario
              })?.ToList();

            if (listTabelaPedido?.Any() == true)
                foreach (Pedido tabelaPedido in listTabelaPedido)
                {
                    //Busca os produtos do pedido
                    List<PedidoProduto> pedidoProdutos = ListProdutosPedido(tabelaPedido.Id);
                    tabelaPedido.Produtos = pedidoProdutos;
                }

            return listTabelaPedido;
        }

        private List<PedidoProduto> ListProdutosPedido(int idPedido)
        {
            List<tabelaPedidoProduto> listTabelaPedidoProduto =
              this.db.Query<tabelaPedidoProduto>
              (@"
                SELECT
                   [IdPedido]
                  ,[IdProduto]
                  ,PP.[Preco]
                  ,[QuantidadeProduto]
	              ,P.[Nome] AS [NomeProduto]
	              ,P.[Descricao] AS [DescricaoProduto]
	              ,P.[CaminhoImagem] AS [CaminhoImagemProduto]
	              ,P.[PalavrasChave] AS [PalavrasChaveProduto]
              FROM [ProjetoIntegrador].[VersaoFinal].[PedidoProduto] PP
              JOIN [ProjetoIntegrador].[VersaoFinal].[Produto] P
              ON PP.IdProduto = P.Id
                  WHERE
                      [IdPedido] = @IdPedido
                ", new
              {
                  IdPedido = idPedido
              })?.ToList();

            List<PedidoProduto> retorno = new List<PedidoProduto>();
            if (listTabelaPedidoProduto?.Any() == true)
                foreach (tabelaPedidoProduto tbPedidoProduto in listTabelaPedidoProduto)
                    retorno.Add(tbPedidoProduto.Mapear());

            return retorno;
        }

        private void CreatePedidoProduto(PedidoProduto pedidoProduto, int idPedido)
        {
            //Cria o pedido produto
            string sql = @"INSERT INTO [VersaoFinal].[PedidoProduto]
            ([IdPedido]
           ,[IdProduto]
           ,[Preco]
           ,[QuantidadeProduto])
                VALUES
                (
                   @IdPedido,
                   @IdProduto,
                   @Preco,
                   @QuantidadeProduto
                );
               ";

            this.db.ExecuteScalar<int>(sql, new
            {
                IdPedido = idPedido,
                IdProduto = pedidoProduto.Produto.Id,
                Preco = pedidoProduto.Produto.Preco,
                QuantidadeProduto = pedidoProduto.Quantidade
            });
        }
    }
}
