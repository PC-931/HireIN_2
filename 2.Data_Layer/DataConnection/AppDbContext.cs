using _1.Entity_Layer;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Data_Layer
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
    }
}