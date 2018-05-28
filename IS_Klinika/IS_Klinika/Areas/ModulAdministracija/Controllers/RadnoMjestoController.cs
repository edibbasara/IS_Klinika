using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessKlinika.Model;
using DataAccessKlinika.DAL;
using IS_Klinika.Areas.ModulAdministracija.Models;

namespace IS_Klinika.Areas.ModulAdministracija.Controllers
{
    public class RadnoMjestoController : Controller
    {
        //
        // GET: /ModulAdministracija/RadnoMjesto/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<RadnoMjestoIndexVM.RadnoMjestoInfo> RadnaMjesta = ctx.RadnoMjestos.Select(x => new RadnoMjestoIndexVM.RadnoMjestoInfo
            {
                Id = x.Id,
                Sifra = x.Sifra,
                Naziv = x.Naziv,
                Opis = x.Opis,
                Osnovica = x.Osnovica,
                Koefcijent = x.Koefcijent,
                Valid = x.Valid
            }).ToList();

            RadnoMjestoIndexVM Model = new RadnoMjestoIndexVM
            {
                RadnaMjestaList = RadnaMjesta
            };

            return View("Index",Model);
        }
        public ActionResult Dodaj()
        {
            RadnoMjestoIndexVM.RadnoMjestoInfo Model = new RadnoMjestoIndexVM.RadnoMjestoInfo();
            Model.Valid = true;

            return View("Uredi", Model);
        }
        public ActionResult Uredi(int radMjestoId)
        {
            RadnoMjesto entity = ctx.RadnoMjestos.Find(radMjestoId);

            RadnoMjestoIndexVM.RadnoMjestoInfo Model = new RadnoMjestoIndexVM.RadnoMjestoInfo();

            Model.Id = entity.Id;
            Model.Naziv = entity.Naziv;
            Model.Koefcijent = entity.Koefcijent;
            Model.Opis = entity.Opis;
            Model.Osnovica = entity.Osnovica;
            Model.Sifra = entity.Sifra;
            Model.Valid = entity.Valid;

            return View("Uredi", Model);
        }
        public ActionResult Snimi(RadnoMjestoIndexVM.RadnoMjestoInfo vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", vm);
            }
            RadnoMjesto entity;
            if (vm == null || vm.Id == 0)
            {
                entity = new RadnoMjesto();
                ctx.RadnoMjestos.Add(entity);
            }
            else
            {
                entity = ctx.RadnoMjestos.Find(vm.Id);
            }

            entity.Id = vm.Id;
            entity.Koefcijent = vm.Koefcijent;
            entity.Naziv = vm.Naziv;
            entity.Opis = vm.Opis;
            entity.Osnovica = vm.Osnovica;
            entity.Sifra = vm.Sifra;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index");
       }
        public ActionResult Obrisi(int radMjestoId)
        {
            RadnoMjesto entity = ctx.RadnoMjestos.Find(radMjestoId);
            ctx.RadnoMjestos.Remove(entity);

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}