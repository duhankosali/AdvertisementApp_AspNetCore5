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
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            //throw new NotImplementedException();

            // AppUser ile Gender arasındaki ilişkiyi "AppUserConfiguration.cs" 'de kurduk bu nedenle tekrardan yapmamızı ihtiyaç yok.

            builder.Property(x => x.Definition).HasMaxLength(300);

            
        }
    }
}
