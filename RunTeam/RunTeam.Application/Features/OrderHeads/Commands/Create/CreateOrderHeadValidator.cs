using FluentValidation;
using RunTeam.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Features.OrderHeads.Commands.Create
{
    public class CreateOrderHeadValidator : AbstractValidator<CreateOrderHeadCommand>
    {
        private readonly IOrderHeadRepositoryAsync _repository;
        public CreateOrderHeadValidator(IOrderHeadRepositoryAsync repository)
        {
            this._repository = repository;
        }

    }
}
