using FluentValidation;
using RunTeam.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Countries.Commands.Create
{
    public class CreateCountryValidator : AbstractValidator<CreateCountryCommand>
    {
        private readonly ICountryRepositoryAsync _repository;
        public CreateCountryValidator(ICountryRepositoryAsync repository)
        {
            this._repository = repository;

            RuleFor(p => p.CountryCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(3).WithMessage("{PropertyName} must not exceed 3 characters.")
                .MustAsync(IsUniqueCountrycode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.CountryName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueCountryname).WithMessage("{PropertyName} already exists.");
        }

        private async Task<bool> IsUniqueCountrycode(string countryCode, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueCountryCodeAsync(countryCode);
        }

        private async Task<bool> IsUniqueCountryname(string countryName, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueCountryNameAsync(countryName);
        }
    }
}
