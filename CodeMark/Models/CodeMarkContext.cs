using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CodeMark.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class CodeMarkContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Recommendation> Recommendations { get; set; }
        public DbSet<Image> Images { get; set; }
        public CodeMarkContext()
            : base("CodeMarkContext", throwIfV1Schema: false)
        {
            Database.SetInitializer<CodeMarkContext>(new CreateDatabaseIfNotExists<CodeMarkContext>());
        }

        public static CodeMarkContext Create()
        {
            return new CodeMarkContext();
        }
    }
    //public class CodeMarkContext : DbContext
    //{
    //    public DbSet<Recommendation> Recommendations { get; set; }
    //    public DbSet<Image> Images { get; set; }

    //    public CodeMarkContext() : base("CodeMarkContext")
    //    {
    //        Database.SetInitializer<CodeMarkContext>(new CreateDatabaseIfNotExists<CodeMarkContext>());
    //    }

    //}
    //public class CodeMarkContextInitializer : CreateDatabaseIfNotExists<CodeMarkContext>
    //{
    //    protected override void Seed(CodeMarkContext context)
    //    {
    //        var images = context.Images;
    //        images.Add(new Image("name", null));
    //        context.SaveChanges();
    //        base.Seed(context);
    //    }
    //}
}
