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
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            //throw new NotImplementedException();

            // Bir rol bir kullanıcıya yalnızca bir kere atanabilir. Bu nedenle bir Index yazıyoruz.
            // Örneğin {UserId==1, RoleId==5} bu veriden 2 tane olamaz. Yalnızca 1 tane bulunabilir. 
            builder.HasIndex(x=> new
            {
                x.AppRoleId,
                x.AppUserId
            }).IsUnique();

            builder.HasOne(x => x.AppRole).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.AppRoleId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.AppUserId);
            
        }
    }
}
