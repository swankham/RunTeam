using FluentValidation;
using RunTeam.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Features.OrderLines.Commands.Create
{
    public class CreateOrderLineValidator : AbstractValidator<CreateOrderLineCommand>
    {
        private readonly IOrderLineRepositoryAsync _repository;
        public CreateOrderLineValidator(IOrderLineRepositoryAsync repository)
        {
            this._repository = repository;
        }
    }
}
