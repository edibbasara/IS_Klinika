using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessKlinika.Model;
using DataAccessKlinika.DAL;
using IS_Klinika.Areas.ModulKadrovskaSluzba.Models;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Controllers
{
    public class SmjenaController : Controller
    {
        //
        // GET: /ModulAdministracija/Smjena/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<SmjenaIndexVM.SmjenaInfo> ListaSmjena = ctx.Smjenas.Select(x => new SmjenaIndexVM.SmjenaInfo
            {
                Id = x.Id,
                Naziv = x.Naziv,
                Valid = x.Valid
            }).ToList();

            SmjenaIndexVM Model = new SmjenaIndexVM
            {
                SmjenaList = ListaSmjena
            };

            return View("Index", Model);
        }
        public ActionResult Dodaj()
        {

            SmjenaUrediVM Model = new SmjenaUrediVM();
            Model.Valid = true;

            return View("Uredi", Model);
        }
        public ActionResult Uredi(int smjenaId)
        {
            Smjena entity = ctx.Smjenas.Find(smjenaId);

            SmjenaUrediVM Model = new SmjenaUrediVM();
            Model.Id = entity.Id;
            Model.Naziv = entity.Naziv;
            Model.Valid = entity.Valid;

            return View("Uredi", Model);
        }
        public ActionResult Snimi(SmjenaUrediVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", vm);
            }
            Smjena entity;

            if (vm == null || vm.Id == 0)
            {
                entity = new Smjena();
                ctx.Smjenas.Add(entity);
            }
            else
            {
                entity = ctx.Smjenas.Find(vm.Id);
            }

            entity.Id = vm.Id;
            entity.Naziv = vm.Naziv;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Obrisi(int smjenaId)
        {
            Smjena entity = ctx.Smjenas.Find(smjenaId);
            ctx.Smjenas.Remove(entity);

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}