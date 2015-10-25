using HealthyJourney.Data.Configurations;
using HealthyJourney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data
{
    public class HealthyJourneyContext : DbContext
    {

        public HealthyJourneyContext() : base("Name=HealthyJourneyConnection")
        {

        }

        public DbSet<User> Users { get; set; }
       

        public DbSet<Badge> Badges { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<MedicalCenterMetadata> MedicalCenterMetadatas { get; set; }
        public DbSet<ServiceProviderBadge> ServiceProviderBadges { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Configurations.Add(new UserConfiguration());
           
      /*      modelBuilder.Entity<ServiceProvider>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("ServiceProviders");
                
            }); */

        }

    }
}
