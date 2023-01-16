using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDOS04.Interfaces
{
    /// <summary>
    /// Interface generica para definição dos metodos do repositorio
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IbaseRepository<T>
        where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);

        List<T> GetAll();
        T GetById(Guid id);
    }
}
