using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;

namespace TaskScheduler.Listeners
{
    class GlobalTriggerListener : ITriggerListener
    {
        public void TriggerFired(ITrigger trigger, IJobExecutionContext context) { }

        public bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
        {
            return false;
        }

        public void TriggerMisfired(ITrigger trigger) {
        }

        public void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode) { }

        public string Name
        {
            get { return GetType().FullName; }
        }
    }
}
