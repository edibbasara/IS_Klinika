using IS_Klinika.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccessKlinika.DAL;

namespace IS_Klinika.Api.Controllers
{
    public class PacijentKartonController : ApiController
    {
        KlinikaContext db = new KlinikaContext();
        public int PacijentId;
        public int DijagnozaID;
        [HttpGet]
        public PacijentKartonVM Pregled(int PregledID)
        {
            PacijentId = db.Rezervacijes.Where(a => a.PregledId == PregledID).Select(a => a.PacijentId).FirstOrDefault();
            DijagnozaID = db.Dijagnozas.Where(y => y.PregledId == PregledID).Select(y => y.Id).FirstOrDefault();

            PacijentKartonVM model = db.Pregleds.Where(x => x.Id == PregledID).Select(x => new PacijentKartonVM
            {
                DijagnozaId = DijagnozaID,
                DijagnozaOpis = db.Dijagnozas.Where(y => y.PregledId == PregledID).Select(y => y.Opis).FirstOrDefault(),
                HistorijaBolesti = x.HistorijaBolesti,
                Opis = x.Opis,
                Id = x.Id,
                Valid = x.Valid,
                OsiguranjeList = db.Osiguranjes.Where(z => z.PacijentId == PacijentId).Select(z => new PacijentKartonVM.OsiguranjeInfo
                {
                    Adresa = z.Adresa,
                    Id = z.Id,
                    LicniBrOsig = z.LicniBrOsig,
                    NazivPoslodavca = z.NazivPoslodavca,
                    OpstinaNaziv = z.Opstina.Naziv,
                    OsiguranDo = z.OsiguranDo,
                    OsiguranOd = z.OsiguranOd,
                    PacijentId = z.PacijentId,
                    Zajednica = z.Zajednica,
                    RadnoMjesto = z.RadnoMjesto,
                    RegBr = z.RegBr,
                    Valid = z.Valid
                }).ToList(),
                ReceptList = db.Recepts.Where(s => s.DijagnozaId == DijagnozaID).Select(s => new PacijentKartonVM.ReceptInfo
                {
                    DijagnozaId = DijagnozaID,
                    Id = s.Id,
                    Naziv = s.Naziv,
                    Upotreba = s.Upotreba,
                    Valid = s.Valid,
                    Vrsta = s.Vrsta
                }).ToList(),
                RacunList = db.Racuns.Where(b => b.PregledId == PregledID).Select(b => new PacijentKartonVM.RacunInfo
                {
                    Datum = b.Datum,
                    Id = b.Id,
                    IznosBezPDVUkupno = b.IznosBezPDVUkupno,
                    IznosUkupno = b.IznosUkupno,
                    PDVIznosUkupno = b.PDVIznosUkupno,
                    Popust = b.Popust,
                    PregledId = b.PregledId,
                    Valid = b.Valid,
                    RacunStavkaList = db.RacunStavkes.Where(c => c.RacunId == b.Id).Select(c => new PacijentKartonVM.RacunInfo.RacunStavkaInfo
                    {
                        Id = c.Id,
                        Kolicina = c.Kolicina,
                        NazivProizvod = c.Proizvod.Naziv,
                        PDVstopa = c.PDVStope.PDV,
                        PDVStopeId = c.PDVStopeId,
                        ProizvodId = c.ProizvodId,
                        RacunId = c.RacunId,
                        Valid = c.Valid,
                        Cijena = c.Proizvod.Cijena,
                        IznosBezPDV=c.Proizvod.Cijena*c.Kolicina,
                        IznosPDV= (c.Proizvod.Cijena * c.Kolicina)*(c.PDVStope.PDV/100),
                        IznosSaPDV= c.Proizvod.Cijena * c.Kolicina+ (c.Proizvod.Cijena * c.Kolicina) * (c.PDVStope.PDV / 100)
                    }).ToList()
                }).ToList()
            }).SingleOrDefault();

            return model;
        }
        
    }
}
