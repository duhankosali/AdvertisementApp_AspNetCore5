using FluentValidation;
using Github.AdvertisementApp.Common.Enums;
using Github.AdvertisementApp.Dtos;

namespace Github.AdvertisementApp.Business.ValidationRules.FluentValidation
{
    public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator() 
        {
            this.RuleFor(x=>x.AdvertisementAppUserStatusId).NotEmpty();
            this.RuleFor(x => x.AdvertisementId).NotEmpty();
            this.RuleFor(x => x.AppUserId).NotEmpty();
            this.RuleFor(x => x.CvPath).NotEmpty().WithMessage("Please upload your CV file.");
            this.RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId == (int)MilitaryStatusType.Postponed).WithMessage("Please enter the postponement date.");
        }
    }
}
