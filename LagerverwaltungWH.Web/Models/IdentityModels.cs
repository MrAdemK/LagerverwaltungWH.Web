using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using LagerverwaltungWH.Model.DatabaseModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LagerverwaltungWH.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Geschäftsfall> Geschäftsfalle { get; set; }
        public virtual DbSet<Lagerartikel> Lagerartikeln { get; set; }
        public virtual DbSet<Lagerbewegung> Lagerbewegungen { get; set; }
        public virtual DbSet<Mengeneinheit> Mengeneinheiten { get; set; }
        public virtual DbSet<Vorgangstyp> Vorgangstypen { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}