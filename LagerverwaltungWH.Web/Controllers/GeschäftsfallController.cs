using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LagerverwaltungWH.Model.DatabaseModels;
using LagerverwaltungWH.Model.ViewModels;
using LagerverwaltungWH.Web.Models;

namespace LagerverwaltungWH.Web.Controllers
{
    public class GeschäftsfallController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly UnitOfWork uow = new UnitOfWork();

        // GET: Geschäftsfall
        public async Task<ActionResult> Index(string searching)
        {
            var fall = await (uow.GeschäftsfallRepo.GetGeschäftsfallInfo(searching));
            return View(fall);
        }

        // GET: Geschäftsfall/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var geschäftsfallTemp = await uow.GeschäftsfallRepo.GetGeschäftsfallById(id);
            var artkelId = geschäftsfallTemp.LagerartikelId;
            List<GeschäftsfallListVM> geschäftsfall = await uow.GeschäftsfallRepo.GetGeschäftsfallList(artkelId);
            if (geschäftsfall == null)
            {
                return HttpNotFound();
            }
            return View(geschäftsfall);
        }

        // GET: Geschäftsfall/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.LagerartikelId = new SelectList(await uow.GeschäftsfallRepo.DropdownLagerartikel(), "ValueMember", "DisplayMember");
            ViewBag.VorgangsId = new SelectList(await uow.GeschäftsfallRepo.DropdownVorgang(), "ValueMember", "DisplayMember");
            ViewBag.LagerbewegungsId = new SelectList(await uow.GeschäftsfallRepo.DropdownLagerbewegung(), "ValueMember", "DisplayMember");
            return View();
        }

        // POST: Geschäftsfall/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "GeschäftsfallId,Datum,ErstelltVon,GeändertVon,LagerartikelId,LagerbewegungsId,VorgangsId")] Geschäftsfall geschäftsfall)
        {
            if (ModelState.IsValid)
            {
                var vorgang = await uow.GeschäftsfallRepo.GetAllLagerArtikelById(geschäftsfall.LagerartikelId);
                var bewegung = await uow.GeschäftsfallRepo.GetAllLagerBewegungById(geschäftsfall.LagerbewegungsId);
                
                if (geschäftsfall.VorgangsId == 1)
                {
                    vorgang.Lagerstand += bewegung.LB_Menge;
                }
                else
                {
                    vorgang.Lagerstand -= bewegung.LB_Menge;
                }
                
                var mitarbeiter = User.Identity.Name;
                geschäftsfall.ErstelltVon = mitarbeiter;
                
                uow.GeschäftsfallRepo.InsertGeschäftsfall(geschäftsfall);
                await uow.CommitAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LagerartikelId = new SelectList(await uow.GeschäftsfallRepo.DropdownLagerartikel(), "ValueMember", "DisplayMember", geschäftsfall.LagerartikelId);
            ViewBag.VorgangsId = new SelectList(await uow.GeschäftsfallRepo.DropdownVorgang(), "ValueMember", "DisplayMember", geschäftsfall.VorgangsId);
            ViewBag.LagerbewegungsId = new SelectList(await uow.GeschäftsfallRepo.DropdownLagerbewegung(), "ValueMember", "DisplayMember", geschäftsfall.LagerbewegungsId);
            return View(geschäftsfall);
        }

        // GET: Geschäftsfall/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Geschäftsfall geschäftsfall = await uow.GeschäftsfallRepo.GetGeschäftsfallById(id);
            if (geschäftsfall == null)
            {
                return HttpNotFound();
            }
            ViewBag.LagerartikelId = new SelectList(await uow.GeschäftsfallRepo.DropdownLagerartikel(), "ValueMember", "DisplayMember", geschäftsfall.LagerartikelId);
            ViewBag.VorgangsId = new SelectList(await uow.GeschäftsfallRepo.DropdownVorgang(), "ValueMember", "DisplayMember", geschäftsfall.VorgangsId);
            ViewBag.LagerbewegungsId = new SelectList(await uow.GeschäftsfallRepo.DropdownLagerbewegung(), "ValueMember", "DisplayMember", geschäftsfall.LagerbewegungsId);
            return View(geschäftsfall);
        }

        // POST: Geschäftsfall/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "GeschäftsfallId,Datum,ErstelltVon,GeändertVon,LagerartikelId,LagerbewegungsId,VorgangsId")] Geschäftsfall geschäftsfall)
        {
            if (ModelState.IsValid)
            {
                var mitarbeiter = User.Identity.Name;
                geschäftsfall.GeändertVon = mitarbeiter;
                
                uow.GeschäftsfallRepo.UpdateGeschäftsfall(geschäftsfall);
                await uow.CommitAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LagerartikelId = new SelectList(await uow.GeschäftsfallRepo.DropdownLagerartikel(), "ValueMember", "DisplayMember", geschäftsfall.LagerartikelId);
            ViewBag.VorgangsId = new SelectList(await uow.GeschäftsfallRepo.DropdownVorgang(), "ValueMember", "DisplayMember", geschäftsfall.VorgangsId);
            ViewBag.LagerbewegungsId = new SelectList(await uow.GeschäftsfallRepo.DropdownLagerbewegung(), "ValueMember", "DisplayMember", geschäftsfall.LagerbewegungsId);
            return View(geschäftsfall);
        }

        // GET: Geschäftsfall/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Geschäftsfall geschäftsfall = await uow.GeschäftsfallRepo.GetGeschäftsfallById(id);
            if (geschäftsfall == null)
            {
                return HttpNotFound();
            }
            return View(geschäftsfall);
        }

        // POST: Geschäftsfall/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Geschäftsfall geschäftsfall = await uow.GeschäftsfallRepo.GetGeschäftsfallById(id);
            uow.GeschäftsfallRepo.DeleteGeschäftsfall(geschäftsfall);
            await uow.CommitAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
