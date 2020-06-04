using System;
using Domain.Abstractions;

namespace Infrastructure.Helpers
{
    public class DateTimeManager : IDateTimeManager
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}