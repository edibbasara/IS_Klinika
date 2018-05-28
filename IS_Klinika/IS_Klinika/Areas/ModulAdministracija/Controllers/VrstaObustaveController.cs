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
    public class VrstaObustaveController : Controller
    {
        //
        // GET: /ModulAdministracija/VrstaObustave/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<VrstaObustaveIndexVM.VrstaObustaveInfo> VrsteObustava = ctx.VrstaObustaves.Select(x => new VrstaObustaveIndexVM.VrstaObustaveInfo
            {
                Id=x.Id,
                Naziv=x.Naziv,
                ZiroRN=x.ZiroRN,
                Valid=x.Valid
            }).ToList();

            VrstaObustaveIndexVM Model = new VrstaObustaveIndexVM{
              VrsteObustaveList=VrsteObustava  
            };
            
            return View("Index",Model);
        }
        public ActionResult Dodaj()
        {
            VrstaObustaveUrediVM Model = new VrstaObustaveUrediVM();
            Model.Valid = true;

            return View("Uredi", Model);
        }
        public ActionResult Uredi(int vrsteId)
        {
            VrstaObustave entity = ctx.VrstaObustaves.Find(vrsteId);
            VrstaObustaveUrediVM Model = new VrstaObustaveUrediVM();

            Model.Id = entity.Id;
            Model.Naziv = entity.Naziv;
            Model.ZiroRN = entity.ZiroRN;
            Model.Valid = entity.Valid;

            return View("Uredi",Model);
        }
        public ActionResult Snimi(VrstaObustaveUrediVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", vm);
            }
            VrstaObustave entity;
            if (vm == null || vm.Id == 0)
            {
                entity = new VrstaObustave();
                ctx.VrstaObustaves.Add(entity);
            }
            else
            {
                entity = ctx.VrstaObustaves.Find(vm.Id);
            }

            entity.Id = vm.Id;
            entity.Naziv = vm.Naziv;
            entity.ZiroRN = vm.ZiroRN;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Obrisi(int vrsteId)
        {
            VrstaObustave entity = ctx.VrstaObustaves.Find(vrsteId);
            ctx.VrstaObustaves.Remove(entity);

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
	}
}