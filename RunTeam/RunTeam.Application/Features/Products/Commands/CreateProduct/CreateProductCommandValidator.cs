using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepositoryAsync productRepository;

        public CreateProductCommandValidator(IProductRepositoryAsync productRepository)
        {
            this.productRepository = productRepository;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueName).WithMessage("{PropertyName} already exists.");
        }

        private async Task<bool> IsUniqueName(string barcode, CancellationToken cancellationToken)
        {
            return await productRepository.IsUniqueNameAsync(barcode);
        }
    }
}
