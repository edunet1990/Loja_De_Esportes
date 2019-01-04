using LojaEsportes.Dominio.Entidades;
using LojaEsportes.Dominio.Repositorio;
using LojaEsportes.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaEsportes.Web.Controllers
{
    [HandleError(ExceptionType = typeof(Exception), View = "_Erro")]
    public class CarrinhoController : Controller
    {
        private IRepositorio<Produto> _produtoRepositorio;
        private IProcessarPedido _processarPedido;

        public CarrinhoController()
        {
            _produtoRepositorio = new ProdutoRepositorio(new ProdutoContexto());
            _processarPedido = new EnviarEmailPedido();
        }

        // GET: Carrinho
        public ActionResult Index(string ReturnUrl)
        {
            return View(new CarrinhoViewModel { Carrinho = GetCarrinho(), ReturnUrl = ReturnUrl });
        }

        public  ActionResult ResumoCarrinho(Carrinho _carrinho)
        {
            _carrinho = GetCarrinho();
            return PartialView(_carrinho);
        }

        //GET
        public ViewResult Checkout()
        {
            return View(new Despacho { Carrinho = GetCarrinho() });
        }

        [HttpPost]
        public ViewResult Checkout(Carrinho carrinho, Despacho despacho)
        {
            carrinho = GetCarrinho();

            if (carrinho.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Seu carrinho esta vazio !");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _processarPedido.ProcessarPedido(carrinho, despacho);
                    carrinho.LimparCarrinho();
                    return View("PedidoConcluido");
                }
                catch (Exception ex)
                {
                    return View("_Erro", new HandleErrorInfo(ex, "CheckOut", "Carrinho"));
                }
            }
            else
            {
                return View(despacho);
            }
        }


        public RedirectToRouteResult AdicionarItemAoCarrinho(int ProdutoId,string ReturnUrl)
        {
            Produto _produto = _produtoRepositorio.GetTodos().FirstOrDefault(p => p.ProdutoId == ProdutoId);

            if (_produto != null)
            {
                GetCarrinho().AdicionarItem(_produto, 1);
            }
            return RedirectToAction("Index", new { ReturnUrl });
        }

        public RedirectToRouteResult RemoverItemDoCarrinho(int ProdutoId,string ReturnUrl)
        {
            Produto _produto = _produtoRepositorio.GetTodos().FirstOrDefault(p => p.ProdutoId == ProdutoId);

            if (_produto != null)
            {
                GetCarrinho().RemoverItem(_produto);
            }
            return RedirectToAction("Index", new { ReturnUrl });
        }

        private Carrinho GetCarrinho()
        {
            Carrinho _carrinho = (Carrinho)Session["Carrinho"];

            if (_carrinho == null)
            {
                _carrinho = new Carrinho();
                Session["Carrinho"] = _carrinho;
            }
            return _carrinho;
        }
    }
}