namespace FluentScheduler
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// RunCount Extension Methods
    /// </summary>
    public static class RunCountExtensions
    {

        private static RunCountRestrictableUnit NumberOfTimes(Schedule schedule, int interval)
        {
            return new RunCountRestrictableUnit(schedule, interval);
        }

        /// <summary>
        /// Delays the job for the given interval.
        /// </summary>
        /// <param name="unit">The schedule being affected.</param>
        /// <param name="interval">Interval to wait.</param>
        public static RunCountRestrictableUnit NumberOfTimes(this IUnit unit, int interval)
        {
            if (unit == null)
                throw new ArgumentNullException("unit");

            return NumberOfTimes(unit.Schedule , interval);
        }

    }
}
