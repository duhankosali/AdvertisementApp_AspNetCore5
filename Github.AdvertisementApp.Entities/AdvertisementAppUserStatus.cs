using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Entities
{
    public class AdvertisementAppUserStatus : BaseEntity
    {
        public string Definition { get; set; }
        public List<AdvertisementAppUser> AdvertiesementAppUser { get; set; }
    }
}
