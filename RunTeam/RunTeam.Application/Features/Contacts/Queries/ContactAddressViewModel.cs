using RunTeam.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Features.Contacts.Queries
{
    public class ContactAddressViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
    }
}
