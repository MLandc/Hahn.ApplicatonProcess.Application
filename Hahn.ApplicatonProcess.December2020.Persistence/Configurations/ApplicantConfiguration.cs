using Hahn.ApplicatonProcess.December2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hahn.ApplicatonProcess.December2020.Persistence.Configurations
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired();

            builder.Property(e => e.Adress)
               .IsRequired();

            builder.Property(e => e.Age)
               .IsRequired();

            builder.Property(e => e.CountryOfOrigin)
               .IsRequired();

            builder.Property(e => e.EMailAdress)
               .IsRequired();

            builder.Property(e => e.FamilyName)
               .IsRequired();

            builder.Property(e => e.Hired)
               .IsRequired();            
        }
    }
}
