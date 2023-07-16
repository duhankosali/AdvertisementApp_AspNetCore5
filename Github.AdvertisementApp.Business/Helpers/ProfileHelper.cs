﻿using AutoMapper;
using Github.AdvertisementApp.Business.Mappings.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new AppRoleProfile(),
            };
        }
    }
}
