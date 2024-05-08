using senac.projetoIntegrador.Domain.Models;
using senac.projetoIntegrador.Domain.Repositories;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using Dapper;

namespace senac.projetoIntegrador.Repositories.BancoDeDados
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(IOptions<ConfigurationModel> configuration)
        {
            this.db = new SqlConnection(configuration.Value.ConnectionString);
        }

        public int Create(Produto produto)
        {
            string sql = @"INSERT INTO [VersaoFinal].[Produto]
               (
                [Nome]
               ,[Descricao]
               ,[Preco]
               ,[CaminhoImagem]
               ,[PalavrasChave])
                VALUES
                (
                   @Nome,
                   @Descricao,
                   @Preco,
                   @CaminhoImagem,
                   @PalavrasChave
                );
                SELECT SCOPE_IDENTITY();";

            int id = this.db.ExecuteScalar<int>(sql, new
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                CaminhoImagem = produto.CaminhoImagem,
                PalavrasChave = produto.PalavrasChave
            });
          
            return id;
        }

        public void Delete(int id)
        {
            string sql = @"DELETE FROM
	                [ProjetoIntegrador].[VersaoFinal].[Produto]
                WHERE
	                Id = @Id";

            this.db.Execute(sql, new
            {
                Id = id
            });            
        }

        public List<Produto> List()
        {
            List<Produto> list =
              this.db.Query<Produto>
              (@"
                   SELECT 
                        [Id]
                        ,[Nome]
                        ,[Descricao]
                        ,[Preco]
                        ,[CaminhoImagem]
                        ,[PalavrasChave]
                    FROM 
                        [ProjetoIntegrador].[VersaoFinal].[Produto]
                ")?.ToList();
            
            return list;
        }

        public List<Produto> ListByKeyword(string palavraChave)
        {
            List<Produto> list =
               this.db.Query<Produto>
               (@"
                   SELECT 
                        [Id]
                        ,[Nome]
                        ,[Descricao]
                        ,[Preco]
                        ,[CaminhoImagem]
                        ,[PalavrasChave]
                    FROM 
                        [ProjetoIntegrador].[VersaoFinal].[Produto]
                    WHERE [PalavrasChave] LIKE ('%'+ @PalavraChave + '%')  
                ", new
               {
                   PalavraChave = palavraChave
               })?.ToList();

            return list;
        }
    }
}
