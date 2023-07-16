using AutoMapper;
using FluentValidation;
using Github.AdvertisementApp.Business.Interfaces;
using Github.AdvertisementApp.Common.Enums;
using Github.AdvertisementApp.Dtos;
using Github.AdvertisementApp.UI.Extensions;
using Github.AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator; 
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator, IAppUserService appUserService, IMapper mapper)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
            _appUserService = appUserService;
            _mapper = mapper;
        }
        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();
            var model = new UserCreateModel()
            {
                Genders = new SelectList(response.Data, "Id", "Definition")
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
           var result = _userCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserService.CreateWithRoleAsync(dto,(int)RoleType.Member);  
                return this.ResponseRedirectAction(createResponse, "SignIn");   
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition", model.GenderId);
            return View(model);
        }

        public IActionResult SignIn()
        {
            var model = new AppUserLoginDto();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result = await _appUserService.CheckUser(dto); // kullanıcı var mı yok mu kontrolü
            if(result.ResponseType == Common.ResponseType.Success)
            {
                var roleResult = await _appUserService.GetRolesByUserIdAsync(result.Data.Id);

                // İlgili kullanıcının rollerini çekmemiz lazım:
                var claims = new List<Claim>();

                if(roleResult.ResponseType == Common.ResponseType.Success)
                {
                    foreach (var role in roleResult.Data)
                    {
                       claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }
                }
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString())); // ilgili user'ımın ID'sini herhangi bir rolü olmadığı durumda da almak istiyorum.

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // IsPersistent = true;
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", result.Message);
            return View(dto);
        }
    }
}
