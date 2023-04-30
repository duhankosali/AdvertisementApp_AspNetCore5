using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Entities
{
    public class AdvertisementAppUser : BaseEntity
    {
        public int AdvertisementId { get; set; } // Foreign Key
        public Advertisement Advertisement { get; set; } // Navigation Property

        public int AppUserId { get; set; } // Foreign Key
        public AppUser AppUser { get; set; } // Navigation Property

        public int AdvertisementAppUserStatusId { get; set; } // Foreign Key
        public AdvertisementAppUserStatus AdvertisementAppUserStatus { get; set; } // Navigation Property

        public int MilitaryStatusId { get; set; } // Foreign Key
        public MilitaryStatus MilitaryStatus { get; set; } // Navigation Property

        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }
    }
}
