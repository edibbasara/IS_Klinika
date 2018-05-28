using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessKlinika.DAL;
using DataAccessKlinika.Model;
using IS_Klinika.Areas.ModulAdministracija.Models;

namespace IS_Klinika.Areas.ModulAdministracija.Controllers
{
    public class DoprinosiController : Controller
    {
        //
        // GET: /ModulAdministracija/Doprinosi/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<DoprinosiIndexVM.DoprinosiInfo> DopLista = ctx.Doprinosis.Select(x => new DoprinosiIndexVM.DoprinosiInfo
            {
                 Id=x.Id,
                 Valid=x.Valid,
                 NazivPlana=x.NazivPlana,
                 PIOnaPlatu = x.PIOnaPlatu,
                 ZdravNaPlatu = x.ZdravNaPlatu,
                 NezapFedNaPlatu = x.NezapFedNaPlatu,
                 NezapKanNaPlatu = x.NezapKanNaPlatu,
                 ZdravSolidNaPlatu = x.ZdravSolidNaPlatu,
                 ZastitaOdPrirNepNaPlatu =x.ZastitaOdPrirNepNaPlatu,
                 PIOizPlate = x.PIOizPlate,
                 ZdravIzPlate = x.ZdravIzPlate,
                 NezapFedIzPlate = x.NezapFedIzPlate,
                 NezapKanIzPlate = x.NezapKanIzPlate,
                 ZdravSolidIzPlate = x.ZdravSolidIzPlate,
                 PorezNaPlatuOsnov = x.PorezNaPlatuOsnov,
                 PoreznaPlatu = x.PoreznaPlatu
            }).ToList();

            DoprinosiIndexVM Model = new DoprinosiIndexVM
            {
                DoprinosiLista = DopLista
            };

            return View("Index", Model);
        }

        public ActionResult Dodaj()
        {
            DoprinosiIndexVM.DoprinosiInfo Model = new DoprinosiIndexVM.DoprinosiInfo();
            Model.Valid = true;

            return View("Uredi", Model);
        }
        public ActionResult Uredi(int doprinosId)
        {
            Doprinosi entity = ctx.Doprinosis.Find(doprinosId);

            DoprinosiIndexVM.DoprinosiInfo Model = new DoprinosiIndexVM.DoprinosiInfo();
            Model.Id=entity.Id;
            Model.NazivPlana=entity.NazivPlana;
            Model.Valid=entity.Valid;
            Model.PIOnaPlatu=entity.PIOnaPlatu;
            Model.ZdravNaPlatu=entity.ZdravNaPlatu;
            Model.NezapFedNaPlatu = entity.NezapFedNaPlatu;
            Model.NezapKanNaPlatu = entity.NezapKanNaPlatu;
            Model.ZdravSolidNaPlatu=entity.ZdravSolidNaPlatu;
            Model.ZastitaOdPrirNepNaPlatu =entity.ZastitaOdPrirNepNaPlatu;
            Model.PIOizPlate=entity.PIOizPlate;
            Model.ZdravIzPlate = entity.ZdravIzPlate;
            Model.NezapFedIzPlate =entity.NezapFedIzPlate;
            Model.NezapKanIzPlate = entity.NezapKanIzPlate;
            Model.ZdravSolidIzPlate = entity.ZdravSolidIzPlate;
            Model.PoreznaPlatu = entity.PoreznaPlatu;
            Model.PorezNaPlatuOsnov = entity.PorezNaPlatuOsnov;

            return View("Uredi", Model);
        }
        public ActionResult Snimi(DoprinosiIndexVM.DoprinosiInfo d)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", d);
            }

            Doprinosi entity;
            if (d == null || d.Id == 0)
            {
                entity = new Doprinosi();
                ctx.Doprinosis.Add(entity);
            }
            else
            {
                entity = ctx.Doprinosis.Find(d.Id);
            }

            entity.Id = d.Id;
            entity.NazivPlana = d.NazivPlana;
            entity.Valid = d.Valid;
            entity.PIOnaPlatu = d.PIOnaPlatu;
            entity.ZdravNaPlatu = d.ZdravNaPlatu;
            entity.NezapFedNaPlatu = d.NezapFedNaPlatu;
            entity.NezapKanNaPlatu = d.NezapKanNaPlatu;
            entity.ZdravSolidNaPlatu = d.ZdravSolidNaPlatu;
            entity.ZastitaOdPrirNepNaPlatu = d.ZastitaOdPrirNepNaPlatu;
            entity.PIOizPlate = d.PIOizPlate;
            entity.ZdravIzPlate = d.ZdravIzPlate;
            entity.NezapFedIzPlate = d.NezapFedIzPlate;
            entity.NezapKanIzPlate = d.NezapKanIzPlate;
            entity.ZdravSolidIzPlate = d.ZdravSolidIzPlate;
            entity.PoreznaPlatu = d.PoreznaPlatu;
            entity.PorezNaPlatuOsnov = d.PorezNaPlatuOsnov;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Obrisi(int doprinosId)
        {
            Doprinosi entity = ctx.Doprinosis.Find(doprinosId);
            ctx.Doprinosis.Remove(entity);

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}