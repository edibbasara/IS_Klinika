using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessKlinika.DAL;
using DataAccessKlinika.Model;
using IS_Klinika.Areas.ModulAdministracija.Models;
using System.Data.Entity;

namespace IS_Klinika.Areas.ModulAdministracija.Controllers
{
    public class DijagnozaController : Controller
    {
        //
        // GET: /ModulAdministracija/Dijagnoza/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List < DijagnozaIndexVM.DijagnozaIndex> Dijagnoze = ctx.Dijagnozas.
                Include(x => x.Pregled).Select(x=> new DijagnozaIndexVM.DijagnozaIndex{
             Id=x.Id,
             Opis=x.Opis,
             PregledId=x.PregledId,
             Valid=x.Valid
            }).ToList();
            DijagnozaIndexVM Model = new DijagnozaIndexVM
            {
                DijagnozaList = Dijagnoze
            };

            return View("Index", Model);
        }
        public ActionResult Dodaj(int pregledId,int pacijentId)
        {
            Pregled entity = ctx.Pregleds.Find(pregledId);
            DijagnozaUrediVM Model = new DijagnozaUrediVM();
            Model.OpisPregled = entity.Opis;
            Model.HistorijBolesti = entity.HistorijaBolesti;
            Model.PregledId = entity.Id;
            Model.pacId = pacijentId;
            Model.Valid = true;

            return View("Uredi", Model);
        }

        public ActionResult Uredi(int pregledId,int pacijentId)
        {
            Dijagnoza entity = ctx.Dijagnozas.Include(x=>x.Pregled).Where(x=>x.PregledId==pregledId).FirstOrDefault();

            DijagnozaUrediVM Model = new DijagnozaUrediVM();
            if (entity == null || entity.Id == 0)
            {
                return RedirectToAction("Dodaj", new { pregledId = pregledId, pacijentId = pacijentId });
            }
            else
            {
                Model.Id = entity.Id;
                Model.Opis = entity.Opis;
                Model.PregledId = entity.PregledId;
                Model.Valid = entity.Valid;
                Model.OpisPregled = entity.Pregled.Opis;
                Model.HistorijBolesti = entity.Pregled.HistorijaBolesti;
                Model.pacId = pacijentId;
            }
            return View("Uredi", Model);
            
        }
        public ActionResult Snimi(DijagnozaUrediVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", vm);
            }
            Dijagnoza entity;
            if (vm == null || vm.Id == 0)
            {
                entity = new Dijagnoza();
                ctx.Dijagnozas.Add(entity);               
            }
            else
            {
                entity = ctx.Dijagnozas.Find(vm.Id);
            }
            entity.Id = vm.Id;
            entity.Opis = vm.Opis;
            entity.PregledId = vm.PregledId;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Uredi","Pacijent", new { pacijentId = vm.pacId });
        }
	}
}