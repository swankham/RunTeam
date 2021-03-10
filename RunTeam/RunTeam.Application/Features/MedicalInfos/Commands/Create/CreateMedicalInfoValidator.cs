using FluentValidation;
using RunTeam.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Features.MedicalInfos.Commands.Create
{
    public class CreateMedicalInfoValidator : AbstractValidator<CreateMedicalInfoCommand>
    {
        private readonly IMedicalInfoRepositoryAsync _repository;
        public CreateMedicalInfoValidator(IMedicalInfoRepositoryAsync repository)
        {
            this._repository = repository;
        }
    }
}
