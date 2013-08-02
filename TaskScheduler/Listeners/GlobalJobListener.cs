using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;

namespace TaskScheduler.Listeners
{
    class GlobalJobListener : IJobListener
    {
        public void JobToBeExecuted(IJobExecutionContext context)
        {
        }

        public void JobExecutionVetoed(IJobExecutionContext context)
        {
        }

        public void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
        }

        public string Name
        {
            get
            {
                return GetType().FullName;
            }
        }
    }
}
