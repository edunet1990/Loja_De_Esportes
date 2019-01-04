using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LojaEsportes.Dominio.Entidades;

namespace LojaEsportes.Web.Controllers
{
     [Authorize(Users = "admin")]
    public class PermissaoController : Controller
    {
        private ProdutoContexto db = new ProdutoContexto();

        // GET: Permissao
        public ActionResult Index()
        {
            return View(db.Permissoes.ToList());
        }

        // GET: Permissao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissao permissao = db.Permissoes.Find(id);
            if (permissao == null)
            {
                return HttpNotFound();
            }
            return View(permissao);
        }

        // GET: Permissao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Permissao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PermissaoId,Nome")] Permissao permissao)
        {
            if (ModelState.IsValid)
            {
                db.Permissoes.Add(permissao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(permissao);
        }

        // GET: Permissao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissao permissao = db.Permissoes.Find(id);
            if (permissao == null)
            {
                return HttpNotFound();
            }
            return View(permissao);
        }

        // POST: Permissao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PermissaoId,Nome")] Permissao permissao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permissao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(permissao);
        }

        // GET: Permissao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissao permissao = db.Permissoes.Find(id);
            if (permissao == null)
            {
                return HttpNotFound();
            }
            return View(permissao);
        }

        // POST: Permissao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Permissao permissao = db.Permissoes.Find(id);
            db.Permissoes.Remove(permissao);
            db.SaveChanges();
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
