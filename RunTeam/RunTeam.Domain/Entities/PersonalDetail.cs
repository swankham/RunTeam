using RunTeam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Domain.Entities
{
    public class PersonalDetail : AuditableBaseEntity
    {
        public string UserId { get; set; }
        public string ThaiCitizenId { get; set; }
        public string PassportId { get; set; }
        public int NotionalityId { get; set; }
        public string Prefix { get; set; }
        public string FirstnameTh { get; set; }
        public string MiddlenameTh { get; set; }
        public string LastnameTh { get; set; }
        public string FirstnameEn { get; set; }
        public string MiddlenameEn { get; set; }
        public string LastnameEn { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
    }
}
