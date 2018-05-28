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
    public class KrvnaGrupaController : Controller
    {
        //
        // GET: /ModulAdministracija/KrvnaGrupa/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<KrvnaGrupaIndexVM.KrvnaGrupaInfo> Krv = ctx.KrvnaGrupas.Select(x => new KrvnaGrupaIndexVM.KrvnaGrupaInfo
            {
                Id = x.Id,
                Naziv = x.Naziv,
                RHFaktor = x.RHFaktor,
                Valid = x.Valid
            }).ToList();

            KrvnaGrupaIndexVM Model = new KrvnaGrupaIndexVM
            {
                 KrvnaLista=Krv
            };
            return View("Index",Model);
        }
        public ActionResult Dodaj()
        {
            KrvnaGrupaUrediVM Model = new KrvnaGrupaUrediVM();
            Model.Valid = true;

            return View("Uredi", Model);
        }
        public ActionResult Uredi(int krvId)
        {
            KrvnaGrupa entity = ctx.KrvnaGrupas.Find(krvId);
            KrvnaGrupaUrediVM Model = new KrvnaGrupaUrediVM();
            Model.Id = entity.Id;
            Model.Naziv = entity.Naziv;
            Model.RHFaktor = entity.RHFaktor;
            Model.Valid = entity.Valid;

            return View("Uredi", Model);
        }
        public ActionResult Snimi(KrvnaGrupaUrediVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", vm);
            }
            KrvnaGrupa entity;

            if (vm == null || vm.Id == 0)
            {
                entity = new KrvnaGrupa();
                ctx.KrvnaGrupas.Add(entity);
            }
            else
            {
                entity = ctx.KrvnaGrupas.Find(vm.Id);
            }
            entity.Id = vm.Id;
            entity.Naziv = vm.Naziv;
            entity.RHFaktor = vm.RHFaktor;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Obrisi(int krvId)
        {
            KrvnaGrupa entity = ctx.KrvnaGrupas.Find(krvId);
            ctx.KrvnaGrupas.Remove(entity);

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}