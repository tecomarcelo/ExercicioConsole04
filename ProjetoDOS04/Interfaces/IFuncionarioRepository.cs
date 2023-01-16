using ProjetoDOS04.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDOS04.Interfaces
{
    public interface IFuncionarioRepository : IbaseRepository<Funcionario>
    {
        List<Funcionario> GetByNome(string nome);
    }
}
