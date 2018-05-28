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
    public class ObustaveController : Controller
    {
        //
        // GET: /ModulAdministracija/Obustave/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index(int zaposlenikId)
        {
            List<ObustaveIndexVM.ObustaveInfo> Obustave = ctx.Obustaves.Include(x => x.Zaposlenik).Include(x=>x.Zaposlenik.Korisnici).Include(x => x.VrstaObustave).Where(x => x.ZaposlenikId == zaposlenikId).Select(x => new ObustaveIndexVM.ObustaveInfo
            {
                Id=x.Id,
                Aktivan=x.Aktivan,
                BrojRata = x.BrojRata,
                Iznos = x.Iznos,
                RataIznos = x.RataIznos,
                VrstaObustaveId = x.VrstaObustaveId,
                VrsteObustavaNaziv = x.VrstaObustave.Naziv,
                ZaposlenikId = x.ZaposlenikId,
                ZaposlenikNaziv = x.Zaposlenik.Korisnici.Ime+" "+x.Zaposlenik.Korisnici.Prezime,
                DatumIzdavanja = x.DatumIzdavanja,
                DatumPrestanka=x.DatumPrestanka,
                Valid = x.Valid
            }).ToList();

            ObustaveIndexVM Model = new ObustaveIndexVM
            {
                ObustaveList = Obustave,
                zapID=zaposlenikId
            };
            
            return View("Index",Model);
        }
        public ActionResult Dodaj(int zaposlenikId)
        {
            ObustaveUrediVM Model = new ObustaveUrediVM();
            Model.ZaposlenikId = zaposlenikId;
            Model.ZaposleniciList = UcitajZaposlenike();
            Model.VrsteObustavaList = UcitajVrsteObustava();
            Model.Valid = true;

            return View("Uredi", Model);
        }
        private List<SelectListItem> UcitajZaposlenike()
        {
            List<SelectListItem> Zaposlenici = new List<SelectListItem>();
            Zaposlenici.Add(new SelectListItem { Value = null, Text = "izbor radnika" });
            Zaposlenici.AddRange(ctx.Zaposleniks.Include(x => x.Korisnici).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Korisnici.Ime + " " + x.Korisnici.Prezime }).ToList());

            return Zaposlenici;
        }
        private List<SelectListItem> UcitajVrsteObustava()
        {
            List<SelectListItem> VrsteObustava = new List<SelectListItem>();
            VrsteObustava.Add(new SelectListItem { Value = null, Text = "Vrsta obustava" });
            VrsteObustava.AddRange(ctx.VrstaObustaves.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());

            return VrsteObustava;        
        }
        public ActionResult Uredi(int obustavaId)
        {
            Obustave entity = ctx.Obustaves.Find(obustavaId);
            ObustaveUrediVM Model = new ObustaveUrediVM();

            Model.Id = entity.Id;
            Model.Aktivan = entity.Aktivan;
            Model.BrojRata = entity.BrojRata;
            Model.Iznos = entity.Iznos;
            Model.RataIznos = entity.RataIznos;
            Model.VrstaObustaveId = entity.VrstaObustaveId;
            Model.ZaposlenikId = entity.ZaposlenikId;
            Model.DatumIzdavanja = entity.DatumIzdavanja;
            Model.DatumPrestanka = entity.DatumPrestanka;
            Model.Valid = entity.Valid;

            Model.VrsteObustavaList = UcitajVrsteObustava();
            Model.ZaposleniciList = UcitajZaposlenike();

            return View("Uredi", Model);
        }
        public ActionResult Snimi(ObustaveUrediVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.VrsteObustavaList = UcitajVrsteObustava();
                vm.ZaposleniciList = UcitajZaposlenike();
                return View("Uredi", vm);
            }

            Obustave entity;
            if (vm == null || vm.Id == 0)
            {
                entity = new Obustave();
                ctx.Obustaves.Add(entity);
            }
            else
            {
                entity = ctx.Obustaves.Find(vm.Id);
            }

            entity.Id = vm.Id;
            entity.Iznos = vm.Iznos;
            entity.RataIznos = vm.RataIznos;
            entity.BrojRata = vm.BrojRata;
            entity.Aktivan = vm.Aktivan;
            entity.DatumIzdavanja = vm.DatumIzdavanja;
            entity.DatumPrestanka = vm.DatumPrestanka;
            entity.VrstaObustaveId = vm.VrstaObustaveId;
            entity.ZaposlenikId = vm.ZaposlenikId;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Uredi", "Zaposlenik", new { korisnikId = entity.ZaposlenikId });
        }
        public ActionResult Obrisi(int obustavaId)
        {
            Obustave entity = ctx.Obustaves.Find(obustavaId);
            ctx.Obustaves.Remove(entity);

            ctx.SaveChanges();

            return RedirectToAction("Uredi","Zaposlenik", new { korisnikId = entity.ZaposlenikId });
        }
	}
}