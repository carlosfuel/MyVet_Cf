using Microsoft.EntityFrameworkCore;
using MyVet_Cf.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet_Cf.Web.Data
{
    public class DataContext: IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Agenda> Agendas { get; set; }

        public DbSet<History> Histories { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<PetType> PetTypes { get; set; }

        public DbSet<ServiceType> ServiceTypes { get; set; }

        public DbSet<Manager> Managers { get; set; }
        

    }
}
