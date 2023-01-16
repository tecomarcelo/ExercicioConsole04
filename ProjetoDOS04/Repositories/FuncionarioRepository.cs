using Dapper;
using ProjetoDOS04.Entities;
using ProjetoDOS04.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDOS04.Repositories
{
    /// <summary>
    /// Classe para implementar o repositorio do funcionario
    /// </summary>
    public class FuncionarioRepository : IFuncionarioRepository
    {
        //atributo para armazenar a connectionstring do banco de dados.
        private readonly string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = DBEXFuncionarios; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void Create(Funcionario obj)
        {
            //conectando na base de dados
            using (var connection = new SqlConnection(_connectionString))
            {
                //executar a procedure para cadastro do funcionario
                connection.Execute("SP_INSERIRFUNCIONARIO", new
                {
                    @NOME = obj.Nome,
                    @MATRICULA = obj.Matricula,
                    @CPF = obj.Cpf
                },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Update(Funcionario obj)
        {
            //conectando na base de dados
            using (var connection = new SqlConnection(_connectionString))
            {
                //executar a procedure para atualizar do funcionario
                connection.Execute("SP_ATUALIZARFUNCIONARIO", new
                {
                    @ID = obj.Id,
                    @NOME = obj.Nome,
                    @MATRICULA = obj.Matricula,
                    @CPF = obj.Cpf
                },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void Delete(Funcionario obj)
        {
            //conectando na base de dados
            using (var connection = new SqlConnection(_connectionString))
            {
                //executar a procedure para excluir o funcionario
                connection.Execute("SP_EXCLUIRFUNCIONARIO", new
                {
                    @ID = obj.Id
                },
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public List<Funcionario> GetAll()
        {
            var sql = @"
                    SELECT * FROM FUNCIONARIO
                    ORDER BY NOME ASC
                ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .Query<Funcionario>(sql)
                    .ToList();
            }
        }

        public Funcionario GetById(Guid id)
        {
            var sql = @"
                    SELECT * FROM FUNCIONARIO
                    WHERE ID = @PARAM
                ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .Query<Funcionario>(sql, new { @PARAM = id })
                    .FirstOrDefault();
            }
        }

        public List<Funcionario> GetByNome(string nome)
        {
            var sql = @"
                    SELECT * FROM FUNCIONARIO
                    WHERE NOME LIKE @PARAM
                    ORDER BY NOME ASC
                ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection
                    .Query<Funcionario>(sql, new { @PARAM = $"%{nome}%" })
                    .ToList();
            }
        }
    }
}
