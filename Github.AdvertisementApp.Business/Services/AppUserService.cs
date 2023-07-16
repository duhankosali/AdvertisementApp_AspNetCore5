using AutoMapper;
using FluentValidation;
using Github.AdvertisementApp.Business.Extensions;
using Github.AdvertisementApp.Business.Interfaces;
using Github.AdvertisementApp.Common;
using Github.AdvertisementApp.DataAccess.UnitOfWork;
using Github.AdvertisementApp.Dtos;
using Github.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow, IValidator<AppUserLoginDto> loginDtoValidator)
            : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);

                await _uow.GetRepository<AppUser>().CreateAsync(user);
                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId
                });
                await _uow.SaveChangesAsync();

                return new Response<AppUserCreateDto>(ResponseType.Success, dto);
            }
            return new Response<AppUserCreateDto>(dto, validationResult.ConvertToCustomValidationError()); // istediğim gibi gelmediği durumlarda Extension
        }

        public async Task<IResponse<AppUserListDto>> CheckUser(AppUserLoginDto dto) // böyle bir user var mı yok mu kontrol et
        {
            var validationResult = _loginDtoValidator.Validate(dto);
            if(validationResult.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetByFilter(x => x.Username == dto.Username && x.Password == dto.Password);
                if(user != null) // eğer böyle bir kullanıcı var ise:
                {
                    var appUserDto = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Username or password is wrong.");
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, "Username and password cannot be empty.");
        }

        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId) // Kullanıcı ID'sini kullanarak kullanıcıya ait olan Rolleri liste halinde getir.
        {
            var roles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if(roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "The relevant role was not found.");
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);

            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);
        }
    }
}
