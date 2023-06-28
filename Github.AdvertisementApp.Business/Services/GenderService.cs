using AutoMapper;
using FluentValidation;
using Github.AdvertisementApp.Business.Interfaces;
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
    public class GenderService : Service<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {
        public GenderService(IMapper mapper, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator, IUow uow) 
            : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {

        }
    }
}
