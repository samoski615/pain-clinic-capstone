using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PainClinic.Models;

[assembly: OwinStartupAttribute(typeof(PainClinic.Startup))]
namespace PainClinic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
            app.MapSignalR();
        }

        //this method creates default User roles 
        private void CreateRolesAndUsers()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            //Creating Customer Role
            if (!roleManager.RoleExists("Patient"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Patient";
                roleManager.Create(role);
            }
            //Creating Employee Role
            if (!roleManager.RoleExists("Provider"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Provider";
                roleManager.Create(role);
            }
        }
    }
}
