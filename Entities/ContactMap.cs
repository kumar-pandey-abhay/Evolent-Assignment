using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ContactMap
    {
        public ContactMap(EntityTypeConfiguration<Contact> entityTypeConfiguration)
        {
            entityTypeConfiguration.ToTable("Contact");
            entityTypeConfiguration.HasKey(p => p.Id).Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            entityTypeConfiguration.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            entityTypeConfiguration.Property(u => u.LastName).IsRequired().HasMaxLength(50);
            entityTypeConfiguration.Property(u => u.Email).IsRequired().HasMaxLength(50);
            entityTypeConfiguration.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(50);
            entityTypeConfiguration.Property(u => u.Status).IsRequired();
            entityTypeConfiguration.HasRequired(t => t.CreatedByUser).WithMany().HasForeignKey(t => t.CreatedByUserId);
            entityTypeConfiguration.Property(u => u.CreatedDate).IsRequired();
            entityTypeConfiguration.HasOptional(t => t.ModifiedByUser).WithMany().HasForeignKey(t => t.ModifiedByUserId);
            entityTypeConfiguration.Property(u => u.ModifiedDate);
        }
    }
}
