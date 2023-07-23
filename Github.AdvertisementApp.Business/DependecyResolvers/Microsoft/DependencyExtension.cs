using AutoMapper;
using FluentValidation;
using Github.AdvertisementApp.Business.Interfaces;
using Github.AdvertisementApp.Business.Mappings.AutoMapper;
using Github.AdvertisementApp.Business.Services;
using Github.AdvertisementApp.Business.ValidationRules.FluentValidation;
using Github.AdvertisementApp.DataAccess.Contexts;
using Github.AdvertisementApp.DataAccess.UnitOfWork;
using Github.AdvertisementApp.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Business.DependecyResolvers.Microsoft
{
   // "Extension" metodları: "Extension" metotları, mevcut bir sınıfın işlevselliğini genişletmek için kullanılır.
   // "Extension" metotlarını tanımlamak için, "static" bir sınıf kullanılır.Örneğin, "string" veri türü için bir "Extension" metodu kullanarak, belirli bir işlemi gerçekleştirmek için mevcut bir dize verisini kullanabilirsiniz.
    public  static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local")); // appsettings.json'da bulunan "Local" isimli json data'nın ConnectionString değerini çekiyorum.
            });

            services.AddScoped<IUow, Uow>(); // IUow gördüğünde bana bir Uow ver.

            // Fluent Validation operations
            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();

            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();

            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();

            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateValidator>();

            services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();


            // Services operations
            services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();
        }
    }
}
