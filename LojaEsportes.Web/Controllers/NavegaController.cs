using LojaEsportes.Dominio.Entidades;
using LojaEsportes.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaEsportes.Web.Controllers
{
    public class NavegaController : Controller
    {
        private IRepositorio<Categoria> _categoriaRepositorio;
     
        public NavegaController()
        {
            _categoriaRepositorio = new CategoriaRepositorio(new ProdutoContexto());
        }

        public ActionResult Menu()
        {
            var categorias = _categoriaRepositorio.GetTodos();
            return PartialView(categorias);
        }
    }
}