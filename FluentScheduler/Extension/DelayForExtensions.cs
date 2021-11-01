﻿namespace FluentScheduler
{
    using System;

    /// <summary>
    /// DelayFor extension methods.
    /// </summary>
    public static class DelayForExtensions
    {
        private static DelayTimeUnit DelayFor(Schedule schedule, int interval)
        {
            return new DelayTimeUnit(schedule, interval);
        }

        /// <summary>
        /// Delays the job for the given interval.
        /// </summary>
        /// <param name="unit">The schedule being affected.</param>
        /// <param name="interval">Interval to wait.</param>
        public static DelayTimeUnit DelayFor(this SpecificTimeUnit unit, int interval)
        {
            if (unit == null)
                throw new ArgumentNullException("unit");

            return DelayFor(unit.Schedule, interval);
        }

    }
}
