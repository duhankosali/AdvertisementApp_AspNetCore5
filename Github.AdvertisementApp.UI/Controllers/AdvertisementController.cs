using Github.AdvertisementApp.Business.Interfaces;
using Github.AdvertisementApp.Common.Enums;
using Github.AdvertisementApp.Dtos;
using Github.AdvertisementApp.Dtos.Interfaces;
using Github.AdvertisementApp.UI.Extensions;
using Github.AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IAdvertisementAppUserService _advertisementAppUserService;
        public AdvertisementController(IAppUserService appUserService, IAdvertisementAppUserService advertisementAppUserService)
        {
            _appUserService = appUserService;
            _advertisementAppUserService = advertisementAppUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Member")] // Başvuru yapmak için 'Member' rolüne sahip olunmalı.
        public async Task<IActionResult> Send(int advertisementId)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value); // Sayfaya giren Member'in ID sini çekiyoruz.

            ViewBag.GenderId = await GetGenderId();

            var list = GetMilitaryStatusList();
            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

            return View(new AdvertisementAppUserCreateModal
            {
                AdvertisementId = advertisementId,
                AppUserId = userId,
            });
        }

        [Authorize(Roles = "Member")] // Başvuru yapmak için 'Member' rolüne sahip olunmalı.
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateModal model)
        {
            AdvertisementAppUserCreateDto dto = new();

            if (model.CvFile!=null)
            {
                var fileName = Guid.NewGuid().ToString();
                string extName = Path.GetExtension(model.CvFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","cvFiles", fileName + extName);
                var stream = new FileStream(path, FileMode.Create);
                await model.CvFile.CopyToAsync(stream);

                dto.CvPath = path;
            }

            // mapping
            dto.AdvertisementId = model.AdvertisementId;
            dto.AdvertisementAppUserStatusId = model.AdvertisementAppUserStatusId;
            dto.AppUserId = model.AppUserId;
            dto.EndDate = model.EndDate;
            dto.MilitaryStatusId = model.MilitaryStatusId;
            dto.WorkExperience = model.WorkExperience;

            var response = await _advertisementAppUserService.CreateAsync(dto);
            if(response.ResponseType == Common.ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                ViewBag.GenderId = await GetGenderId();

                List<MilitaryStatusListDto> list = GetMilitaryStatusList();
                ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

                return View();
            }
            else
            {
                return RedirectToAction("HumanResource", "Home");   
            }
        }

        public async Task<int> GetGenderId()
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value); // Sayfaya giren Member'in ID sini çekiyoruz.
            var userResponse = await _appUserService.GetByIdAsync<AppUserListDto>(userId);
            var user = userResponse.Data;
            return user.GenderId;
        }

        public List<MilitaryStatusListDto> GetMilitaryStatusList()
        {
            var list = new List<MilitaryStatusListDto>();
            var items = Enum.GetValues(typeof(MilitaryStatusType));
            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                });
            }
            return list;
        }

        // List Page
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var list = await _advertisementAppUserService.GetList(AdvertisementAppUserStatusType.Applied);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetStatus(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            await _advertisementAppUserService.SetStatusAsync(advertisementAppUserId, type);
            return View();
        }
    }
}
