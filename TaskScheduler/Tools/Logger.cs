using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace TaskScheduler.Tools
{
    public static class Logger
    {
        public static string LogLocation = ConfigurationManager.AppSettings["LogLocation"];
        public static void LogToFile(Models.LogEntry logEntry)
        {
            // Store the script names and test results in a output text file.
            using (StreamWriter writer = new StreamWriter(new FileStream(LogLocation, FileMode.Append)))
            {
                writer.WriteLine(logEntry.CompleteMessage);
            }
        }
    }
}
