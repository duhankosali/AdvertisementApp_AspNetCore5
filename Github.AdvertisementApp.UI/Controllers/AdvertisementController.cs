using Github.AdvertisementApp.Business.Interfaces;
using Github.AdvertisementApp.Dtos;
using Github.AdvertisementApp.Dtos.Interfaces;
using Github.AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appUserService;
        public AdvertisementController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member")] // Başvuru yapmak için 'Member' rolüne sahip olunmalı.
        public async Task<IActionResult> Send(int advertisementId)
        {
           
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value); // Sayfaya giren Member'in ID sini çekiyoruz.
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);
            var user = userResponse.Data;

            ViewBag.GenderId = user.GenderId;
            return View(new AdvertisementAppUserCreateModal
            {
                AdvertisementId = advertisementId,
                AppUserId = userId,
            });
        }
    }
}
