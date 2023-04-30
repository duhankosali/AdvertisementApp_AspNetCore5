using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Entities
{
    public class AppUserRole
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }    
    }
}
