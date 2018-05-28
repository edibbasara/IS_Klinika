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
    public class PregledController : Controller
    {
        //
        // GET: /ModulAdministracija/Pregled/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index(int? pacijentId)
        {
            List<PregledIndexVM.PregledInfo> Pregledi = ctx.Rezervacijes.
                Include(x=>x.Pacijent).
                Include(x=>x.Zaposlenik).Include(x=>x.Pregled).
                Include(x=>x.Pacijent.Korisnici).
                Include(x=>x.Zaposlenik.Korisnici).Where(x=> !pacijentId.HasValue || pacijentId == x.PacijentId && x.Zavrsen == true).Select(x => new PregledIndexVM.PregledInfo
            {
                Id=x.PregledId,
                HistorijaBolesti=x.Pregled.HistorijaBolesti,
                Opis=x.Pregled.Opis,
                Valid=x.Valid,
                PacijentId=x.PacijentId,
                PacijentNaziv=x.Pacijent.Korisnici.Ime+" "+x.Pacijent.Korisnici.Prezime,
                zaposlenikId=x.ZaposlenikId,
                zaposlenikNaziv=x.Zaposlenik.Korisnici.Ime+" "+x.Zaposlenik.Korisnici.Prezime,
                datumPregleda=x.DatumPregleda,
                Zavrsen=x.Zavrsen
            }).ToList();

            PregledIndexVM Model = new PregledIndexVM
            {
                PregledLista = Pregledi
            };

            return View("Index",Model);
        }
        public ActionResult Uredi(int pregledId)
        {
            Pregled entity = ctx.Pregleds.Find(pregledId);
            DijagnozaUrediVM dVM = ctx.Dijagnozas.Where(x=>x.PregledId==pregledId).Select(x=> new DijagnozaUrediVM{
             Id=x.Id,
             Opis=x.Opis,
             PregledId=x.PregledId,
             Valid=x.Valid
            }).FirstOrDefault();
            
            PregledUrediVM Model = new PregledUrediVM();
            Model.Id = entity.Id;
            Model.Opis = entity.Opis;
            Model.Valid = entity.Valid;

            return View("Uredi", Model);
        }
        
	}
}