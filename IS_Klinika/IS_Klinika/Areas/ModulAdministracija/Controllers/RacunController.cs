using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessKlinika.DAL;
using DataAccessKlinika.Model;
using IS_Klinika.Areas.ModulAdministracija.Models;

namespace IS_Klinika.Areas.ModulAdministracija.Controllers
{
    public class RacunController : Controller
    {
        //
        // GET: /ModulAdministracija/Racun/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index(int pregledId)
        {
            List<RacunIndexVM.RacunInfo> Racuni = ctx.Racuns.Where(x => x.PregledId == pregledId).Select(x => new RacunIndexVM.RacunInfo
            {
                Id=x.Id,
                Datum=x.Datum,
                IznosBezPDVUkupno=x.IznosBezPDVUkupno,
                IznosUkupno=x.IznosUkupno,
                PDVIznosUkupno=x.PDVIznosUkupno,
                PregledId=x.PregledId,
                Valid=x.Valid
            }).ToList();

            RacunIndexVM Model = new RacunIndexVM
            {
                RacuniLista = Racuni
            };

            return View("Index", Model);
        }
        public ActionResult Dodaj(int pregledId)
        {
            Racun entity = new Racun();
            entity.PregledId = pregledId;
            entity.Valid = true;
            entity.Datum = DateTime.UtcNow;
            ctx.Racuns.Add(entity);

            ctx.SaveChanges();

            Racun r = ctx.Racuns.Include(x => x.Pregled).Where(x => x.PregledId == pregledId).FirstOrDefault();

            List<RacunStavkeIndexVM.RacunStavkeInfo> StavkeList = ctx.RacunStavkes.Include(x => x.Proizvod).Include(x => x.Racun).Where(x => x.RacunId == r.Id).Select(x => new RacunStavkeIndexVM.RacunStavkeInfo
            {
                Id = x.Id,
                Kolicina = x.Kolicina,
                PDVStopeId = x.PDVStopeId,
                PDVStopeNaziv = x.PDVStope.Naziv,
                ProizvodId = x.ProizvodId,
                ProizvodNaziv = x.Proizvod.Naziv,
                RacunId = x.RacunId,
                Valid = x.Valid,
                PDV = x.PDVStope.PDV,
                IznosBezPDV = (x.Kolicina * x.Proizvod.Cijena) - (x.Kolicina * x.Proizvod.Cijena)*(x.Proizvod.Popust/100),
                IznosPDV = (((x.Kolicina * x.Proizvod.Cijena) - (x.Kolicina * x.Proizvod.Cijena) * (x.Proizvod.Popust / 100)) * (x.PDVStope.PDV / 100)),
                IznosSaPDV = ((x.Kolicina * x.Proizvod.Cijena) - (x.Kolicina * x.Proizvod.Cijena) * (x.Proizvod.Popust / 100)) + (((x.Kolicina * x.Proizvod.Cijena) - (x.Kolicina * x.Proizvod.Cijena) * (x.Proizvod.Popust / 100)) * (x.PDVStope.PDV / 100)),
                ProizodCijena=x.Proizvod.Cijena,
                Popust=x.Proizvod.Popust,
                PopustIznos=(x.Kolicina * x.Proizvod.Cijena)*(x.Proizvod.Popust/100)
            }).ToList();

            RacunUrediVM Model = new RacunUrediVM();
            Model.Id = r.Id;
            Model.PregledId = r.PregledId;
            Model.Datum = r.Datum;
            Model.StavkeList = StavkeList;
            foreach (RacunStavkeIndexVM.RacunStavkeInfo x in StavkeList)
            {
                Model.IznosBezPDVUkupno += x.IznosBezPDV;
                Model.PDVIznosUkupno += x.IznosPDV;
                Model.IznosUkupno += x.IznosSaPDV;
                Model.Popust += x.Popust;
            }
            Model.Valid = r.Valid;
            Model.ProizvodiList = UcitajProizvode();
            Model.StopePDVList = UcitajPDV();

            return View("Uredi", Model);
        }

        public ActionResult Uredi(int racunId)
        {
            Racun entity = ctx.Racuns.Include(x => x.Pregled).Where(x => racunId == x.Id).FirstOrDefault();

            List<RacunStavkeIndexVM.RacunStavkeInfo> StavkeList = ctx.RacunStavkes.Include(x => x.Proizvod).Include(x => x.Racun).Where(x => x.RacunId == entity.Id).Select(x => new RacunStavkeIndexVM.RacunStavkeInfo
            {
                Id = x.Id,
                Kolicina = x.Kolicina,
                PDVStopeId = x.PDVStopeId,
                PDVStopeNaziv = x.PDVStope.Naziv,
                ProizvodId = x.ProizvodId,
                ProizvodNaziv = x.Proizvod.Naziv,
                RacunId = x.RacunId,
                Valid = x.Valid,
                PDV = x.PDVStope.PDV,
                IznosBezPDV = (x.Kolicina * x.Proizvod.Cijena),
                IznosPDV = ((x.Kolicina * x.Proizvod.Cijena) * (x.PDVStope.PDV/100)),
                IznosSaPDV = (x.Kolicina * x.Proizvod.Cijena) + ((x.Kolicina * x.Proizvod.Cijena) * (x.PDVStope.PDV/100)),
                ProizodCijena=x.Proizvod.Cijena,
                Popust = x.Proizvod.Popust,
                PopustIznos = (x.Kolicina * x.Proizvod.Cijena) * (x.Proizvod.Popust / 100)
            }).ToList();

            RacunUrediVM Model = new RacunUrediVM();
            Model.Id = entity.Id;
            Model.Datum = entity.Datum;
            Model.StavkeList = StavkeList;
            foreach (RacunStavkeIndexVM.RacunStavkeInfo x in StavkeList)
            {
                Model.IznosBezPDVUkupno += x.IznosBezPDV;
                Model.PDVIznosUkupno += x.IznosPDV;
                Model.IznosUkupno += x.IznosSaPDV;
                Model.Popust += x.PopustIznos;
            }
            Model.PregledId = entity.PregledId;
            Model.Valid = entity.Valid;
            Model.ProizvodiList = UcitajProizvode();
            Model.StopePDVList = UcitajPDV();

            return View("Uredi", Model);
        }

        public ActionResult Snimi(RacunUrediVM vm)
        {
            Racun entity;
            if(vm==null || vm.Id==0)
            {
                entity = new Racun();
                ctx.Racuns.Add(entity);
            }
            else
            {
                entity = ctx.Racuns.Find(vm.Id);
            }

            entity.Id = vm.Id;
            entity.Datum = vm.Datum;
            entity.IznosBezPDVUkupno = vm.IznosBezPDVUkupno;
            entity.IznosUkupno = vm.IznosUkupno;
            entity.PDVIznosUkupno = vm.PDVIznosUkupno;
            entity.PregledId = vm.PregledId;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index",new{ pregledId = entity.PregledId });
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
	}
}