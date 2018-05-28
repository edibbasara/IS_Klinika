using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS_Klinika.Areas.ModulAdministracija.Models;
using DataAccessKlinika.DAL;
using System.Data.Entity;
using DataAccessKlinika.Model;


namespace IS_Klinika.Areas.ModulAdministracija.Controllers
{
    public class KorisnikController : Controller
    {
        //
        // GET: /ModulAdministracija/Korisnik/
        KlinikaContext ctx = new KlinikaContext();
        public ActionResult Index()
        {
            List<KorisnikIndexVM.KorisnikInfo> Korisnici = ctx.Kosrisnicis.Select(x => new KorisnikIndexVM.KorisnikInfo
            {
                Id=x.Id,
                Ime = x.Ime,
                Prezime=x.Prezime,
                Adresa=x.Adresa,
                Email=x.Email,
                Tel=x.Tel,
                Mob=x.Mob,
                DatumRodjenja=x.DatumRodjenja,
                KorisnickoIme=x.KorisnickoIme,
                Lozinka=x.Lozinka,
                Valid=x.Valid
            }).ToList();

            KorisnikIndexVM Model = new KorisnikIndexVM
            {
                ListaKorisnika = Korisnici,
            };

            return View("Index",Model);
        }

        public ActionResult Uredi(int? Id)
        {

            Korisnici DBKorisnik = ctx.Kosrisnicis.Where(x => x.Id == Id).FirstOrDefault();

            KorisnikUrediVM Model = new KorisnikUrediVM
            {
                Id = DBKorisnik.Id,
                Ime = DBKorisnik.Ime,
                Prezime = DBKorisnik.Prezime,
                Adresa = DBKorisnik.Adresa,
                Email = DBKorisnik.Email,
                Tel = DBKorisnik.Tel,
                Mob = DBKorisnik.Mob,
                DatumRodjenja = DBKorisnik.DatumRodjenja,
                KorisnickoIme = DBKorisnik.KorisnickoIme,
                Lozinka = DBKorisnik.Lozinka,
                Valid = DBKorisnik.Valid
            };



            return View("Uredi",Model);
        }


        public ActionResult Dodaj()
        {
            KorisnikUrediVM Model = new KorisnikUrediVM();
            Model.Valid = true;

            return View("Uredi",Model);
        }
        public ActionResult Snimi(KorisnikUrediVM k)
        {
            Korisnici entity;

            if(k == null || k.Id==0)
            {
                entity = new Korisnici();
                ctx.Kosrisnicis.Add(entity);
            }
            else
            {
                entity = ctx.Kosrisnicis.Find(k.Id);
            }
            
            entity.Ime=k.Ime;
            entity.Prezime=k.Prezime;
            entity.Adresa=k.Adresa;
            entity.KorisnickoIme=k.KorisnickoIme;
            entity.Lozinka=k.Lozinka;
            entity.Email=k.Email;
            entity.Tel=k.Tel;
            entity.Mob=k.Mob;
            entity.DatumRodjenja=k.DatumRodjenja;
            entity.Valid=k.Valid;

            ctx.SaveChanges();

            return RedirectToAction("Index");

        }
        public ActionResult Obrisi(int Id)
        {
            Korisnici k = ctx.Kosrisnicis.Find(Id);


            ctx.Kosrisnicis.Remove(k);

            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}

