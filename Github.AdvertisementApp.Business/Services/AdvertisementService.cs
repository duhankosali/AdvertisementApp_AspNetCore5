﻿using AutoMapper;
using FluentValidation;
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
    public class AdvertisementService : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AdvertisementService(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUow uow) 
            : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync()  
        {
            var data = await _uow.GetRepository<Advertisement>().GetAllAsync(x=>x.Status, x=>x.CreatedDate, Common.Enums.OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Success, dto);
        }
    }
}
