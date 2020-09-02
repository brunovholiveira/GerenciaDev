using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GDev.WebApp.ViewModels;

namespace GDev.WebApp.Data
{
    public class ApplicationContextDB : IdentityDbContext<IdentityUser>
    {
        public ApplicationContextDB(DbContextOptions<ApplicationContextDB> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<GDev.WebApp.ViewModels.AcessoViewModel> AcessoViewModel { get; set; }
    }
}
