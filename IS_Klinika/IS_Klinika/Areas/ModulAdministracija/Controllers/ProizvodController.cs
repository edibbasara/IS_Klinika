using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessKlinika.DAL;
using DataAccessKlinika.Model;
using IS_Klinika.Areas.ModulAdministracija.Models;

namespace IS_Klinika.Areas.ModulAdministracija.Controllers
{
    public class ProizvodController : Controller
    {
        //
        // GET: /ModulAdministracija/Proizvod/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<ProizvodIndexVM.ProizvodInfo> Proizvodi = ctx.Proizvods.Select(x => new ProizvodIndexVM.ProizvodInfo
            {
                Id = x.Id,
                Valid = x.Valid,
                Naziv = x.Naziv,
                Cijena = x.Cijena,
                Popust=x.Popust
            }).ToList();
            ProizvodIndexVM Model = new ProizvodIndexVM
            {
                ProizvodiList = Proizvodi
            };
            return View("Index",Model);
        }
        public ActionResult Dodaj()
        {
            ProizvodUrediVM Model = new ProizvodUrediVM();
            Model.Valid = true;

            return View("Uredi", Model);
        }
        public ActionResult Uredi(int proizvodId)
        {
            Proizvod entity = ctx.Proizvods.Find(proizvodId);

            ProizvodUrediVM Model = new ProizvodUrediVM();
            Model.Id = entity.Id;
            Model.Valid = entity.Valid;
            Model.Naziv = entity.Naziv;
            Model.Cijena = entity.Cijena;
            Model.Popust = entity.Popust;

          
            return View("Uredi", Model);
      }
        public ActionResult Snimi(ProizvodUrediVM p)
        {
            if (!ModelState.IsValid)
            {
                return View("Uredi", p);
            }
            Proizvod entity;
            if (p == null || p.Id == 0)
            {
                entity = new Proizvod();
                ctx.Proizvods.Add(entity);
            }
            else
            {
                entity = ctx.Proizvods.Find(p.Id);
            }
            entity.Id = p.Id;
            entity.Valid = p.Valid;
            entity.Naziv = p.Naziv;
            entity.Cijena = p.Cijena;

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Obrisi(int proizvodId)
        {
            Proizvod entity = ctx.Proizvods.Find(proizvodId);
            ctx.Proizvods.Remove(entity);

            ctx.SaveChanges();

            return RedirectToAction("Index");
        
        }
	}
}