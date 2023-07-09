using AutoMapper;
using Github.AdvertisementApp.Dtos;
using Github.AdvertisementApp.UI.Models;

namespace Github.AdvertisementApp.UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile : Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>();
        }
    }
}
