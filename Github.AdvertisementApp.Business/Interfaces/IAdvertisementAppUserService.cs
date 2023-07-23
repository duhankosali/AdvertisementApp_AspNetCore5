using Github.AdvertisementApp.Common;
using Github.AdvertisementApp.Dtos;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
    }
}
