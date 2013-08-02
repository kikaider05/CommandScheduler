using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using Quartz;
using Quartz.Impl;

namespace TaskScheduler
{
    public partial class TaskManager : ServiceBase
    {
        public Quartz.IScheduler scheduler;
        public string logFile = System.Configuration.ConfigurationManager.AppSettings["ServiceLogLoc"];
        public string Connection = System.Configuration.ConfigurationManager.AppSettings["DisasterConStr"];

        public TaskManager()
        {
            InitializeComponent();
        }

        static void Main(string[] args)
        {
            ServiceBase.Run(new TaskManager());
        }

        protected override void OnStart(string[] args)
        {
            Tools.Logger.LogToFile(new Models.LogEntry(0, "OnStart", "Service Started Successfully"));
            // First, initialize Quartz.NET as usual. In this sample app I'll configure Quartz.NET by code.
            var schedulerFactory = new StdSchedulerFactory();
            scheduler = schedulerFactory.GetScheduler();
            scheduler.Start();

            scheduler.ListenerManager.AddJobListener(new Listeners.GlobalJobListener());
            scheduler.ListenerManager.AddTriggerListener(new Listeners.GlobalTriggerListener());
            
            // A sample trigger and job
            var SoapTrigger = TriggerBuilder.Create()
               .WithIdentity("CheckTrigger").WithSchedule(Quartz.SimpleScheduleBuilder.RepeatMinutelyForever(2))
               .StartNow()
               .Build();
            var SoapJob = new JobDetailImpl("SoapJob", "Soap", typeof(Jobs.SoapJob));
            scheduler.ScheduleJob(SoapJob, SoapTrigger);

            scheduler.AddCalendar("myCalendar", new Calendars.RiskCalendar { Description = "Risk Calendar" }, false, false);
        }

        protected override void OnStop()
        {
            scheduler.Clear();
            Tools.Logger.LogToFile(new Models.LogEntry(0, "OnStop", "Service Stopped Successfully"));
        }

    }
}
