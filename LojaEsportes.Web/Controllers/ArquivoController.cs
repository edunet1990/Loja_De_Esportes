using LojaEsportes.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaEsportes.Web.Controllers
{
    public class ArquivoController : Controller
    {
        // GET: Arquivo
        public ActionResult ExibirImagem(int id)
        {
            using (ProdutoContexto db = new ProdutoContexto())
            {
                var arquivoRetorno = db.Produtos.Find(id);
                return File(arquivoRetorno.Imagem, arquivoRetorno.ImagemTipo);
            }
        }
    }
}