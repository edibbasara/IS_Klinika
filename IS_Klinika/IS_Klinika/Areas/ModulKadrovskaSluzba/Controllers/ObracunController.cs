using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessKlinika.DAL;
using DataAccessKlinika.Model;
using IS_Klinika.Areas.ModulKadrovskaSluzba.Models;
using System.Data.Entity;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Controllers
{
    public class ObracunController : Controller
    {
        //
        // GET: /ModulAdministracija/Obracun/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index(int zaposlenikID)
        {
            List<ObracunIndexVM.ObracunInfo> Obracun = ctx.Obracuns.Include(x => x.Zaposlenik).Include(x => x.Zaposlenik.Korisnici).Include(x => x.Doprinosi).Where(x => x.ZaposlenikId == zaposlenikID).Select(x => new ObracunIndexVM.ObracunInfo
            {
                Id = x.Id,
                Valid = x.Valid,
                ZaposlenikId = x.ZaposlenikId,
                ZaposlenikIme = x.Zaposlenik.Korisnici.Ime + " " + x.Zaposlenik.Korisnici.Prezime,
                Godina = x.Godina,
                Mjesec = x.Mjesec,
                DoprinosiId = x.DoprinosiId,
                DoprinosiNaziv = x.Doprinosi.NazivPlana,
                PeriodOD = x.PeriodOD,
                PeriodDO = x.PeriodDO,
                DatumObracuna = x.DatumObracuna

            }).ToList();

            ObracunIndexVM Model = new ObracunIndexVM
            {
                ObracunList = Obracun,
                ZapId = zaposlenikID
            };

            return View("Index", Model);
        }
        public ActionResult Dodaj(int zaposlenikId)
        {
            Korisnici k = ctx.Kosrisnicis.Find(zaposlenikId);
            ObracunUrediVM Model = new ObracunUrediVM();
            Model.ZaposlenikId = zaposlenikId;
            Model.ZaposlenikImePrezime = k.Ime + " " + k.Prezime;
            Model.Valid = true;
            Model.DatumObracuna = DateTime.UtcNow;
            Model.PeriodDO = null;
            Model.PeriodOD = null;
            Model.DoprinosiList = UcitajDoprinose();
            Model.MjeseciList = UcitajMjesece();
            Model.GodineList = UcitajGodine();

            return View("Uredi", Model);
        }
        private List<SelectListItem> UcitajZaposlenike()
        {
            List<SelectListItem> Zaposlenici = new List<SelectListItem>();
            Zaposlenici.Add(new SelectListItem { Value = null, Text = "Izbor zaposlenika" });
            Zaposlenici.AddRange(ctx.Zaposleniks.Include(x => x.Korisnici).Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Korisnici.Ime + " " + x.Korisnici.Prezime }).ToList());

            return Zaposlenici;
        }
        private List<SelectListItem> UcitajDoprinose()
        {
            List<SelectListItem> Doprinosi = new List<SelectListItem>();
            Doprinosi.Add(new SelectListItem { Value = null, Text = "Izbor plana doprinosa" });
            Doprinosi.AddRange(ctx.Doprinosis.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.NazivPlana }).ToList());

            return Doprinosi;
        }
        private List<SelectListItem> UcitajMjesece()
        {
            List<SelectListItem> Mjeseci = new List<SelectListItem>();

            Mjeseci.Add(new SelectListItem { Value = "Januar", Text = "Januar" });
            Mjeseci.Add(new SelectListItem { Value = "Februar", Text = "Februar" });
            Mjeseci.Add(new SelectListItem { Value = "Mart", Text = "Mart" });
            Mjeseci.Add(new SelectListItem { Value = "April", Text = "April" });
            Mjeseci.Add(new SelectListItem { Value = "Maj", Text = "Maj" });
            Mjeseci.Add(new SelectListItem { Value = "Juni", Text = "Juni" });
            Mjeseci.Add(new SelectListItem { Value = "Juli", Text = "Juli" });
            Mjeseci.Add(new SelectListItem { Value = "August", Text = "August" });
            Mjeseci.Add(new SelectListItem { Value = "Septembar", Text = "Septembar" });
            Mjeseci.Add(new SelectListItem { Value = "Oktobar", Text = "Oktobar" });
            Mjeseci.Add(new SelectListItem { Value = "Novembar", Text = "Novembar" });
            Mjeseci.Add(new SelectListItem { Value = "Decembar", Text = "Decembar" });

            return Mjeseci;
        }
        private List<SelectListItem> UcitajGodine()
        {
            List<SelectListItem> Godine = new List<SelectListItem>();

            Godine.Add(new SelectListItem { Value = "2017", Text = "2017" });
            Godine.Add(new SelectListItem { Value = "2018", Text = "2018" });
            Godine.Add(new SelectListItem { Value = "2019", Text = "2019" });
            Godine.Add(new SelectListItem { Value = "2020", Text = "2020" });

            return Godine;
        }
        public ActionResult Uredi(int obracunId)
        {
            Obracun entity = ctx.Obracuns.Find(obracunId);
            ObracunUrediVM Model = new ObracunUrediVM();
            Model.Id = entity.Id;
            Model.Valid = entity.Valid;
            Model.Mjesec = entity.Mjesec;
            Model.Godina = entity.Godina;
            Model.RPV = entity.RPV;
            Model.PR = entity.PR;
            Model.GO = entity.GO;
            Model.BD42D = entity.BD42D;
            Model.BP42D = entity.BP42D;
            Model.DP = entity.DP;
            Model.RN = entity.RN;
            Model.NS = entity.NS;
            Model.NR = entity.NR;
            Model.RDP = entity.RDP;
            Model.ZaposlenikId = entity.ZaposlenikId;
            Model.DoprinosiId = entity.DoprinosiId;
            Model.PeriodOD = entity.PeriodOD;
            Model.PeriodDO = entity.PeriodDO;
            Model.DatumObracuna = entity.DatumObracuna;
            Model.DoprinosiList = UcitajDoprinose();
            Model.MjeseciList = UcitajMjesece();
            Model.GodineList = UcitajGodine();

            return View("Uredi", Model);
        }
        public ActionResult Snimi(ObracunUrediVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.DoprinosiList = UcitajDoprinose();
                vm.GodineList = UcitajGodine();
                vm.MjeseciList = UcitajMjesece();
                return View("Uredi", vm);
            }
            Obracun entity;
            if (vm == null || vm.Id == 0)
            {
                entity = new Obracun();
                entity.ObracunDoprinosi = new ObracunDoprinosi();
                ctx.Obracuns.Add(entity);
            }
            else
            {
                entity = ctx.Obracuns.Find(vm.Id);
                entity.ObracunDoprinosi = ctx.ObracunDoprinosis.Find(vm.Id);
            }
            Doprinosi dop = ctx.Doprinosis.Find(vm.DoprinosiId);
            Zaposlenik z = ctx.Zaposleniks.Find(vm.ZaposlenikId);
            Klinika k = ctx.Klinikas.Find(z.KlinikaId);

            entity.Id = vm.Id;
            entity.Valid = vm.Valid;
            entity.Mjesec = vm.Mjesec;
            entity.Godina = vm.Godina;
            entity.RPV = vm.RPV;
            entity.PR = vm.PR;
            entity.GO = vm.GO;
            entity.BD42D = vm.BD42D;
            entity.BP42D = vm.BP42D;
            entity.DP = vm.DP;
            entity.RN = vm.RN;
            entity.NS = vm.NS;
            entity.NR = vm.NR;
            entity.RDP = vm.RDP;
            entity.ZaposlenikId = vm.ZaposlenikId;
            entity.DoprinosiId = vm.DoprinosiId;
            entity.PeriodOD = vm.PeriodOD;
            entity.PeriodDO = vm.PeriodDO;
            entity.DatumObracuna = vm.DatumObracuna;

            entity.ObracunDoprinosi.Id = vm.Id;
            entity.ObracunDoprinosi.Valid = vm.Valid;
            entity.ObracunDoprinosi.PIOnaPlatu = dop.PIOnaPlatu * vm.PIOnaPlatu;
            entity.ObracunDoprinosi.PIOizPlate = dop.PIOizPlate * vm.PIOizPlate;
            entity.ObracunDoprinosi.PoreznaPlatu = dop.PoreznaPlatu * vm.PoreznaPlatu;
            entity.ObracunDoprinosi.PorezNaPlatuOsnov = dop.PorezNaPlatuOsnov * vm.PorezNaPlatuOsnov;
            entity.ObracunDoprinosi.ZastitaOdPrirNepNaPlatu = dop.ZastitaOdPrirNepNaPlatu * vm.ZastitaOdPrirNepNaPlatu;
            entity.ObracunDoprinosi.ZdravIzPlate = dop.ZdravIzPlate * vm.ZdravIzPlate;
            entity.ObracunDoprinosi.ZdravNaPlatu = dop.ZdravNaPlatu * vm.ZdravNaPlatu;
            entity.ObracunDoprinosi.ZdravSolidIzPlate = dop.ZdravSolidIzPlate * vm.ZdravSolidIzPlate;
            entity.ObracunDoprinosi.ZdravSolidNaPlatu = dop.ZdravSolidNaPlatu * vm.ZdravSolidNaPlatu;
            entity.ObracunDoprinosi.NezapFedIzPlate = dop.NezapFedIzPlate * vm.NezapFedIzPlate;
            entity.ObracunDoprinosi.NezapFedNaPlatu = dop.NezapFedNaPlatu * vm.NezapFedNaPlatu;
            entity.ObracunDoprinosi.NezapKanIzPlate = dop.NezapKanIzPlate * vm.NezapKanIzPlate;
            entity.ObracunDoprinosi.NezapKanNaPlatu = dop.NezapKanNaPlatu * vm.NezapKanNaPlatu;

            ctx.SaveChanges();

            return RedirectToAction("Uredi", "Zaposlenik", new { korisnikId = vm.ZaposlenikId });
        }
        public ActionResult Obrisi(int obracunId)
        {
            Obracun entity = ctx.Obracuns.Find(obracunId);
            ObracunDoprinosi Dop = ctx.ObracunDoprinosis.Find(obracunId);
            ctx.ObracunDoprinosis.Remove(Dop);
            ctx.Obracuns.Remove(entity);

            ctx.SaveChanges();

            return RedirectToAction("Uredi", "Zaposlenik", new { korisnikId = entity.ZaposlenikId });
        }
    }
}