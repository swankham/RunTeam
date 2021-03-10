using FluentValidation;
using RunTeam.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Events.Commands.Create
{
    public class CreateEventValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepositoryAsync _repository;
        public CreateEventValidator(IEventRepositoryAsync repository)
        {
            this._repository = repository;

            RuleFor(p => p.EventCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(10).WithMessage("{PropertyName} must not exceed 3 characters.")
                .MustAsync(IsUniqueEventCode).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.EventName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 500 characters.")
                .MustAsync(IsUniqueEventName).WithMessage("{PropertyName} already exists.");
        }

        private async Task<bool> IsUniqueEventCode(string countryCode, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueEventCodeAsync(countryCode);
        }

        private async Task<bool> IsUniqueEventName(string countryName, CancellationToken cancellationToken)
        {
            return await _repository.IsUniqueEventNameAsync(countryName);
        }

    }
}
