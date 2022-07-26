using Dapper;
using ProjetoAula05_c.Configurations;
using ProjetoAula05_c.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05_c.Repository
{
    public class ProdutoRepository
    {
        public void Create(Produtos produto)
        {
            var sql = @"
                INSERT INTO PRODUTOS(
                    IDPRODUTO,
                    NOME,
                    PRECO,
                    QUANTIDADE,
                    DATACADASTRO)
                VALUES(
                    @IdProduto,
                    @Nome,
                    @Preco,
                    @Quantidade,
                    @DataCadastro)
            ";

            using (var connection = new SqlConnection(SqlConfiguration.ConnectionString()))
            {
                connection.Execute(sql, produto);
            }
        }

        public void Update(Produtos produto)
        {
            var sql = @"
                UPDATE PRODUTOS
                SET
                  NOME = @Nome,
                  PRECO = @Preco,
                  QUANTIDADE = @Quantidade
                WHERE
                  IDPRODUTO = @IdProduto
            ";

            using (var connection = new SqlConnection(SqlConfiguration.ConnectionString()))
            {
                connection.Execute(sql, produto);
            }
        }

        public void Delete(Produtos produto)
        {
            var sql = @"
                DELETE FROM PRODUTOS
                WHERE IDPRODUTO = @IdProduto
            ";

            using (var connection = new SqlConnection(SqlConfiguration.ConnectionString()))
            {
                connection.Execute(sql, produto);
            }
        }

        public List<Produtos> GetAll()
        {
            var sql = @"
                SELECT * FROM PRODUTOS
                ORDER BY NOME
            ";

            using (var connection = new SqlConnection(SqlConfiguration.ConnectionString()))
            {
                return connection.Query<Produtos>(sql).ToList();
            }
        }

        public Produtos GetById(Guid IdProduto)
        {
            var sql = @"
                SELECT * FROM PRODUTOS
                WHERE IDPRODUTO = @IdProduto
            ";

            using (var connection = new SqlConnection(SqlConfiguration.ConnectionString()))
            {
                return connection.Query<Produtos>(sql, new { IdProduto }).FirstOrDefault();
            }
        }
    }
}
