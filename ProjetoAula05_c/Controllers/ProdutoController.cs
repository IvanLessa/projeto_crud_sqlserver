using ProjetoAula05_c.Entities;
using ProjetoAula05_c.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula05_c.Controllers
{
    public class ProdutoController
    {
        public void CadastrarProduto()
        {
            try
            {
                Console.WriteLine("CADASTRO DE PRODUTOS\n");

                var cadastroProduto = new Produtos();

                cadastroProduto.IdProduto = Guid.NewGuid();
                cadastroProduto.DataCadastro = DateTime.Now;

                Console.Write("Informe o nnome do produto.........: ");
                cadastroProduto.Nome = Console.ReadLine();

                Console.Write("Informe o preço do produto.........: ");
                cadastroProduto.Preco = decimal.Parse(Console.ReadLine());

                Console.Write("Informe a quantidade do produto....: ");
                cadastroProduto.Quantidade = int.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                produtoRepository.Create(cadastroProduto);

                Console.WriteLine
                ("\nPRODUTO CADASTRADO COM SUCESSO NO BANCO DE DADOS!");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao cadastrar produto: {e.Message} ");
            }


        }

        public void AtualizarProduto()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÃO DE PRODUTO\n");

                Console.Write("Informe o ID do produto..........: ");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(idProduto);

                if (produto != null)
                {
                    Console.Write("Informe o novo nome do produto.........:");
                    produto.Nome = Console.ReadLine();
                    
                    Console.Write("Informe o novo preço do produto........:");
                    produto.Preco = decimal.Parse(Console.ReadLine());
                    
                    Console.Write("Informe a nova quantidade do produto...:");
                    produto.Quantidade = int.Parse(Console.ReadLine());
                    
                    produtoRepository.Update(produto);

                    Console.WriteLine("\nPRODUTO ATUALIZADO COM SUCESSSO NO BANCO DE DADOS\n");

                }
                else
                {
                    Console.WriteLine("Produto não cadastrado!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Falha ao atualiazr produto: {e.Message}");
            }
        }

        public void ApagarProduto()
        {
            try
            {

                Console.WriteLine("\nEXCLUSÃO DE PRODUTO\n");

                Console.Write("Informe o ID do produto que será excluído..........: ");
                var idProduto = Guid.Parse(Console.ReadLine());

                var produtoRepository = new ProdutoRepository();
                var produto = produtoRepository.GetById(idProduto);

                if (produto != null) 
                {
                    produtoRepository.Delete(produto);
                }
                else
                {
                    Console.WriteLine("Produto não cadastrado!");
                }

                produtoRepository.Update(produto);
                Console.WriteLine("\nPRODUTO EXCLUÍDO COM SUCESSSO NO BANCO DE DADOS\n");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Produto não encontrado: {e.Message}");
            }
        }
        public void ConsultarProduto()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE PRODUTOS\n");

                var produtoRepository = new ProdutoRepository();
                var produtos = produtoRepository.GetAll();

                foreach (var item in produtos)
                {
                    Console.WriteLine($"Id do Produto.............: {item.IdProduto}");
                    Console.WriteLine($"Data/Hora de cadastro.....: {item.DataCadastro}");
                    Console.WriteLine($"Nome do Produto...........: {item.Nome}");
                    Console.WriteLine($"Quantidade do Produto.....: {item.Quantidade}");
                    Console.WriteLine($"Preço do Produto..........: {item.Preco}");
                    Console.WriteLine($".....");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Produto não encontrado: {e.Message}");
            }
        }
    }
}
