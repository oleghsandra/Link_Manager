using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LinkManager.UI.BL.Scheduler
{
    public class SchedulerEngine
    {
        private static readonly SchedulerEngine schedulerEngineInstance;
        private readonly IScheduler scheduler;

        private SchedulerEngine()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            this.scheduler = schedulerFactory.GetScheduler();
            this.scheduler.Start();
        }

        static SchedulerEngine()
        {
            if (schedulerEngineInstance == null)
            {
                schedulerEngineInstance = new SchedulerEngine();
            }
        }

        public static SchedulerEngine Instance
        {
            get
            {
                return schedulerEngineInstance;
            }
        }

        public void StartScheduler()
        {
            this.scheduler.Start();
        }

        public void StopScheduler()
        {
            this.scheduler.Shutdown(true);
        }

        public void ScheduleFinancialJob()
        {
            string jobIdentity = "FinancialJob";
            string trigerIdentity = "FinancialJobTriger";

            IJobDetail jobDetail = JobBuilder.Create<SchedulerFinancialJob>()
                .WithIdentity(jobIdentity)
                .Build();

            //Дістати з конфігів
            string jobExecutionTimeConfig = "15:51";

            DateTime executionTime = DateTime.ParseExact(jobExecutionTimeConfig, "HH:mm", CultureInfo.CurrentCulture);

            ITrigger triger = TriggerBuilder.Create()
                .WithIdentity(trigerIdentity)
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(executionTime.Hour, executionTime.Minute))
                .Build();

            this.scheduler.ScheduleJob(jobDetail, triger);
        }

        public void ScheduleAdminJob()
        {
            string jobIdentity = "AdminJob";
            string trigerIdentity = "AdminJobTriger";

            IJobDetail jobDetail = JobBuilder.Create<AdminJob>()
                .WithIdentity(jobIdentity)
                .Build();

            //Дістати з конфігів
            string jobExecutionTimeConfig = "23:20";

            DateTime executionTime = DateTime.ParseExact(jobExecutionTimeConfig, "HH:mm", CultureInfo.CurrentCulture);

            ITrigger triger = TriggerBuilder.Create()
                .WithIdentity(trigerIdentity)
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(executionTime.Hour, executionTime.Minute))
                .Build();

            this.scheduler.ScheduleJob(jobDetail, triger);
        }
    }
}