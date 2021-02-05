using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.December2020.Application.Features.Applicants.Commands.CreateApplicant
{
    public class CreateApplicantCommandValidator : AbstractValidator<CreateApplicantCommand>
    {
        private readonly IApplicantRepository _applicantRepository;
        public CreateApplicantCommandValidator(IApplicantRepository applicantRepository)
        {
            _applicantRepository = applicantRepository;

            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()                
                //.MustAsync(ApplicantNameUnique)
                .MinimumLength(5).WithMessage("{PropertyName} must have at least 5 characters.");

            RuleFor(a => a.FamilyName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(5).WithMessage("{PropertyName} must have at least 5 characters.");

            RuleFor(a => a.Adress)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MinimumLength(10).WithMessage("{PropertyName} must have at least 10 characters.");

            RuleFor(a => a.Age)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(20).WithMessage("{PropertyName} must be greater than 20.")
                .LessThan(60).WithMessage("{PropertyName} must be less than 60");

            RuleFor(a => a.EMailAdress)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .EmailAddress().WithMessage("{PropertyName} must be a valid email address.");

            RuleFor(a => a.Hired)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(a => a.CountryOfOrigin)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(CheckValidCountry);
        }
        
        private Task<bool> CheckValidCountry(string country, CancellationToken token)
        {
            //to do
            //check https://restcountries.eu/rest/v2/… – ApiDescription: https://restcountries.eu/#api-endpoints-full-name if the country is found, the country is valid. 
            return Task.FromResult(true);
        }
    }
}
