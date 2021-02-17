using RunTeam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Domain.Entities
{
    public class ContactAddress : AuditableBaseEntity
    {
        public string UserId { get; set; }
        public string Address { get; set; }
        public string Privince { get; set; }
        public int Country { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
    }
}
