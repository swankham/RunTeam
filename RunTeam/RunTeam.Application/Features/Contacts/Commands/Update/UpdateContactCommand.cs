using MediatR;
using RunTeam.Application.Exceptions;
using RunTeam.Application.Interfaces.Repositories;
using RunTeam.Application.Wrappers;
using RunTeam.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RunTeam.Application.Features.Contacts.Commands.Update
{
    public class UpdateContactCommand : IRequest<Response<ContactAddress>>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }

        public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Response<ContactAddress>>
        {
            private readonly IContactAddressRepositoryAsync _repository;
            public UpdateContactCommandHandler(IContactAddressRepositoryAsync repository)
            {
                _repository = repository;
            }

            public async Task<Response<ContactAddress>> Handle(UpdateContactCommand command, CancellationToken cancellationToken)
            {
                var _contact = await _repository.GetByIdAsync(command.Id);

                if (_contact == null)
                {
                    throw new ApiException($"Contact address Not Found.");
                }
                else
                {
                    _contact.UserId = command.UserId;
                    _contact.Address = command.Address;
                    _contact.Province = command.Province;
                    _contact.CountryId = command.CountryId;
                    _contact.Phone = command.Phone;
                    _contact.PostalCode = command.PostalCode;
                    _contact.EmailAddress = command.EmailAddress;

                    await _repository.UpdateAsync(_contact);
                    return new Response<ContactAddress>(_contact);
                }
            }
        }
    }
}
