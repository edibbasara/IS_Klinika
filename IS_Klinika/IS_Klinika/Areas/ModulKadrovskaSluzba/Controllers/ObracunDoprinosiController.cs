using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessKlinika.DAL;
using DataAccessKlinika.Model;
using IS_Klinika.Areas.ModulKadrovskaSluzba.Models;

namespace IS_Klinika.Areas.ModulKadrovskaSluzba.Controllers
{
    public class ObracunDoprinosiController : Controller
    {
        //
        // GET: /ModulAdministracija/ObracunDoprinosi/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index(int obracunId)
        {
            ObracunDoprinosiIndexVM Model = ctx.ObracunDoprinosis.Include(x => x.Obracun).Include(x => x.Obracun.Doprinosi).Where(x => x.Id == obracunId).Select(x => new ObracunDoprinosiIndexVM
            {
                Id = x.Id,
                Valid = x.Valid,
                PIOizPlate = x.PIOizPlate,
                PIOnaPlatu = x.PIOnaPlatu,
                PoreznaPlatu = x.PoreznaPlatu,
                PorezNaPlatuOsnov = x.PorezNaPlatuOsnov,
                NezapFedIzPlate = x.NezapFedIzPlate,
                NezapFedNaPlatu = x.NezapFedNaPlatu,
                NezapKanIzPlate = x.NezapKanIzPlate,
                NezapKanNaPlatu = x.NezapKanNaPlatu,
                ZastitaOdPrirNepNaPlatu = x.ZastitaOdPrirNepNaPlatu,
                ZdravIzPlate = x.ZdravIzPlate,
                ZdravNaPlatu = x.ZdravNaPlatu,
                ZdravSolidIzPlate = x.ZdravSolidIzPlate,
                ZdravSolidNaPlatu = x.ZdravSolidNaPlatu,

                koefNezapFedIzPlate = x.Obracun.Doprinosi.NezapFedIzPlate,
                koefNezapFedNaPlatu = x.Obracun.Doprinosi.NezapFedNaPlatu,
                koefNezapKanIzPlate = x.Obracun.Doprinosi.NezapKanIzPlate,
                koefNezapKanNaPlatu = x.Obracun.Doprinosi.NezapKanNaPlatu,
                koefPIOizPlate = x.Obracun.Doprinosi.PIOizPlate,
                koefPIOnaPlatu = x.Obracun.Doprinosi.PIOnaPlatu,
                koefPoreznaPlatu = x.Obracun.Doprinosi.PoreznaPlatu,
                koefPorezNaPlatuOsnov = x.Obracun.Doprinosi.PorezNaPlatuOsnov,
                koefZastitaOdPrirNepNaPlatu = x.Obracun.Doprinosi.ZastitaOdPrirNepNaPlatu,
                koefZdravIzPlate = x.Obracun.Doprinosi.ZdravIzPlate,
                koefZdravNaPlatu = x.Obracun.Doprinosi.ZdravNaPlatu,
                koefZdravSolidIzPlate = x.Obracun.Doprinosi.ZdravSolidIzPlate,
                koefZdravSolidNaPlatu = x.Obracun.Doprinosi.ZdravSolidNaPlatu
            }).FirstOrDefault();


            return View("Index", Model);
        }
    }
}