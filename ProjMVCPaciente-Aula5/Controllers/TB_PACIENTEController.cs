using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjMVCPaciente_Aula5;

namespace ProjMVCPaciente_Aula5.Controllers
{
    public class TB_PACIENTEController : Controller
    {
        private PacienteDBEntities db = new PacienteDBEntities();

        // GET: TB_PACIENTE
        public ActionResult Index()
        {
            return View(db.TB_PACIENTE.ToList());
        }

        // GET: TB_PACIENTE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PACIENTE tB_PACIENTE = db.TB_PACIENTE.Find(id);
            if (tB_PACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_PACIENTE);
        }

        // GET: TB_PACIENTE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TB_PACIENTE/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Telefone,Email,NomePai,NomeMae")] TB_PACIENTE tB_PACIENTE)
        {
            if (ModelState.IsValid)
            {
                db.TB_PACIENTE.Add(tB_PACIENTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tB_PACIENTE);
        }

        // GET: TB_PACIENTE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PACIENTE tB_PACIENTE = db.TB_PACIENTE.Find(id);
            if (tB_PACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_PACIENTE);
        }

        // POST: TB_PACIENTE/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Telefone,Email,NomePai,NomeMae")] TB_PACIENTE tB_PACIENTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tB_PACIENTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tB_PACIENTE);
        }

        // GET: TB_PACIENTE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_PACIENTE tB_PACIENTE = db.TB_PACIENTE.Find(id);
            if (tB_PACIENTE == null)
            {
                return HttpNotFound();
            }
            return View(tB_PACIENTE);
        }

        // POST: TB_PACIENTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TB_PACIENTE tB_PACIENTE = db.TB_PACIENTE.Find(id);
            db.TB_PACIENTE.Remove(tB_PACIENTE);
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
