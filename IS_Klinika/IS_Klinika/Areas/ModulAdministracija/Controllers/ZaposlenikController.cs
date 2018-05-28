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
    public class ZaposlenikController : Controller
    {
        //
        // GET: /ModulAdministracija/Zaposlenik/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<ZaposlenikIndexVM.ZaposlenikInfo> Zaposlenici = ctx.Zaposleniks.
                Include(x=>x.Klinika).
                Include(x=>x.RadnoMjesto).
                Include(x=>x.Korisnici).
                Include(x=>x.OpstinaPrebivalista).Select(x => new ZaposlenikIndexVM.ZaposlenikInfo
            {
                Id=x.Id,
                IsAdministrator=x.IsAdministrator,
                IsDoktor=x.IsDoktor,
                IsMedicinskoOsoblje=x.IsMedicinskoOsoblje,
                IsKadrovskoOsoblje=x.IsKadrovskoOsoblje,
                KlinikaId=x.KlinikaId,
                KlinikaNaziv=x.Klinika.Naziv,
                RadnoMjestoId=x.RadnoMjestoId,
                RadnoMjestoNaziv=x.RadnoMjesto.Naziv,
                PocetakRada=x.PocetakRada,
                KrajRada=x.KrajRada,
                Valid=x.Valid,
                ImePrezime=x.Korisnici.Ime+" "+x.Korisnici.Prezime,
                Adresa=x.Korisnici.Adresa,
                Email=x.Korisnici.Email,
                Mob=x.Korisnici.Mob,
                Tel=x.Korisnici.Tel,
                OpstinaPrebivalistaID=x.OpstinaPrebivalistaId,
                OpstinaPrebivalistaNaziv=x.OpstinaPrebivalista.Naziv
            }).ToList();

            ZaposlenikIndexVM Model = new ZaposlenikIndexVM
            {
                ZaposleniciLista=Zaposlenici,
                KlinikaList =UcitajKlinike()
            };

            return View(Model);

        }
        public ActionResult Uredi(int korisnikId)
        {
            Zaposlenik z = ctx.Zaposleniks.Where(x => korisnikId == x.Id)
                .Include(x => x.Korisnici).
                Include(x => x.OpstinaPrebivalista).
                Include(x => x.OpstinaRodzenja).
                Include(x => x.Klinika).
                Include(x => x.RadnoMjesto).FirstOrDefault();

            ZaposlenikUrediVM Model = new ZaposlenikUrediVM();
            Model.Id = z.Id;
            Model.Ime = z.Korisnici.Ime;
            Model.Prezime = z.Korisnici.Prezime;
            Model.KorisnickoIme = z.Korisnici.KorisnickoIme;
            Model.Lozinka = z.Korisnici.Lozinka;
            Model.Adresa = z.Korisnici.Adresa;
            Model.OpstinaPrebivalistaId = z.OpstinaPrebivalistaId;
            Model.OpstinaRodzenjaId = z.OpstinaRodzenjaId;
            Model.IsAdministrator = z.IsAdministrator;
            Model.IsDoktor = z.IsDoktor;
            Model.IsKadrovskoOsoblje = z.IsKadrovskoOsoblje;
            Model.IsMedicinskoOsoblje = z.IsMedicinskoOsoblje;
            Model.JMBG=z.JMBG;
            Model.LKbr=z.LKbr;
            Model.Email=z.Korisnici.Email;
            Model.Tel=z.Korisnici.Tel;
            Model.Mob=z.Korisnici.Mob;
            Model.Banka=z.Banka;
            Model.Konto=z.Konto;
            Model.DatumRodjenja=z.Korisnici.DatumRodjenja;
            Model.KoefLO=z.KoefLO;
            Model.MinuliRad=z.MinuliRad;
            Model.PIOdjelBr=z.PIOdjelBr;
            Model.PIOregBr=z.PIOregBr;
            Model.RadnoMjestoId=z.RadnoMjestoId;
            Model.PocetakRada=z.PocetakRada;
            Model.KrajRada=z.KrajRada;
            Model.KlinikaId=z.KlinikaId;
            Model.Valid=z.Valid;
            Model.KorisnikValid=z.Valid;

            Model.KlinikaList=UcitajKlinike();
            Model.OpstinaList=UcitajOpstine();
            Model.RadnoMjestoList=UcitajRadnoMjesto();

            return View("Uredi", Model);
        }
        public ActionResult Dodaj()
        {
            ZaposlenikUrediVM Model = new ZaposlenikUrediVM();
            Model.KlinikaList = UcitajKlinike();
            Model.OpstinaList = UcitajOpstine();
            Model.RadnoMjestoList = UcitajRadnoMjesto();
            Model.Valid = true;

            return View("Uredi",Model);
        }
        public ActionResult Snimi(ZaposlenikUrediVM z)
        {
            Zaposlenik entity;

            if (z == null || z.Id == 0)
            {
                entity = new Zaposlenik();
                entity.Korisnici = new Korisnici();
                ctx.Zaposleniks.Add(entity);
            }
            else
            {
                entity = ctx.Zaposleniks.Find(z.Id);
                entity.Korisnici = ctx.Kosrisnicis.Find(z.Id);
            }
            entity.Id = z.Id;
            entity.Korisnici.Ime = z.Ime;
            entity.Korisnici.Prezime = z.Prezime;
            entity.Korisnici.KorisnickoIme = z.KorisnickoIme;
            entity.Korisnici.Lozinka = z.Lozinka;
            entity.Korisnici.Adresa = z.Adresa;
            entity.Korisnici.Email = z.Email;
            entity.Korisnici.Tel = z.Tel;
            entity.Korisnici.Mob = z.Mob;
            entity.Korisnici.Valid = z.KorisnikValid;
            entity.Korisnici.DatumRodjenja = z.DatumRodjenja;
            entity.IsAdministrator = z.IsAdministrator;
            entity.IsDoktor = z.IsDoktor;
            entity.IsKadrovskoOsoblje = z.IsKadrovskoOsoblje;
            entity.IsMedicinskoOsoblje = z.IsMedicinskoOsoblje;
            entity.Banka = z.Banka;
            entity.Konto = z.Konto;
            entity.JMBG = z.JMBG;
            entity.LKbr = z.LKbr;
            entity.MinuliRad = z.MinuliRad;
            entity.OpstinaPrebivalistaId = z.OpstinaPrebivalistaId;
            entity.OpstinaRodzenjaId = z.OpstinaRodzenjaId;
            entity.PIOdjelBr = z.PIOdjelBr;
            entity.PIOregBr = z.PIOregBr;
            entity.RadnoMjestoId = z.RadnoMjestoId;
            entity.KlinikaId = z.KlinikaId;
            entity.PocetakRada = z.PocetakRada;
            entity.KrajRada = z.KrajRada;
            entity.Valid = z.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        private List<SelectListItem> UcitajRadnoMjesto()
        {
            List<SelectListItem> RadnaMjesta = new List<SelectListItem>();

            RadnaMjesta.Add(new SelectListItem { Value = null, Text = "Izaberi radno mjesto" });
            RadnaMjesta.AddRange(ctx.RadnoMjestos.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());

            return RadnaMjesta;        
        }
 
        private List<SelectListItem> UcitajOpstine()
        {
            List<SelectListItem> Opstine = new List<SelectListItem>();
            Opstine.Add(new SelectListItem { Value = null, Text = "Izaberi opštinu" });
            Opstine.AddRange(ctx.Opstinas.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());

            return Opstine;
        }
        private List<SelectListItem> UcitajKlinike()
        {
            List<SelectListItem> Klinike = new List<SelectListItem>();
            Klinike.Add(new SelectListItem { Value = null, Text = "Izbor klinike" });
            Klinike.AddRange(ctx.Klinikas.Select(x => new SelectListItem { Value = x.Id.ToString(), Text=x.Naziv }).ToList());

            return Klinike;
        }
        public ActionResult Obrisi(int zaposlenikId)
        {
            try
            {
            Zaposlenik entity = ctx.Zaposleniks.Find(zaposlenikId);
            if (entity != null)
            {
                ctx.Zaposleniks.Remove(entity);
            }
            Korisnici k = ctx.Kosrisnicis.Find(zaposlenikId);
            if (k != null)
            {
                ctx.Kosrisnicis.Remove(k);
            }
          
            ctx.SaveChanges();

            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
	}
}