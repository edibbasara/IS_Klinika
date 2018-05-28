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
    public class OsiguranjeController : Controller
    {
        //
        // GET: /ModulAdministracija/Osiguranje/
        KlinikaContext ctx = new KlinikaContext();

        public ActionResult Index(int id)
        {
            List<OsiguranjeIndexVM.osiguranjeInfo> Osiguranje = ctx.Osiguranjes.Where(x => x.PacijentId == id).Select(x => new OsiguranjeIndexVM.osiguranjeInfo
            {
                Id = x.Id,
                PacijentId = x.PacijentId,
                NazivPoslodavca = x.NazivPoslodavca,
                Adresa = x.Adresa,
                OpstinaId = x.OpstinaId,
                OpstinaNaziv = x.Opstina.Naziv,
                RadnoMjesto = x.RadnoMjesto,
                OsiguranOd = x.OsiguranOd,
                OsiguranDo = x.OsiguranDo,
                Valid = x.Valid
            }).ToList();

            OsiguranjeIndexVM Model = new OsiguranjeIndexVM
            {
                OsiguranjeLista = Osiguranje,
                pacId=id
            };

            return View("Index", Model);
        }

        public ActionResult Dodaj(int pacijentId)
        {
            Korisnici k= ctx.Kosrisnicis.Find(pacijentId);
            OsiguranjeUrediVM Model = new OsiguranjeUrediVM();
            Model.OpstineList = UcitajOpstine();
            Model.PacijentId = pacijentId;
            Model.Valid = true;
            Model.PacijentImePrezime = k.Ime + " " + k.Prezime;

            return View("Uredi", Model);
        }
        private List<SelectListItem> UcitajOpstine()
        {
            List<SelectListItem> Opstine = new List<SelectListItem>();
            Opstine.Add(new SelectListItem { Value = null, Text = "Izaberi općinu" });
            Opstine.AddRange(ctx.Opstinas.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());

            return Opstine;
        }
        public ActionResult Uredi(int osiguranjeId)
        {
            Osiguranje entity = ctx.Osiguranjes.Include(x => x.Pacijent).Include(x=>x.Opstina).Include(x => x.Pacijent.Korisnici).Where(x => osiguranjeId == x.Id).FirstOrDefault();

            OsiguranjeUrediVM Model = new OsiguranjeUrediVM();
            Model.Id = entity.Id;
            Model.Valid = entity.Valid;
            Model.NazivPoslodavca = entity.NazivPoslodavca;
            Model.Adresa = entity.Adresa;
            Model.OpstinaId = entity.OpstinaId;
            Model.OpstinaNaziv = entity.Opstina.Naziv;
            Model.LicniBrOsig = entity.LicniBrOsig;
            Model.RegBr = entity.RegBr;
            Model.Zajednica = entity.Zajednica;
            Model.RadnoMjesto = entity.RadnoMjesto;
            Model.OsiguranOd = entity.OsiguranOd;
            Model.OsiguranDo = entity.OsiguranDo;
            Model.PacijentId = entity.PacijentId;
            Model.PacijentImePrezime = entity.Pacijent.Korisnici.Ime + ' ' + entity.Pacijent.Korisnici.Prezime;
            Model.OpstineList = UcitajOpstine();

            return View("Uredi", Model);
        }
        public ActionResult Snimi(OsiguranjeUrediVM o)
        {
            if (!ModelState.IsValid)
            {
                o.OpstineList = UcitajOpstine();
                return View("Uredi", o);
            }
            Osiguranje entity;
            if (o == null || o.Id == 0)
            {
                entity = new Osiguranje();
                ctx.Osiguranjes.Add(entity);
            }
            else
            {
                entity = ctx.Osiguranjes.Find(o.Id);
            }

            entity.Id = o.Id;
            entity.Valid = o.Valid;
            entity.NazivPoslodavca = o.NazivPoslodavca;
            entity.Adresa = o.Adresa;
            entity.OpstinaId = o.OpstinaId;
            entity.LicniBrOsig = o.LicniBrOsig;
            entity.RegBr = o.RegBr;
            entity.Zajednica = o.Zajednica;
            entity.RadnoMjesto = o.RadnoMjesto;
            entity.OsiguranOd = o.OsiguranOd;
            entity.OsiguranDo = o.OsiguranDo;
            entity.PacijentId = o.PacijentId;

            ctx.SaveChanges();

            return RedirectToAction("Uredi", "Pacijent" ,new { pacijentId = o.PacijentId });
        }
    }
}