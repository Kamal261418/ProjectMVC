using Demo.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Context
{
    public class MVCAppGr03DbContext:IdentityDbContext<ApplicationUser>
    {
        public MVCAppGr03DbContext(DbContextOptions<MVCAppGr03DbContext> options):base(options)
        {
            Database.EnsureCreated();
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //     => optionsBuilder.UseSqlServer("Server = . ; Database = MVCAppGr03Db ; Trusted_Connection = true , MultipleActiveResultSets = true ");

           public DbSet<Department> departments { get; set; }
            
            public DbSet<Employee> employees { get; set; }



    }
}
