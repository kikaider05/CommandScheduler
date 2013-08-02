using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using System.Configuration;

namespace TaskScheduler.Jobs
{
    public class SoapJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Tools.Logger.LogToFile(new Models.LogEntry(0, "Soap Job", "Soap Job Started"));
            Tools.CMDRunner.RunCommand(ConfigurationManager.AppSettings["TestCommand"]);
            Tools.Logger.LogToFile(new Models.LogEntry(0, "Soap Job", "Soap Job Finished"));
        }
    }
}
