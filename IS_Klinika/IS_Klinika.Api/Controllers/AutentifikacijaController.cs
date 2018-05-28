using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessKlinika.DAL;
using IS_Klinika.Api.Models;

namespace IS_Klinika.Api.Controllers
{

    public class AutentifikacijaController : ApiController
    {
        KlinikaContext db = new KlinikaContext();
        [HttpGet]
        public AutentifikacijaVM Provjera(string username,string password)
        {
            AutentifikacijaVM model = db.Kosrisnicis.Where(x => x.KorisnickoIme == username && x.Lozinka == password && x.Pacijent != null).Select(x => new AutentifikacijaVM
            {
                Id = x.Id,
                Adresa = x.Adresa,
                AktivacijskiHash = x.Pacijent.AktivacijskiHash,
                DatumRodjenja = x.DatumRodjenja,
                Email = x.Email,
                ImePrezime = x.Ime + " " + x.Prezime,
                IsPotvrdjen = x.Pacijent.IsPotvrdjen,
                KlinikaPac = x.Pacijent.Klinika.Naziv,
                KorisnickoIme = x.KorisnickoIme,
                PacOpstinaPrebivalistaNaziv = x.Pacijent.OpstinaPrebivalista.Naziv,
                Valid = x.Valid,
                RezervacijaList = db.Rezervacijes.Where(y => y.PacijentId == x.Id).Select(y => new AutentifikacijaVM.RezervacijeInfo
                {
                    DatumPregleda = y.DatumPregleda,
                    DatumRezervacije=y.DatumRezervacije,
                    Id=y.Id,
                    PacijentId=y.PacijentId,
                    PacijentNaziv=y.Pacijent.Korisnici.Ime+" "+y.Pacijent.Korisnici.Prezime,
                    PregledId=y.PregledId,
                    TerminId=y.TerminId,
                    Valid = y.Valid,
                    ZaposlenikId=y.ZaposlenikId,
                    ZaposlenikNaziv= y.Zaposlenik.Korisnici.Ime + " " + y.Zaposlenik.Korisnici.Prezime,
                    Zavrsen=y.Zavrsen,
                    Termin=y.Termin.Sati+":"+y.Termin.Minuti
                }).ToList()
            }).SingleOrDefault();

            return model;
        }
    }
}
