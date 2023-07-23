using Microsoft.AspNetCore.Http;
using System;

namespace Github.AdvertisementApp.UI.Models
{
    public class AdvertisementAppUserCreateModal
    {
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }
        public int AdvertisementAppUserStatusId { get; set; }
        public int MilitaryStatusId { get; set; }
        public DateTime? EndDate { get; set; }
        public int WorkExperience { get; set; }
        public IFormFile CvFile { get; set; }
    }
}
