using FluentValidation;
using RunTeam.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Features.Contacts.Commands.Create
{
    public class CreateContactValidator : AbstractValidator<CreateContactCommand>
    {
        private readonly IContactAddressRepositoryAsync _repository;
        public CreateContactValidator(IContactAddressRepositoryAsync repository)
        {
            this._repository = repository;
        }
    }
}
