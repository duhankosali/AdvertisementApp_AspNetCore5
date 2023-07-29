using Github.AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Dtos
{
    public class AdvertisementAppUserListDto : IDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; } // Foreign Key
        public AdvertisementListDto Advertisement { get; set; } // Navigation Property

        public int AppUserId { get; set; } // Foreign Key
        public AppUserListDto AppUser { get; set; } // Navigation Property

        public int AdvertisementAppUserStatusId { get; set; } // Foreign Key
        public AdvertisementAppUserStatusListDto AdvertisementAppUserStatus { get; set; } // Navigation Property

        public int MilitaryStatusId { get; set; } // Foreign Key
        public MilitaryStatusListDto MilitaryStatus { get; set; } // Navigation Property

        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public string CvPath { get; set; }
    }
}
