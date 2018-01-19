using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BilisimEgitimAnket.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Kelime> Kelimeler { get; set; }
        public DbSet<KIRMIZI> Kirmiziler { get; set; }
        public DbSet<SARI> Sariler { get; set; }
        public DbSet<MAVI> Maviler { get; set; }
        public DbSet<YESIL> Yesiller { get; set; }
        public DbSet<Firma> Firmalar { get; set; }
        public DbSet<Kullanici> Kullaniciler { get; set; }
        public DbSet<Sonuc> Sonuclar { get; set; }

        public ApplicationDbContext():base("DefaultConnection",throwIfV1Schema:false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, BilisimEgitimAnket.Migrations.Configuration>("DefaultConnection"));
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // tablo ısımlerıne gelen 's' takısını eklemıyor bunu kullanmazsan 'kullanicilars'
            // olacak...
            modelBuilder.Entity<IdentityUserRole>()
            .HasKey(r => new { r.UserId, r.RoleId })
            .ToTable("AspNetUserRoles");

            modelBuilder.Entity<IdentityUserLogin>()
                        .HasKey(L => new { L.LoginProvider, L.ProviderKey, L.UserId })
                        .ToTable("AspNetUserLogins");            
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}