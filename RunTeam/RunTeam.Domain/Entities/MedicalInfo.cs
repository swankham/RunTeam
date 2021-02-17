using RunTeam.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Domain.Entities
{
    public class MedicalInfo : AuditableBaseEntity
    {
        public string UserId { get; set; }
        public string HealthIssues { get; set; }
        public string BloodGroup { get; set; }
        public string EmergencyContact { get; set; }
        public string Phone { get; set; }
    }
}
