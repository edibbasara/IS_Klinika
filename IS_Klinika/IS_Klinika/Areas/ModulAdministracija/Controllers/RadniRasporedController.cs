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
    public class RadniRasporedController : Controller
    {
        //
        // GET: /ModulAdministracija/RadniRaspored/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<RadniRasporedIndexVM.RadniRasporedInfo> RasporedRada = ctx.RadniRasporeds.Include(x => x.Zaposlenik).Include(x => x.Zaposlenik.Korisnici).Include(x => x.Smjena).Select(x => new RadniRasporedIndexVM.RadniRasporedInfo
            {
                Id = x.Id,
                SmjenaId = x.SmjenaId,
                ZaposlenikID = x.ZaposlenikID,
                SmjenaNaziv = x.Smjena.Naziv,
                ImePrezime = x.Zaposlenik.Korisnici.Ime + " " + x.Zaposlenik.Korisnici.Prezime,
                DatumOD = x.DatumOD,
                DatumDO = x.DatumDO,
                Valid = x.Valid
            }).ToList();

            RadniRasporedIndexVM Model = new RadniRasporedIndexVM
            {
                RadniRasporedLista = RasporedRada
            };

            return View("Index",Model);
        }
        public ActionResult Dodaj()
        {
            RadniRasporedUrediVM Model = new RadniRasporedUrediVM();
            Model.ZaposleniciLista = UcitajZaposlenike();
            Model.SmjenaLista = UcitajSmjene();
            Model.Valid = true;

            return View("Uredi", Model);

        }
        private List<SelectListItem> UcitajSmjene()
        {
            List<SelectListItem> SmjeneList = new List<SelectListItem>();
            SmjeneList.Add(new SelectListItem { Value = null, Text = "Izbor smjene" });
            SmjeneList.AddRange(ctx.Smjenas.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Naziv }).ToList());

            return SmjeneList;
        }
        private List<SelectListItem> UcitajZaposlenike()
        {
            List<SelectListItem> ZaposleniciLista = new List<SelectListItem>();
            ZaposleniciLista.Add(new SelectListItem { Value = null, Text = "Izbor zaposlenika" });
            ZaposleniciLista.AddRange(ctx.Zaposleniks.Include(x=>x.Korisnici).Select(x => new SelectListItem{ Value = x.Id.ToString(), Text = x.Korisnici.Ime + " " + x.Korisnici.Prezime }).ToList());

            return ZaposleniciLista;
        }
        public ActionResult Uredi(int rasporedId)
        {
            RadniRaspored entity = ctx.RadniRasporeds.Find(rasporedId);

            RadniRasporedUrediVM Model = new RadniRasporedUrediVM();

            Model.Id = entity.Id;
            Model.SmjenaId = entity.SmjenaId;
            Model.ZaposlenikID = entity.ZaposlenikID;
            Model.DatumOD = entity.DatumOD;
            Model.DatumDO = entity.DatumDO;
            Model.Valid = entity.Valid;
            Model.ZaposleniciLista = UcitajZaposlenike();
            Model.SmjenaLista = UcitajSmjene();

            return View("Uredi",Model);
        }
        public ActionResult Snimi(RadniRasporedUrediVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.SmjenaLista=UcitajSmjene();
                vm.ZaposleniciLista=UcitajZaposlenike();

                return View("Uredi", vm);
            }
            RadniRaspored entity;
            if (vm == null || vm.Id == 0)
            {
                entity = new RadniRaspored();
                ctx.RadniRasporeds.Add(entity);
            }
            else
            {
                entity = ctx.RadniRasporeds.Find(vm.Id);
            }

            entity.Id = vm.Id;
            entity.SmjenaId = vm.SmjenaId;
            entity.ZaposlenikID = vm.ZaposlenikID;
            entity.DatumOD = vm.DatumOD;
            entity.DatumDO = vm.DatumDO;
            entity.Valid = vm.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Obrisi(int rasporedId)
        {
            RadniRaspored entity = ctx.RadniRasporeds.Find(rasporedId);
            ctx.RadniRasporeds.Remove(entity);

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}