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
        public string Address { get; set; }
        public string Province { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string EmailAddress { get; set; }
        public string HealthIssues { get; set; }
        public string BloodGroup { get; set; }
        public string EmergencyContact { get; set; }
        public string EmergencyPhone { get; set; }
        public string ImageName { get; set; }
    }
}
