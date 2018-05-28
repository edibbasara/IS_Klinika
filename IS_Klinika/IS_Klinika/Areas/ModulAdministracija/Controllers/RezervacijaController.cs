using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessKlinika.Model;
using DataAccessKlinika.DAL;
using IS_Klinika.Areas.ModulAdministracija.Models;
using System.Data.Entity;

namespace IS_Klinika.Areas.ModulAdministracija.Controllers
{
    public class RezervacijaController : Controller
    {
        //
        // GET: /ModulAdministracija/Rezervacija/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index(int pacijentId)
        {
            List<RezervacijaIndexVM.RezervacijaInfo> Rezervacije = ctx.Rezervacijes.Include(x => x.Pregled).Include(x => x.Pacijent).Include(x => x.Zaposlenik).Where(x=>x.PacijentId==pacijentId && x.Zavrsen == false).Select(x => new RezervacijaIndexVM.RezervacijaInfo
            {
                Id = x.Id,
                Opis = x.Pregled.Opis,
                PregledId = x.PregledId,
                PacijentId = x.PacijentId,
                pacijentNaziv = x.Pacijent.Korisnici.Ime + " " + x.Pacijent.Korisnici.Prezime,
                ZaposlenikId = x.ZaposlenikId,
                zaposlenikNaziv = x.Zaposlenik.Korisnici.Ime + " " + x.Zaposlenik.Korisnici.Prezime,
                DatumPregleda = x.DatumPregleda,
                DatumRezervacije = x.DatumRezervacije,
                Zavrsen = x.Zavrsen,
                Valid = x.Valid
            }).ToList();

            RezervacijaIndexVM Model = new RezervacijaIndexVM
            {
                RezervacijeList = Rezervacije,
                PacId=pacijentId
            };

            return View("Index", Model);
        }
        public ActionResult Dodaj(int pacijentId,int zaposlenikId,DateTime datumPregleda)
        {
                     
            RezervacijaUrediVM Model = new RezervacijaUrediVM();
            Model.PacijentId = pacijentId;
            Model.pacijentNaziv = ctx.Pacijents.Include(x => x.Korisnici).Where(x => x.Id == pacijentId).Select(x => x.Korisnici.Ime + " " + x.Korisnici.Prezime).FirstOrDefault();
            Model.ZaposlenikId = zaposlenikId;
            Model.zaposlenikNaziv = ctx.Zaposleniks.Include(x => x.Korisnici).Where(x => x.Id == zaposlenikId).Select(x => x.Korisnici.Ime + " "+x.Korisnici.Prezime).FirstOrDefault();
            Model.DatumPregleda = datumPregleda;
            Model.DatumRezervacije = DateTime.Now;
            Model.terminiList = UcitajTermine(zaposlenikId,datumPregleda);
            Model.Valid = true;

            return View("Uredi", Model);
        }
  
        public ActionResult Uredi(int rezervacijaId)
        {
            Rezervacije entity = ctx.Rezervacijes.
                Include(x => x.Pregled).
                Include(x => x.Pacijent).
                Include(x => x.Zaposlenik).
                Include(x => x.Termin).
                Include(x=>x.Zaposlenik.Korisnici).
                Include(x=>x.Pacijent.Korisnici)
                .Where(x => x.Id == rezervacijaId).FirstOrDefault();     
       
            RezervacijaUrediVM Model = new RezervacijaUrediVM();
            Model.DatumPregleda = entity.DatumPregleda;
            Model.DatumRezervacije = entity.DatumRezervacije;
            Model.HistorijaBolesti = entity.Pregled.HistorijaBolesti;
            Model.Id = entity.Id;
            Model.Opis = entity.Pregled.Opis;
            Model.PacijentId = entity.PacijentId;
            Model.pacijentNaziv = entity.Pacijent.Korisnici.Ime + " " + entity.Pacijent.Korisnici.Prezime;
            Model.PregledId = entity.PregledId;
            Model.TerminId = entity.TerminId;
            Model.terminiList = UcitajTermine(entity.ZaposlenikId,entity.DatumPregleda);
            Model.Valid = entity.Valid;
            Model.ZaposlenikId = entity.ZaposlenikId;
            Model.zaposlenikNaziv = entity.Zaposlenik.Korisnici.Ime + " " + entity.Zaposlenik.Korisnici.Prezime;
            Model.Zavrsen = entity.Zavrsen;

            return View("Uredi", Model);
        }
        public ActionResult Snimi(RezervacijaUrediVM vm)
        {
            if(!ModelState.IsValid)
            {
                vm.DatumRezervacije = DateTime.Now;
                vm.terminiList = UcitajTermine(vm.ZaposlenikId, vm.DatumPregleda);
                return View("Uredi", vm);
            }
            Rezervacije entity;
            if (vm == null || vm.Id == 0)
            {
                entity = new Rezervacije();
                entity.Pregled = new Pregled();
                ctx.Rezervacijes.Add(entity);
                
            }
            else
            {
                entity = ctx.Rezervacijes.Include(x => x.Pregled).Where(x => x.Id == vm.Id).FirstOrDefault();
            }

            entity.Id = vm.Id;
            entity.PacijentId = vm.PacijentId;
            entity.PregledId=vm.PregledId;
            entity.Pregled.Opis = vm.Opis;
            entity.Pregled.HistorijaBolesti = vm.HistorijaBolesti;
            entity.Pregled.Valid = vm.Valid;
            entity.TerminId = vm.TerminId;
            entity.ZaposlenikId = vm.ZaposlenikId;
            entity.Zavrsen = vm.Zavrsen;
            entity.DatumPregleda = vm.DatumPregleda;
            entity.DatumRezervacije = DateTime.UtcNow;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Uredi", "Pacijent", new { pacijentId = vm.PacijentId });
        }

        private List<SelectListItem> TerminiLI()
        {
            List<SelectListItem> Termini = new List<SelectListItem>();
            Termini.AddRange(ctx.Termins.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Sati + " : " + x.Minuti }).ToList());

            return Termini;
        }
        private List<SelectListItem> UcitajZaposlenike()
        {
            List<SelectListItem> Zaposlenici = new List<SelectListItem>();
            Zaposlenici.Add(new SelectListItem { Value = null, Text = "Izbor Doktora" });
            Zaposlenici.AddRange(ctx.Zaposleniks.Include(x=>x.RadnoMjesto).Include(x=>x.Korisnici).Where(x=> x.RadnoMjesto.Naziv == "Doktor").Select(x=> new SelectListItem{Value=x.Id.ToString(),Text=x.Korisnici.Ime+" "+x.Korisnici.Prezime}).ToList());

            return Zaposlenici;
        }
        private List<SelectListItem> UcitajPacijente()
        {
            List<SelectListItem> Pacijenti = new List<SelectListItem>();
            Pacijenti.AddRange(ctx.Pacijents.Include(x => x.Korisnici).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Korisnici.Ime + " " + x.Korisnici.Prezime }).ToList());

            return Pacijenti;
        }
        private List<SelectListItem> UcitajTermine(int zaposlenikId,DateTime datumPregleda)
        {
            RadniRaspored rad = ctx.RadniRasporeds.Include(x=>x.Zaposlenik).Where(x=>x.ZaposlenikID==zaposlenikId).FirstOrDefault();

            List<RezervacijaIndexVM.RezervacijaInfo> r = ctx.Rezervacijes
               .Include(x => x.Pregled)
               .Include(x => x.Zaposlenik)
               .Include(x => x.Termin).
               Include(x => x.Pacijent).
               Include(x => x.Pacijent.Korisnici)
               .Include(x => x.Zaposlenik.Korisnici).Where(x => x.ZaposlenikId == zaposlenikId && datumPregleda == x.DatumPregleda).Select(x => new RezervacijaIndexVM.RezervacijaInfo
               {

                   Id = x.Id,
                   PacijentId = x.PacijentId,
                   PregledId = x.PregledId,
                   TerminId = x.TerminId,
                   ZaposlenikId = x.ZaposlenikId,
                   Valid = x.Valid,
                   Zavrsen = x.Zavrsen,
                   DatumPregleda = x.DatumPregleda,
                   DatumRezervacije = x.DatumRezervacije,
                   Opis = x.Pregled.Opis,
                   pacijentNaziv = x.Pacijent.Korisnici.Ime + " " + x.Pacijent.Korisnici.Prezime,
                   zaposlenikNaziv = x.Zaposlenik.Korisnici.Ime + " " + x.Zaposlenik.Korisnici.Prezime
               }).ToList();

            List<TerminiIndexVM.TerminiInfo> SlobTermini = ctx.Termins.Include(x => x.Smjena).Where(x=>x.SmjenaId==rad.SmjenaId).Select(x => new TerminiIndexVM.TerminiInfo
            {
                Id = x.Id,
                Sati = x.Sati,
                Minuti = x.Minuti,
                SmjenaId = x.SmjenaId,
                SmjenaNaziv = x.Smjena.Naziv,
                Valid = x.Valid
            }).ToList();

            List<int> index = new List<int>();

            foreach (RezervacijaIndexVM.RezervacijaInfo t in r)
            {
                foreach (TerminiIndexVM.TerminiInfo z in SlobTermini)
                {
                    if (t.TerminId == z.Id)
                    {
                        index.Add(z.Id);
                    }
                }
            }

            foreach (int i in index)
            {
                SlobTermini.RemoveAll(x => x.Id == i);
            }

            List<SelectListItem> TerminiLista = new List<SelectListItem>();
            TerminiLista.AddRange(SlobTermini.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Sati + " : " + x.Minuti }).ToList());
            
            return TerminiLista;
        }
        public ActionResult Obrisi(int rezervacijaId)
        {
            Rezervacije entity = ctx.Rezervacijes.Find(rezervacijaId);
            Pregled p = ctx.Pregleds.Find(entity.PregledId);
            ctx.Rezervacijes.Remove(entity);            
            ctx.Pregleds.Remove(p);
            

            ctx.SaveChanges();

            return RedirectToAction("Uredi", "Pacijent", new { pacijentId = entity.PacijentId });
        }
  
  	}

}