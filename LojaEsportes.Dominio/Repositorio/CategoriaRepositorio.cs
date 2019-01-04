using LojaEsportes.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEsportes.Dominio.Repositorio
{
    public class CategoriaRepositorio : IRepositorio<Categoria>
    {
        private ProdutoContexto context;

        public CategoriaRepositorio(ProdutoContexto produtoContexto)
        {
            this.context = produtoContexto;
        }

        //todas as categorias
        public IEnumerable<Categoria> GetTodos()
        {
            return context.Categoria.OrderBy(c => c.Nome);
        }

        //retorna uma categoria pelo codigo
        public IEnumerable<Categoria> Get(int? id)
        {
            return context.Categoria.Where(c => c.CategoriaId == id);
        }
    }
}
