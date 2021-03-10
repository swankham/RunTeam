using FluentValidation;
using RunTeam.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Features.PersonalDetails.Commands.Create
{
    public class CreatePersornalDetailValidator : AbstractValidator<CreatePersornalDetailCommand>
    {
        private readonly IPersonalDetailRepositoryAsync _repository;
        public CreatePersornalDetailValidator(IPersonalDetailRepositoryAsync repository)
        {
            this._repository = repository;
        }
    }
}
