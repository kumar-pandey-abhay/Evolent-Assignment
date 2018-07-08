using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserMap
    {
        public UserMap(EntityTypeConfiguration<Users> entityTypeConfiguration)
        {
            entityTypeConfiguration.ToTable("Users");
            entityTypeConfiguration.HasKey(p => p.Id).Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            entityTypeConfiguration.Property(u => u.UserName).IsRequired().HasMaxLength(50);
            entityTypeConfiguration.Property(u => u.Password).IsRequired().HasMaxLength(50);
        }
    }
}
