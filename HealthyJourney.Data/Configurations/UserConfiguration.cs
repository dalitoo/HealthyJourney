using HealthyJourney.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyJourney.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
             Map<Admin>(b => b.ToTable("Admins"));
             Map<Consultant>(b => b.ToTable("Consultants"));
             Map<Client>(b => b.ToTable("Clients"));
            Map<MedicalCenter>(b => b.ToTable("MedicalCenters"));
            Map<Insurance>(b => b.ToTable("Insurances"));
            Map<Doctor>(b => b.ToTable("Doctors"));




            Property(u => u.UserName)
                .HasColumnName("username")
                .HasMaxLength(8)
                .IsRequired();

            Property(u => u.Email).IsRequired();
            Property(u => u.Password).HasMaxLength(8).IsRequired();


        }
    }
}
