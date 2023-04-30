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
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement> // Advertisement sınıfımızın veritabanı tablosunda bulunmasını istediğimiz özellikleri yazıyoruz. Bunu yaparken EntityFramework paketinin sunmuş olduğu "IEntityTypeConfiguration" interface'inden yararlanıyoruz.
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            //throw new NotImplementedException();
            builder.Property(x => x.Title).HasMaxLength(200);
            builder.Property(x=>x.Description).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getDate()");
        }
    }
}
