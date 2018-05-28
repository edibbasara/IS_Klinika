using System;
using System.Data.Entity;
using DataAccessKlinika.DAL;
using DataAccessKlinika.Model;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_Klinika.Areas.ModulAdministracija.Models;

namespace IS_Klinika.Areas.ModulAdministracija.Controllers
{
    public class KlinikaController : Controller
    {
        //
        // GET: /ModulAdministracija/Klinika/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<KlinikeIndexVM.KlinikaInfo> Klinike = ctx.Klinikas.Include(x=>x.Opstina).Select(x => new KlinikeIndexVM.KlinikaInfo
            {
                Id = x.Id,
                Valid = x.Valid,
                Sifra = x.Sifra,
                Naziv = x.Naziv,
                Vrsta = x.Vrsta,
                Adresa = x.Adresa,
                OpstinaId = x.OpstinaId,
                OpstinaNaziv = x.Opstina.Naziv,
                IdBroj = x.IdBroj,
                PDVbroj = x.PDVbroj,
                ZdravInstitBr = x.ZdravInstitBr,
                KoefRPV = x.KoefRPV,
                KoefPR = x.KoefPR,
                KoefGO = x.KoefGO,
                KoefBD42D = x.KoefBD42D,
                KoefBP42D = x.KoefBP42D,
                KoefRN = x.KoefRN,
                KoefNR = x.KoefNR,
                KoefNS = x.KoefNS,
                KoefRDP = x.KoefRDP
            }).ToList();

            KlinikeIndexVM Model = new KlinikeIndexVM
            {
                ListaKlinika = Klinike
            };

            return View("Index",Model);
        }

        public ActionResult Uredi(int? Id)
        {

            Klinika DBKlinika = ctx.Klinikas.Include(x=>x.Opstina).
                Where(x=>x.Id == Id).FirstOrDefault();

            KlinikaUrediVM Model = new KlinikaUrediVM
            {
                Id = DBKlinika.Id,
                Sifra = DBKlinika.Sifra,
                Naziv = DBKlinika.Naziv,
                OpstinaId = DBKlinika.OpstinaId,
                Vrsta = DBKlinika.Vrsta,
                Adresa = DBKlinika.Adresa,
                IdBroj = DBKlinika.IdBroj,
                PDVbroj = DBKlinika.PDVbroj,
                ZdravInstitBr = DBKlinika.ZdravInstitBr,
                KoefRPV = DBKlinika.KoefRPV,
                KoefPR = DBKlinika.KoefPR,
                KoefGO = DBKlinika.KoefGO,
                KoefBD42D = DBKlinika.KoefBD42D,
                KoefBP42D = DBKlinika.KoefBP42D,
                KoefRN = DBKlinika.KoefRN,
                KoefNS = DBKlinika.KoefNS,
                KoefNR = DBKlinika.KoefNR,
                KoefRDP = DBKlinika.KoefRDP,
                Valid = DBKlinika.Valid

            };

            Model.OpstineList = UcitajOpstine();
            
            

            return View("Uredi", Model);
        }
        public ActionResult Dodaj()
        {
            KlinikaUrediVM Model = new KlinikaUrediVM();

            List<SelectListItem> Opstine = UcitajOpstine();
            Model.OpstineList = Opstine;
            Model.Valid = true;

            return View("Uredi", Model);
        }
        
        public ActionResult Snimi(KlinikaUrediVM k)
        {
            if (!ModelState.IsValid)
            {
                k.OpstineList = UcitajOpstine();
                return View("Uredi", k);
            }
            Klinika entity;

            if (k == null || k.Id==0)
            {
                entity = new Klinika();
                ctx.Klinikas.Add(entity);
            }
            else
            {
                entity = ctx.Klinikas.Find(k.Id);
            }

            entity.Sifra=k.Sifra;
            entity.Naziv=k.Naziv;
            entity.OpstinaId = k.OpstinaId;
            entity.Vrsta=k.Vrsta;
            entity.Adresa=k.Adresa;
            entity.IdBroj=k.IdBroj;
            entity.PDVbroj=k.PDVbroj;
            entity.ZdravInstitBr=k.ZdravInstitBr;
            entity.KoefRPV=k.KoefRPV;
            entity.KoefPR=k.KoefPR;
            entity.KoefGO=k.KoefGO;
            entity.KoefBD42D=k.KoefBD42D;
            entity.KoefBP42D=k.KoefBP42D;
            entity.KoefRN=k.KoefRN;
            entity.KoefNS=k.KoefNS;
            entity.KoefNR=k.KoefNR;
            entity.KoefRDP=k.KoefRDP;
            entity.Valid = k.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Obrisi(int Id)
        {
            Klinika entity = ctx.Klinikas.Find(Id);
            ctx.Klinikas.Remove(entity);

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        private List<SelectListItem> UcitajOpstine()
        {
            List<SelectListItem> ListaOpstina =new List<SelectListItem>();

            ListaOpstina.Add(new SelectListItem { Value = null, Text = "Izaberi opstinu" });
            ListaOpstina.AddRange(ctx.Opstinas.Select(x=> new SelectListItem{
                Value=x.Id.ToString(),
                Text=x.Naziv
            }).ToList());            
            
            return ListaOpstina;
        }
	}
}