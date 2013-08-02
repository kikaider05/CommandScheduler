using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskScheduler.Models
{
    public class LogEntry
    {
        public int LogCode;
        public string Caller;
        public string Message;
        public string CompleteMessage
        {
            get
            {
                return DateTime.Now.ToString() + " - " + LogCode.ToString() + " | " + Caller + " | " + Message;
            }
        }

        public LogEntry(int LogCode, string Caller, string Message)
        {
            this.LogCode = LogCode;
            this.Caller = Caller;
            this.Message = Message;
        }
    }
}
