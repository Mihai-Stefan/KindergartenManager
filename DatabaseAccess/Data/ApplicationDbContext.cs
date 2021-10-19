using DataAcesss.Data;
using DatabaseAccess.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Kid> Kids { get; set; }
        public DbSet<KidImage> KidImages { get; set; }
        public DbSet<KidParent> KidParents { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<KgFacility> KgFacilities { get; set; }

        public DbSet<KidComment> KidComments { get; set; }
    }
}
