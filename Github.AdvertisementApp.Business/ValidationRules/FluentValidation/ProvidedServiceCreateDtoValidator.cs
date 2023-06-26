using FluentValidation;
using Github.AdvertisementApp.Dtos.ProviderServiceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class ProvidedServiceCreateDtoValidator : AbstractValidator<ProvidedServiceCreateDto> // Fluent Validation kullanıyoruz.
    {
        public ProvidedServiceCreateDtoValidator()
        {
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.ImagePath).NotEmpty();
            RuleFor(x=>x.Title).NotEmpty();
        }
    }
}
