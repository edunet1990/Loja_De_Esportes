using LojaEsportes.Dominio.Entidades;
using LojaEsportes.Web.Seguranca;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LojaEsportes.Web.Controllers
{
    //[PermissaoFiltro(Roles="Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        private ProdutoContexto db = new ProdutoContexto();

        public ActionResult MenuAdmin()
        {
            return View();
        }

        // GET: Admin
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(produtos.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoId,Nome,Descricao,Preco,Imagem,ImagemTipo,CategoriaId")] Produto produto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var arqImagem = new Produto
                    {
                        ImagemTipo = upload.ContentType
                    };
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arqImagem.Imagem = reader.ReadBytes(upload.ContentLength);
                    }
                    produto.Imagem = arqImagem.Imagem;
                    produto.ImagemTipo = arqImagem.ImagemTipo;
                }
                db.Produtos.Add(produto);
                db.SaveChanges();
                 TempData["mensagem"] = string.Format("{0}  : foi incluído com sucesso", produto.Nome);
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome", produto.CategoriaId);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoId,Nome,Descricao,Preco,Imagem,ImagemTipo,CategoriaId")] Produto produto, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var arqImagem = new Produto
                    {
                        ImagemTipo = upload.ContentType
                    };
                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        arqImagem.Imagem = reader.ReadBytes(upload.ContentLength);
                    }
                    produto.Imagem = arqImagem.Imagem;
                    produto.ImagemTipo = arqImagem.ImagemTipo;
                }
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                TempData["mensagem"] = string.Format("{0}  : foi atualizado com sucesso", produto.Nome);
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(db.Categoria, "CategoriaId", "Nome", produto.CategoriaId);
            return View(produto);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            TempData["mensagem"] = string.Format("{0}  : foi excluído com sucesso", produto.Nome);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
