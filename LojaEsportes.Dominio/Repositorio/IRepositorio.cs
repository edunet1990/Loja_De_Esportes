using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEsportes.Dominio.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> GetTodos();
        IEnumerable<T> Get(int? id);
    }
}
