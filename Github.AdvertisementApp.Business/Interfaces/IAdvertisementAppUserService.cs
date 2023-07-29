using Github.AdvertisementApp.Common;
using Github.AdvertisementApp.Common.Enums;
using Github.AdvertisementApp.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
        Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type);
        Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type);
    }
}
