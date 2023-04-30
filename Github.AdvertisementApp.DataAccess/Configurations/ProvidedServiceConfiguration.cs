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
    public class ProvidedServiceConfiguration : IEntityTypeConfiguration<ProvidedService>
    {
        public void Configure(EntityTypeBuilder<ProvidedService> builder)
        {
            //throw new NotImplementedException();

            builder.Property(x => x.Title).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(600).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getDate()");
        }
    }
}
