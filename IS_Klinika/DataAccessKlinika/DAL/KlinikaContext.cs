using DataAccessKlinika.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DataAccessKlinika.DAL
{
    public class KlinikaContext:DbContext
    {
        public KlinikaContext()
            : base("Name=Connection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Korisnici>().HasOptional(x => x.Zaposlenik).WithRequired(x => x.Korisnici);
            modelBuilder.Entity<Korisnici>().HasOptional(x => x.Pacijent).WithRequired(x => x.Korisnici);
            modelBuilder.Entity<Obracun>().HasOptional(x => x.ObracunDoprinosi).WithRequired(x => x.Obracun);
        }

        public DbSet<RadniRaspored> RadniRasporeds { get; set; }
        public DbSet<Dijagnoza> Dijagnozas { get; set; }
        public DbSet<Doprinosi> Doprinosis { get; set; }
        public DbSet<Klinika> Klinikas { get; set; }
        public DbSet<Korisnici> Kosrisnicis { get; set; }
        public DbSet<KrvnaGrupa> KrvnaGrupas { get; set; }
        public DbSet<Obracun> Obracuns { get; set; }
        public DbSet<Obustave> Obustaves { get; set; }
        public DbSet<Opstina> Opstinas { get; set; }
        public DbSet<Osiguranje> Osiguranjes { get; set; }
        public DbSet<Pacijent> Pacijents { get; set; }
        public DbSet<Pregled> Pregleds { get; set; }
        public DbSet<Proizvod> Proizvods { get; set; }
        public DbSet<Racun> Racuns { get; set; }
        public DbSet<RadnoMjesto> RadnoMjestos { get; set; }
        public DbSet<Recept> Recepts { get; set; }
        public DbSet<Rezervacije> Rezervacijes { get; set; }
        public DbSet<Smjena> Smjenas { get; set; }
        public DbSet<Termin> Termins { get; set; }
        public DbSet<VrstaObustave> VrstaObustaves { get; set; }
        public DbSet<Zaposlenik> Zaposleniks { get; set; }
        public DbSet<ObracunDoprinosi> ObracunDoprinosis { get; set; }
        public DbSet<PDVStope> PDVStopes { get; set; }
        public DbSet<RacunStavke> RacunStavkes { get; set; }
    }
}
