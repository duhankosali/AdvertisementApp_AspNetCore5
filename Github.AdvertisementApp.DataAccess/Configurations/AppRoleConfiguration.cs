using Github.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.DataAccess.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            //throw new NotImplementedException();
            builder.Property(x => x.Definition).HasMaxLength(200).IsRequired();

            builder.HasData(new AppRole[]
            {
                new()
                {
                    Definition = "Admin",
                    Id = 1
                },
                new()
                {
                    Definition = "Member",
                    Id = 2
                }
            });
        }
    }
}
