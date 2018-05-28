using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessKlinika.DAL;
using DataAccessKlinika.Model;
using IS_Klinika.Areas.ModulKadrovskaSluzba.Models;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Controllers
{
    public class OpstinaController : Controller
    {
        //
        // GET: /ModulAdministracija/Opština/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<OpstinaIndexVM.OpstinaInfo> Opstine = ctx.Opstinas.Select(x => new OpstinaIndexVM.OpstinaInfo
            {
                Id = x.Id,
                PTT = x.PTT,
                Naziv = x.Naziv,
                Valid = x.Valid
            }).ToList();

            OpstinaIndexVM Model = new OpstinaIndexVM
            {
                OpstineList = Opstine
            };

            return View("Index", Model);
        }
        public ActionResult Dodaj()
        {
            OpstinaUrediVM Modal = new OpstinaUrediVM();
            Modal.Valid = true;

            return View("Uredi", Modal);
        }
        public ActionResult Uredi(int opstinaId)
        {
            Opstina entity = ctx.Opstinas.Find(opstinaId);
            OpstinaUrediVM Model = new OpstinaUrediVM();

            Model.Id = entity.Id;
            Model.PTT = entity.PTT;
            Model.Naziv = entity.Naziv;
            Model.Valid = entity.Valid;

            return View("Uredi", Model);
        }
        public ActionResult Snimi(OpstinaUrediVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", vm);
            }
            Opstina entity;
            if (vm == null || vm.Id == 0)
            {
                entity = new Opstina();
                ctx.Opstinas.Add(entity);
            }
            else
            {
                entity = ctx.Opstinas.Find(vm.Id);
            }

            entity.Id = vm.Id;
            entity.PTT = vm.PTT;
            entity.Naziv = vm.Naziv;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Obrisi(int opstinaId)
        {
            Opstina entity = ctx.Opstinas.Find(opstinaId);
            ctx.Opstinas.Remove(entity);

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}