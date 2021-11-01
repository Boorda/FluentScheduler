using System;
using System.Collections.Generic;

namespace FluentScheduler
{

    /// <summary>
    /// Unit used to represent the maximum number of times to run a schedule.
    /// </summary>
    public sealed class RunCountRestrictableUnit : IUnit
    {

        /// <summary>
        /// Number of times the schedule has already run.
        /// </summary>
        public int RunCount { get; private set; }

        /// <summary>
        /// Number of times to allow the schedule to run.
        /// </summary>
        public int MaxRunCount { get; set; }

        /// <summary>
        /// Name of Job running the schedule.
        /// </summary>
        public string JobName { get; private set; }

        internal Schedule Schedule { get; private set; }

        Schedule IUnit.Schedule { get { return Schedule; } }

        internal RunCountRestrictableUnit(Schedule schedule, int maxCount)
        {
            Schedule = schedule;
            MaxRunCount = maxCount;
            JobName = Schedule.Name;
            JobManager.JobStart += JobManager_JobStart;
        }

        private void JobManager_JobStart(JobStartInfo obj)
        {     
            if(obj.Name == JobName) { Increment(); }
        }

        /// <summary>
        /// Increments the run Occurrences count.
        /// </summary>
        public void Increment()
        {
            RunCount++;
            if (RunCount >= MaxRunCount) { Schedule.CancelJob(JobName); }
        }

        /// <summary>
        /// Terminates the current job.
        /// </summary>
        /// <returns><seealso cref="JobEndInfo"/> object.</returns>
        //public JobEndInfo Cancel()
        //{
        //    JobEndInfo jobEndInfo = new JobEndInfo()
        //    {
        //        Name = JobName,
        //        CancelType = CancelType.ByRunCount,
        //        RunCount = Occurrences
        //    };

        //    JobManager.RemoveJob(Schedule.Name);
        //    return jobEndInfo;
        //}

    }
}
