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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            //throw new NotImplementedException();
            builder.Property(x => x.Firstname).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.Surname).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.Username).HasMaxLength(200).IsRequired();
            builder.Property(x=>x.PhoneNumber).HasMaxLength(20).IsRequired();
            builder.Property(x=>x.Password).HasMaxLength(50).IsRequired();

            builder.HasOne(x => x.Gender).WithMany(x => x.AppUsers).HasForeignKey(x => x.GenderId); // Bir kişinin yalnızca bir cinsiyeti olabilir. Bire çok ilişki kuruldu.
        }
    }
}
