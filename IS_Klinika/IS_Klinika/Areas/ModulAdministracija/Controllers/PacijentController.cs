using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using IS_Klinika.Areas.ModulAdministracija.Models;
using DataAccessKlinika.DAL;
using DataAccessKlinika.Model;

namespace IS_Klinika.Areas.ModulAdministracija.Controllers
{
    public class PacijentController : Controller
    {
        //
        // GET: /ModulAdministracija/Pacijent/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<PacijentIndexVM.PacijentInfo> Pacijenti = ctx.Pacijents.
                Include(x=>x.Korisnici).
                Include(x=>x.OpstinaPrebivalista).
                Include(x=>x.OpstinaRodzenja).
                Include(x=>x.Klinika).                
                Select(x => new PacijentIndexVM.PacijentInfo
            {
                Id=x.Id,
                AktivacijskiHash=x.AktivacijskiHash,
                IsPotvrdjen=x.IsPotvrdjen,
                DatumRegistracije=x.DatumRegistracije,
                Valid=x.Valid,
                Ime=x.Korisnici.Ime,
                Prezime=x.Korisnici.Prezime,
                Adresa=x.Korisnici.Adresa,
                OpstinaPrebivalistaId=x.OpstinaPrebivalistaId,
                OpstinaPrebivalistaNaziv=x.OpstinaPrebivalista.Naziv,
                KlinikaId=x.KlinikaId,
                KlinikaNaziv=x.Klinika.Naziv
            }).ToList();

            PacijentIndexVM Model = new PacijentIndexVM
            {
                ListaPacijenata=Pacijenti,
                OpstinaList=UcitajOpstine()
            };

            return View(Model);
        }
        public ActionResult Uredi(int pacijentId)
        {
            Pacijent p = ctx.Pacijents.Where(x=> x.Id == pacijentId).
                Include(x => x.Korisnici).
                Include(x => x.KrvnaGrupa).                
                Include(x=>x.OpstinaRodzenja).
                Include(x=>x.OpstinaPrebivalista).FirstOrDefault();

            PacijentUrediVM Model = new PacijentUrediVM();
                Model.Id = p.Id;
                Model.IsPotvrdjen = p.IsPotvrdjen;
                Model.AktivacijskiHash = p.AktivacijskiHash;
                Model.KrvnaGrupaId = p.KrvnaGrupaId;
                Model.DatumRegistracije = p.DatumRegistracije;
                Model.Valid = p.Valid;
                Model.Ime = p.Korisnici.Ime;
                Model.Prezime = p.Korisnici.Prezime;
                Model.Adresa = p.Korisnici.Adresa;
                Model.Email = p.Korisnici.Email;
                Model.Tel = p.Korisnici.Tel;
                Model.Mob = p.Korisnici.Mob;
                Model.DatumRodjenja = p.Korisnici.DatumRodjenja;
                Model.OpstinaPrebivalistaId = p.OpstinaPrebivalistaId;
                Model.OpstinaRodzenjaId = p.OpstinaRodzenjaId;
                Model.KorisnickoIme = p.Korisnici.KorisnickoIme;
                Model.Lozinka = p.Korisnici.Lozinka;
                Model.KlinikaId = p.KlinikaId;               
            
            Model.KrvnaGrupaLista = UcitajKrv();
            Model.OpstineList = UcitajOpstine();
            Model.KlinikeList = UcitajKlinike();
            Model.ZaposleniciList = UcitajZaposlenike();
            Model.DatumPregleda = DateTime.Now;

            return View("Uredi", Model);
        }
        private List<SelectListItem> UcitajZaposlenike()
        {
            List<SelectListItem> Zaposlenici = new List<SelectListItem>();

            Zaposlenici.AddRange(ctx.Zaposleniks.Include(x => x.RadnoMjesto).Include(x => x.Korisnici).Where(x => x.RadnoMjesto.Naziv == "Doktor").Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Korisnici.Ime + " " + x.Korisnici.Prezime }).ToList());

            return Zaposlenici;
        }
        private List<SelectListItem> UcitajKrv()
        {
            List<SelectListItem> Krv = new List<SelectListItem>();
            Krv.Add(new SelectListItem { Value = null, Text = "Izaberi krvnu grupu" });
            Krv.AddRange(ctx.KrvnaGrupas.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());

            return Krv;
        }
        public ActionResult Snimi(PacijentUrediVM p)
        {
            if (!ModelState.IsValid)
            {
                p.KrvnaGrupaLista = UcitajKrv();
                p.OpstineList = UcitajOpstine();
                p.KlinikeList = UcitajKlinike();
                p.ZaposleniciList = UcitajZaposlenike();
                p.DatumRegistracije = DateTime.Now;
                return View("Uredi", p);
            }
            Pacijent entity;
            if (p == null || p.Id == 0)
            {
                entity = new Pacijent();
                entity.Korisnici = new Korisnici();
                ctx.Pacijents.Add(entity);
            }
            else
            {
                entity = ctx.Pacijents.Find(p.Id);
                entity.Korisnici = ctx.Kosrisnicis.Find(p.Id);
            }
            entity.Id = p.Id;
            entity.IsPotvrdjen = p.IsPotvrdjen;
            entity.KrvnaGrupaId=p.KrvnaGrupaId;
            entity.Valid=p.Valid;
            entity.DatumRegistracije = p.DatumRegistracije;
            entity.AktivacijskiHash = p.AktivacijskiHash;
            entity.OpstinaPrebivalistaId = p.OpstinaPrebivalistaId;
            entity.OpstinaRodzenjaId = p.OpstinaRodzenjaId;
            entity.KrvnaGrupaId = p.KrvnaGrupaId;
            entity.KlinikaId = p.KlinikaId;
            entity.Korisnici.Id = p.Id;
            entity.Korisnici.Ime = p.Ime;
            entity.Korisnici.Prezime = p.Prezime;
            entity.Korisnici.KorisnickoIme = p.KorisnickoIme;
            entity.Korisnici.Lozinka = p.Lozinka;
            entity.Korisnici.Mob = p.Mob;
            entity.Korisnici.Tel = p.Tel;
            entity.Korisnici.Email = p.Email;
            entity.Korisnici.Adresa = p.Adresa;
            entity.Korisnici.DatumRodjenja = p.DatumRodjenja;
            entity.Korisnici.Valid = p.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Dodaj()
        {
            PacijentUrediVM Model = new PacijentUrediVM();
            Model.KrvnaGrupaLista = UcitajKrv();
            Model.KlinikeList = UcitajKlinike();
            Model.OpstineList = UcitajOpstine();
            Model.ZaposleniciList = UcitajZaposlenike();
            Model.DatumRegistracije = DateTime.Now;
            Model.Valid = true;

            return View("Uredi", Model);
        }
        private List<SelectListItem> UcitajOpstine()
        {
            List<SelectListItem> Opstine = new List<SelectListItem>();
            Opstine.Add(new SelectListItem { Value = null, Text = "Izaberi opštinu" });
            Opstine.AddRange(ctx.Opstinas.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());

            return Opstine;
        }
        public List<SelectListItem> UcitajKlinike()
        {
            List<SelectListItem> Klinike = new List<SelectListItem>();
            Klinike.Add(new SelectListItem { Value = null, Text = "Izaberi Kliniku" });
            Klinike.AddRange(ctx.Klinikas.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }));

            return Klinike;
        }
        public ActionResult Obrisi(int pacijentId)
        {
            Pacijent entity = ctx.Pacijents.Find(pacijentId);
            ctx.Pacijents.Remove(entity);

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}