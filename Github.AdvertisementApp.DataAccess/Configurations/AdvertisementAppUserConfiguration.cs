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
    public class AdvertisementAppUserConfiguration : IEntityTypeConfiguration<AdvertisementAppUser>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUser> builder)
        {
            //throw new NotImplementedException();

            // Bir kullanıcı bir ilana yalnızca bir kere başvurabilir. Bu nedenle AdvertisementId ve UserId nin aynı olduğu bir alan olamaz.
            builder.HasIndex(x=> new
            {
                x.AdvertisementId,
                x.AppUserId
            }).IsUnique();

            builder.Property(x=>x.CvPath).HasMaxLength(600).IsRequired(); // CV verisi olmak zorundadır.

            builder.HasOne(x => x.Advertisement).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AdvertisementId); // Advertisement ve AdvertisementAppUsers arasında bire çok ilişki kurduk.

            builder.HasOne(x => x.AppUser).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AppUserId); // AppUser ile AdvertisementAppUsers arasında bire çok ilişki kurduk.

            builder.HasOne(x => x.AdvertisementAppUserStatus).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.AdvertisementAppUserStatusId); // AdvertisementAppUserStatus ile AdvertisementAppUsers arasında bire çok ilişki kurduk.

            builder.HasOne(x => x.MilitaryStatus).WithMany(x => x.AdvertisementAppUsers).HasForeignKey(x => x.MilitaryStatusId); // MilitaryStatus ile AdvertisementAppUsers arasında bire çok ilişki kurduk.   
        }
    }
}
