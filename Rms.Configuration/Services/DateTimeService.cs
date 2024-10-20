using Rms.Models.Common.Identity;
using System;


namespace Rms.Configuration.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
