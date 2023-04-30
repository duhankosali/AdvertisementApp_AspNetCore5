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
    public class AdvertisementAppUserStatusConfiguration : IEntityTypeConfiguration<AdvertisementAppUserStatus>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUserStatus> builder)
        {
            //throw new NotImplementedException();

            // AdvertisementAppUsers ile AdvertisementAppUserStatus arasındaki ilişkiyi "AdvertisementAppUserConfiguration.cs" dosyasında belirttik. Burada tekrardan belirtmemize gerek yok. ***

            builder.Property(x => x.Definition).HasMaxLength(500);

        }
    }
}
