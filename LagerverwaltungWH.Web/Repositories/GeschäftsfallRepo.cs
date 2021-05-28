using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using LagerverwaltungWH.Model.ViewModels;
using LagerverwaltungWH.Web.Models;
using LagerverwaltungWH.Web.Repositories.Interfaces;
using System.Data.Entity;
using LagerverwaltungWH.Model.DatabaseModels;

namespace LagerverwaltungWH.Web.Repositories
{
    public class GeschäftsfallRepo : IGeschäftsfallRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public GeschäftsfallRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GeschäftsfallIndexVM>> GetGeschäftsfallInfo(string searching)
        {
            var fall = await (from g in _dbContext.Geschäftsfalle
                        .Include(l => l.Lagerartikel)
                    .Include(lb => lb.Lagerbewegung)
                    .Include(v => v.Vorgangstyp)
                    .Include(m => m.Lagerartikel.Mengeneinheit)
                              select new GeschäftsfallIndexVM
                              {
                                  GeschäftsfallId = g.GeschäftsfallId,
                                  Bezeichnung = g.Lagerartikel.Bezeichnung,
                                  Lagerstand = g.Lagerartikel.Lagerstand,
                                  MengeneinheitBezeichnung = g.Lagerartikel.Mengeneinheit.MengeneinheitBezeichnung
                              })
                .Where(x => x.Bezeichnung.Contains(searching) || searching == null)
                .GroupBy(x => x.LagerartikelId).SelectMany(x => x).ToListAsync();

            return fall;
        }

        public async Task<Geschäftsfall> GetGeschäftsfallById(int? id)
        {
            return await _dbContext.Geschäftsfalle.FindAsync(id);
        }

        public async Task<Lagerartikel> GetAllLagerArtikelById(int? id)
        {
            return await _dbContext.Lagerartikeln.FindAsync(id);
        }

        public async Task<Lagerbewegung> GetAllLagerBewegungById(int? id)
        {
            return await _dbContext.Lagerbewegungen.FindAsync(id);
        }

        public async Task<List<GeschäftsfallListVM>> GetGeschäftsfallList(int? id)
        {
            var list = await (from g in _dbContext.Geschäftsfalle
                        .Include(a => a.Lagerartikel)
                        .Include(l => l.Lagerbewegung)
                        .Include(v => v.Vorgangstyp)
                              select new GeschäftsfallListVM
                              {
                                  LagerartikelId = g.LagerartikelId,
                                  GeschäftsfallId = g.GeschäftsfallId,
                                  Datum = g.Datum,
                                  ErstelltVon = g.ErstelltVon,
                                  GeändertVon = g.GeändertVon,
                                  LB_Menge = g.Lagerbewegung.LB_Menge,
                                  Vorgang = g.Vorgangstyp.Vorgang,
                                  Bezeichnung = g.Lagerartikel.Bezeichnung
                              })
                .Where(x => x.LagerartikelId == id).ToListAsync();

            return list;
        }

        public void InsertGeschäftsfall(Geschäftsfall geschäftsfall)
        {
            _dbContext.Geschäftsfalle.Attach(geschäftsfall);
            _dbContext.Entry(geschäftsfall).State = EntityState.Added;
        }

        public void UpdateGeschäftsfall(Geschäftsfall geschäftsfall)
        {
            _dbContext.Geschäftsfalle.Attach(geschäftsfall);
            _dbContext.Entry(geschäftsfall).State = EntityState.Modified;
        }

        public void DeleteGeschäftsfall(Geschäftsfall geschäftsfall)
        {
            _dbContext.Geschäftsfalle.Attach(geschäftsfall);
            _dbContext.Entry(geschäftsfall).State = EntityState.Deleted;
        }

        public async Task<IEnumerable> DropdownLagerartikel()
        {
            var lagerartikel = await (from l in _dbContext.Lagerartikeln
                                      orderby l.Bezeichnung
                                      select new SelectItemListVM
                                      {
                                          ValueMember = l.LagerartikelId.ToString(),
                                          DisplayMember = l.Bezeichnung.ToString()
                                      }).ToListAsync();

            return lagerartikel;
        }

        public async Task<IEnumerable> DropdownVorgang()
        {
            var lagerartikel = await (from v in _dbContext.Vorgangstypen
                                      orderby v.Vorgang
                                      select new SelectItemListVM
                                      {
                                          ValueMember = v.VorgangsId.ToString(),
                                          DisplayMember = v.Vorgang.ToString()
                                      }).ToListAsync();

            return lagerartikel;
        }

        public async Task<IEnumerable> DropdownLagerbewegung()
        {
            var lagerartikel = await (from l in _dbContext.Lagerbewegungen
                                      orderby l.LB_Menge
                                      select new SelectItemListVM
                                      {
                                          ValueMember = l.LagerbewegungsId.ToString(),
                                          DisplayMember = l.LB_Menge.ToString()
                                      }).ToListAsync();

            return lagerartikel;
        }
    }
}