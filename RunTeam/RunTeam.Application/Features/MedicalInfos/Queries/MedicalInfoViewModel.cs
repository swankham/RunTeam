using RunTeam.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Features.MedicalInfos.Queries
{
    public class MedicalInfoViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string HealthIssues { get; set; }
        public string BloodGroup { get; set; }
        public string EmergencyContact { get; set; }
        public string Phone { get; set; }
    }
}
