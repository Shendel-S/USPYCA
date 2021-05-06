using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace USPYCA.Models
{
    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet <Ciudadano> Ciudadanos { get; set; }
        public DbSet <Direccion> Direcciones { get; set; }
        public DbSet <Solicitud> Solicitudes { get; set; }
        public DbSet <Ubicacion> Ubicaciones { get; set; }

        public DbSet <Tramite> Tramites { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating (DbModelBuilder modelBuilder)
            {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Ciudadano>().ToTable("Ciudadano", "USPYCA");
            modelBuilder.Entity<Direccion>().ToTable("Direccion", "USPYCA");
            modelBuilder.Entity<Solicitud>().ToTable("Solicitud", "USPYCA");
            modelBuilder.Entity<Ubicacion>().ToTable("Ubicacion", "USPYCA");
            modelBuilder.Entity<Tramite>().ToTable("Tramite", "USPYCA");


            base.OnModelCreating(modelBuilder);

            }

    }
}
