using ProjetoAula05_c.Controllers;

namespace PorjetoAula05_c
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var produtoController = new ProdutoController();

            try
            {
                Console.WriteLine("\n\t(1) Cadatrar Produto");
                Console.WriteLine("\t(2) Alterar Produto");
                Console.WriteLine("\t(3) Excluir Produto");
                Console.WriteLine("\t(4) Listar Produto");

                Console.Write("\nInforme a opção desejada: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        produtoController.CadastrarProduto();
                        break;

                    case 2:
                        produtoController.AtualizarProduto();
                        break;

                    case 3:
                        produtoController.ApagarProduto();
                        break;

                    case 4:
                        produtoController.ConsultarProduto();
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");
                        break;
                }

                Console.Write("\nDeseja continuar: (S/N)...: ");
                var escolha = Console.ReadLine();

                if (escolha == "S")
                {
                    Console.Clear();//limpar a tela do console
                    Main(args);//recurcividade
                }
                else
                {
                    Console.WriteLine("\nFIM DO PROGRAMA!");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
    }
}