using FluentValidation;
using Github.AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Github.AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class GenderUpdateValidator : AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x=>x.Definition).NotEmpty();
        }
    }
}
