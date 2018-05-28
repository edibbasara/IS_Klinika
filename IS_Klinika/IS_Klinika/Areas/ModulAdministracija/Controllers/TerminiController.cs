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
    public class TerminiController : Controller
    {
        //
        // GET: /ModulAdministracija/Termini/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index(int smjenaId)
        {
            List<TerminiIndexVM.TerminiInfo> Termini = ctx.Termins.Include(x => x.Smjena).Where(x=>x.SmjenaId==smjenaId).Select(x => new TerminiIndexVM.TerminiInfo
            {
                Id = x.Id,
                Sati = x.Sati,
                Minuti = x.Minuti,
                SmjenaId = x.SmjenaId,
                SmjenaNaziv = x.Smjena.Naziv,
                Valid = x.Valid
            }).ToList();

            TerminiIndexVM Model = new TerminiIndexVM{
               TerminiList=Termini,
               SmjID=smjenaId
            };

            return View("Index",Model);
        }
        public ActionResult Dodaj(int smjenaId)
        {
            Smjena s=ctx.Smjenas.Find(smjenaId);
            TerminiUrediVM Model = new TerminiUrediVM();
            Model.SmjenaNaziv = s.Naziv;
            Model.SmjenaId = smjenaId;
            Model.Valid = true;

            return View("Uredi", Model);
        }
        public ActionResult Uredi(int terminId)
        {
            Termin entity = ctx.Termins.Include(x=>x.Smjena).Where(x=>x.Id==terminId).FirstOrDefault();
            TerminiUrediVM Model = new TerminiUrediVM();
            Model.Id = entity.Id;
            Model.Sati = entity.Sati;
            Model.Minuti = entity.Minuti;
            Model.SmjenaId = entity.SmjenaId;
            Model.Valid = entity.Valid;
            Model.SmjenaNaziv = entity.Smjena.Naziv;

            return View("Uredi", Model);
        }
        public List<SelectListItem> UcitajSmjene()
        {
            List<SelectListItem> Smjene = new List<SelectListItem>();
            Smjene.Add(new SelectListItem { Value = null, Text = "Izbor smjene" });
            Smjene.AddRange(ctx.Smjenas.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());

            return Smjene;
        }
        public ActionResult Snimi(TerminiUrediVM vm)
        {
            if(!ModelState.IsValid)
            {
                return View("Uredi", vm);
            }
            Termin entity;
            if (vm == null || vm.Id == 0)
            {
                entity = new Termin();
                ctx.Termins.Add(entity);
            }
            else
            {
                entity = ctx.Termins.Find(vm.Id);
            }

            entity.Id = vm.Id;
            entity.Sati = vm.Sati;
            entity.Minuti = vm.Minuti;
            entity.SmjenaId = vm.SmjenaId;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index", "Smjena",new { });
        }
        public ActionResult Obrisi(int terminId)
        {
            Termin entity = ctx.Termins.Find(terminId);
            ctx.Termins.Remove(entity);

            ctx.SaveChanges();

            return RedirectToAction("Index","Smjena", new { });
        }
        //public ActionResult Izbor(int zaposlenikId,DateTime datumPregleda)
        //{
           
        //    List<RezervacijaIndexVM.RezervacijaInfo> r = ctx.Rezervacijes
        //        .Include(x=>x.Pregled)
        //        .Include(x => x.Zaposlenik)
        //        .Include(x => x.Termin).
        //        Include(x=>x.Pacijent).
        //        Include(x=>x.Pacijent.Korisnici)
        //        .Include(x=>x.Zaposlenik.Korisnici).Where(x=>x.ZaposlenikId==zaposlenikId && datumPregleda==x.DatumPregleda).Select(x => new RezervacijaIndexVM.RezervacijaInfo
        //    {

        //        Id = x.Id,
        //        PacijentId = x.PacijentId,
        //        PregledId = x.PregledId,
        //        TerminId = x.TerminId,
        //        ZaposlenikId = x.ZaposlenikId,
        //        Valid = x.Valid,
        //        Zavrsen = x.Zavrsen,
        //        DatumPregleda = x.DatumPregleda,
        //        DatumRezervacije = x.DatumRezervacije,
        //        Opis=x.Pregled.Opis,
        //        Placen=x.Pregled.Placen,
        //        pacijentNaziv=x.Pacijent.Korisnici.Ime+" "+x.Pacijent.Korisnici.Prezime,
        //        zaposlenikNaziv=x.Zaposlenik.Korisnici.Ime+" "+x.Zaposlenik.Korisnici.Prezime                
        //    }).ToList();

        //    List<TerminiIndexVM.TerminiInfo> SlobTermini = ctx.Termins.Include(x => x.Smjena).Select(x => new TerminiIndexVM.TerminiInfo
        //    {
        //        Id = x.Id,
        //        Sati = x.Sati,
        //        Minuti = x.Minuti,
        //        SmjenaId = x.SmjenaId,
        //        SmjenaNaziv = x.Smjena.Naziv,
        //        Valid = x.Valid
        //    }).ToList();

        //    List<int> index = new List<int>();
            
        //    foreach (RezervacijaIndexVM.RezervacijaInfo t in r)
        //    {
        //        foreach (TerminiIndexVM.TerminiInfo z in SlobTermini)
        //        {
        //            if (t.TerminId == z.Id)
        //            {                        
        //                index.Add(z.Id);
        //            }
        //        }
        //    }

        //    foreach (int i in index)
        //    {
        //        SlobTermini.RemoveAll(x=>x.Id == i);
        //    }
      
        //    TerminiIndexVM Model = new TerminiIndexVM{
        //        TerminiList=SlobTermini
        //    };            
            
        //    return View("Izbor", Model);                
        //}
	}
}