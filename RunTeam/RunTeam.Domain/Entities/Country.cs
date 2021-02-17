using RunTeam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Domain.Entities
{
    public class Country : AuditableBaseEntity
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}
