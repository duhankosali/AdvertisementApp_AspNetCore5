﻿using AutoMapper;
using Github.AdvertisementApp.Dtos;
using Github.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AppRoleProfile : Profile
    {
        public AppRoleProfile()
        {
            CreateMap<AppRole, AppRoleListDto>().ReverseMap();
            CreateMap<AppRole, AppRoleCreateDto>().ReverseMap();
            CreateMap<AppRole, AppRoleUpdateDto>().ReverseMap();
        }
    }
}
