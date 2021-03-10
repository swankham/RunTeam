using RunTeam.Application.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Features.Countries.Queries
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
}
