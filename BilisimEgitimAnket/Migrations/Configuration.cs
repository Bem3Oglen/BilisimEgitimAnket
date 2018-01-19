namespace BilisimEgitimAnket.Migrations
{
    using BilisimEgitimAnket.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;

    internal sealed class Configuration : DbMigrationsConfiguration<BilisimEgitimAnket.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BilisimEgitimAnket.Models.ApplicationDbContext context)
        {
           
                var store = new UserStore<ApplicationUser>(context);
                var manager = new ApplicationUserManager(store);

                var user = new Models.ApplicationUser() { Email = "onur@gmai.com", UserName = "onur@gmail.com" };
                Task<Microsoft.AspNet.Identity.IdentityResult> task = Task.Run(() => manager.CreateAsync(user, "@Anket2306"));

                // Will block until the task is completed...
                var result = task.Result;


                context.SaveChanges();
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
