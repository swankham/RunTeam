using System;
using System.Collections.Generic;
using System.Text;

namespace RunTeam.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
