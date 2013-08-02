using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;

namespace TaskScheduler.Calendars
{
    class RiskCalendar : ICalendar
    {
        public bool IsTimeIncluded(DateTimeOffset timeUtc)
        {
            return false;
        }

        public DateTimeOffset GetNextIncludedTimeUtc(DateTimeOffset timeUtc)
        {
            return timeUtc;
        }

        public string Description { get; set; }

        public ICalendar CalendarBase { get; set; }
        public object Clone()
        {
            return this;
        }
    }
}
