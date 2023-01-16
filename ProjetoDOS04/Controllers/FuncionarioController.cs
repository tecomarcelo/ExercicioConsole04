using ProjetoDOS04.Entities;
using ProjetoDOS04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDOS04.Controllers
{
    /// <summary>
    /// Classe de controle de aplicação para eventos do funcionario
    /// </summary>
    public class FuncionarioController
    {
        /// <summary>
        /// Metodo para gerar a interface de funcionarios do projeto
        /// </summary>
        public void ControleFuncionarios()
        {
            try
            {
                Console.WriteLine("\n ###   CONTROLE DE FUNCIONÁRIOS   ###\n");
                Console.WriteLine("(1) - CADASTRAR FUNCIONÁRIO");
                Console.WriteLine("(2) - ATUALIZAR FUNCIONÁRIO");
                Console.WriteLine("(3) - EXCLUIR FUNCIONÁRIO");
                Console.WriteLine("(4) - CONSULTAR TODOS OS FUNCIONÁRIOS");
                Console.WriteLine("(5) - CONSULTAR FUNCIONÁRIOS POR NOME");
                Console.WriteLine("\n--");

                Console.WriteLine("Informe a ação desejada.....: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: CadastrarFuncionario();
                        break;

                    case 2: AtualizarFuncionario();
                        break;

                    case 3: ExcluirFuncionario();
                        break;

                    case 4: ConsultarFuncionarios();
                        break;

                    case 5: ConsultarFuncionarioPorNome();
                        break;

                    default:
                        throw new Exception("\nOpção invalida.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nErro: {e.Message}");
            }
            finally
            {               
                Console.WriteLine($"\nDeseja continuar? (S,N): ");
                var opcao = Console.ReadLine();

                if (opcao.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    Console.Clear(); //limpa console
                    ControleFuncionarios(); //recursividade
                }
                else
                    Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }

        //Metodo privado para fazer o fluxo de cadastro do cliente
        private void CadastrarFuncionario()
        {
            var funcionario = new Funcionario();

            Console.WriteLine("\nCADASTRO DE FUNCIONARIO\n");

            Console.Write("ENTRE COM O NOME DO FUNCIONARIO.......: ");
            funcionario.Nome = Console.ReadLine();

            Console.Write("ENTRE COM A MATRICULA DO FUNCIONARIO..: ");
            funcionario.Matricula = Console.ReadLine();

            Console.Write("ENTRE COM O CPF DO FUNCIONARIO........: ");
            funcionario.Cpf = Console.ReadLine();

            var funcionarioRepository = new FuncionarioRepository();
            funcionarioRepository.Create(funcionario);

            Console.WriteLine("\nFUNCIONARIO CADASTRADO COM SUCESSO!\n");
        }

        //Metodo privado para fazer o fluxo de atualizar o funcionario
        private void AtualizarFuncionario()
        {
            Console.WriteLine("\nATUALIZAR FUNCIONARIO\n");

            Console.Write("ENTRE COM O ID DO FUNCIONARIO..............: ");
            var id = Guid.Parse(Console.ReadLine());

            //buscar o funcionario no banco de dados com ID informado
            var funcionarioRepository = new FuncionarioRepository();
            var funcionario = funcionarioRepository.GetById(id);

            //verificar se o funcionario foi encontrado
            if(funcionario != null)
            {
                Console.Write("ENTRE COM O NOME DO FUNCIONARIO........: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("ENTRE COM A MATRICULA DO FUNCIONARIO...: ");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("ENTRE COM O CPF DO FUNCIONARIO.........: ");
                funcionario.Cpf = Console.ReadLine();

                funcionarioRepository.Update(funcionario);
                Console.WriteLine("\n\nFUNCIONÁRIO ATUALIZADO COM SUCESSO!\n");
            }
            else
            {
                throw new Exception("Cliente não foi encontrado.");
            }
        }

        //Metodo privado para fazer o fluxo de excluir o funcionario
        private void ExcluirFuncionario()
        {
            Console.WriteLine("\nEXCLUSÃO DE FUNCIONÁRIO\n");

            Console.Write("ENTRE COM O ID DO FUNCIONÁRIO.............:");
            var id = Guid.Parse(Console.ReadLine());

            //buscar o funcionario no banco de dados com ID informado
            var funcionarioRepository = new FuncionarioRepository();
            var funcionario = funcionarioRepository.GetById(id);

            //verificar se o funcionario foi encontrado
            if (funcionario != null)
            {
                funcionarioRepository.Delete(funcionario);
                Console.WriteLine("\n\nFUNCIONÁRIO EXCLUIDO COM SUCESSO!\n");
            }
            else
            {
                throw new Exception("Funcionário não foi encontrado.");
            }
        }

        //metodo privado para fazer o fluxo de consulta de funcionario.
        public static string FormatCPF(string Cpf)
        {
            return Convert.ToUInt64(Cpf).ToString(@"000\.000\.000\-00");
        }

        private void ConsultarFuncionarios()
        {
            Console.WriteLine("\nCONSULTA DE FUNCIONÁRIOS\n");

            var funcionarioRepository = new FuncionarioRepository();

            foreach (var item in funcionarioRepository.GetAll())
            {
                Console.WriteLine($"ID..............................: {item.Id}");
                Console.WriteLine($"NOME DO FUNCIONÁRIO.............: {item.Nome}");
                Console.WriteLine($"MATRICULA.......................: {Convert.ToUInt64(item.Matricula).ToString(@"000\-000")}");
                Console.WriteLine($"CPF.............................: {Convert.ToUInt64(item.Cpf).ToString(@"000\.000\.000\-00")}");
                Console.WriteLine("..........");
            }
        }

        //metodo privado para fazer o fluxo de consulta de funcionário por nome
        private void ConsultarFuncionarioPorNome()
        {
            Console.WriteLine("\nCONSULTA DE FUNCIONÁRIOS POR NOME\n");

            Console.Write("ENTRE COM O NOME DO FUNCIONARIO..........: ");
            var nome = Console.ReadLine();

            var funcionarioRepository = new FuncionarioRepository();

            foreach (var item in funcionarioRepository.GetByNome(nome))
            {
                Console.WriteLine($"ID..............................: {item.Id}");
                Console.WriteLine($"NOME DO FUNCIONÁRIO.............: {item.Nome}");
                Console.WriteLine($"MATRICULA.......................: {Convert.ToUInt64(item.Matricula).ToString(@"000\-000")}");
                Console.WriteLine($"CPF.............................: {Convert.ToUInt64(item.Cpf).ToString(@"000\.000\.000\-00")}");
                Console.WriteLine("..........");
            }
        }
    }
}
