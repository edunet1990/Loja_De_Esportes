using LojaEsportes.Dominio.Entidades;
using LojaEsportes.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace LojaEsportes.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IRepositorio<Produto> _repositorioProduto;

        public ProdutoController()
        {
            _repositorioProduto = new ProdutoRepositorio(new ProdutoContexto());
        }

        public ViewResult Catalogo(int? pag, int? cat)
        {
            //ViewBag.Cat = cat;

            if (cat == null)
            {
                return View(_repositorioProduto.GetTodos().ToPagedList(pag ?? 1, 2));
            }
            else
            {
                return View(_repositorioProduto.Get(cat).ToPagedList(pag ?? 1, 2));
            }
        }
    }
}