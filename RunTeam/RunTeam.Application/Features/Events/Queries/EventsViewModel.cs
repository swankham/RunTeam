﻿using RunTeam.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Features.Events.Queries
{
    public class EventsViewModel
    {
        public string EventCode { get; set; }
        public string EventName { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }
        public bool EnableFlag { get; set; }
        public bool OnlineFlag { get; set; }
        public string EventDescription { get; set; }
        public int RegistrationStatus { get; set; }
        public string EventOwner { get; set; }
    }
}
