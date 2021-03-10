using MediatR;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.MedicalInfos.Commands.DeleteById
{
    public class DeleteMedicalInfoByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteMedicalInfoByIdCommandHandler : IRequestHandler<DeleteMedicalInfoByIdCommand, Response<int>>
        {
            private readonly IMedicalInfoRepositoryAsync _repository;
            public DeleteMedicalInfoByIdCommandHandler(IMedicalInfoRepositoryAsync repository)
            {
                _repository = repository;
            }
            public async Task<Response<int>> Handle(DeleteMedicalInfoByIdCommand command, CancellationToken cancellationToken)
            {
                var _medial = await _repository.GetByIdAsync(command.Id);
                if (_medial == null) throw new ApiException($"Medical Infomation Not Found.");
                await _repository.DeleteAsync(_medial);
                return new Response<int>(_medial.Id);
            }
        }
    }
}
