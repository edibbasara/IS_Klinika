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
    public class RacunStavkeController : Controller
    {
        //
        // GET: /ModulAdministracija/RacunStavke/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index(int racunId)
        {
            List<RacunStavkeIndexVM.RacunStavkeInfo> RacunStavke = ctx.RacunStavkes.Include(x => x.Racun).Include(x => x.Proizvod).Include(x => x.PDVStope).Where(x => x.RacunId == racunId).Select(x => new RacunStavkeIndexVM.RacunStavkeInfo
            {
                Id=x.Id,
                Kolicina=x.Kolicina,
                PDVStopeId=x.PDVStopeId,
                PDVStopeNaziv=x.PDVStope.Naziv,
                ProizvodId=x.ProizvodId,
                ProizvodNaziv=x.Proizvod.Naziv,
                RacunId=x.RacunId,
                Valid=x.Valid,
                PDV=x.PDVStope.PDV,
                IznosBezPDV=(x.Kolicina*x.Proizvod.Cijena)*x.Proizvod.Popust,
                IznosPDV = ((x.Kolicina * x.Proizvod.Cijena) * x.Proizvod.Popust)*x.PDVStope.PDV,
                IznosSaPDV = ((x.Kolicina * x.Proizvod.Cijena) * x.Proizvod.Popust) + (((x.Kolicina * x.Proizvod.Cijena) * x.Proizvod.Popust) * x.PDVStope.PDV),
                ProizodCijena=x.Proizvod.Cijena
            }).ToList();

            RacunStavkeIndexVM Model = new RacunStavkeIndexVM
            {
                RacunStavkeList = RacunStavke
            };
            return View("Index",Model);
        }
        public ActionResult Dodaj(int racunId, int stopaId, int proizvodId,  int kolicina){
            
            RacunStavkeUrediVM Model = new RacunStavkeUrediVM();
            Model.RacunId = racunId;
            Model.Kolicina = kolicina;
            Model.PDVStopeId = 1;
            Model.ProizvodId = proizvodId;
            Model.Valid = true;

            return RedirectToAction("Snimi", Model);
        }
        private List<SelectListItem> UcitajProizvode()
        {
            List<SelectListItem> ProizvodiList = new List<SelectListItem>();
            ProizvodiList.Add(new SelectListItem { Value = null, Text = "Izbor proizvoda" });
            ProizvodiList.AddRange(ctx.Proizvods.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());

            return ProizvodiList;
        }
        private List<SelectListItem> UcitajPDV()
        {
            List<SelectListItem> PDVLista = new List<SelectListItem>();
            PDVLista.AddRange(ctx.PDVStopes.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());

            return PDVLista;
        }
        public ActionResult Uredi(int stavkaId,int racunId)
        {
            RacunStavke entity = ctx.RacunStavkes.Find(stavkaId);

            RacunStavkeUrediVM Model = new RacunStavkeUrediVM();
            Model.Id = entity.Id;
            Model.Kolicina = entity.Kolicina;
            Model.PDVStopeId = entity.PDVStopeId;
            Model.PDVStopeList = UcitajPDV();
            Model.ProizvodId = entity.ProizvodId;
            Model.ProizvodiLista = UcitajProizvode();
            Model.RacunId = racunId;
            Model.Valid = entity.Valid;

            return View("Uredi", Model);
        }
        public ActionResult Snimi(RacunStavkeUrediVM vm)
        {
            RacunStavke entity;
            if (vm == null || vm.Id ==0)
            {
                entity = new RacunStavke();
                ctx.RacunStavkes.Add(entity);
            }
            else
            {
                entity = ctx.RacunStavkes.Find(vm.Id);
            }

            entity.Id = vm.Id;
            entity.Kolicina = vm.Kolicina;
            entity.PDVStopeId= vm.PDVStopeId;
            entity.ProizvodId = vm.ProizvodId;
            entity.RacunId = vm.RacunId;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Uredi", "Racun", new { entity.RacunId });
        }
        public ActionResult Obrisi(int stavkaId)
        {
            RacunStavke entity = ctx.RacunStavkes.Find(stavkaId);
            ctx.RacunStavkes.Remove(entity);

            ctx.SaveChanges();

            return RedirectToAction("Uredi", "Racun", new { entity.RacunId });
        }
	}
}