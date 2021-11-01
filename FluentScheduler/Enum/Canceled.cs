namespace FluentScheduler
{
    /// <summary>
    /// Represents a canceled state.
    /// </summary>
    public enum CancelType
    {
        /// <summary>
        /// Not Canceled
        /// </summary>
        NotCanceled,
        /// <summary>
        /// Canceled by user interaction.
        /// </summary>
        ByUser,
        /// <summary>
        /// Canceled after reaching a specified run count.
        /// </summary>
        ByRunCount,
        /// <summary>
        /// Canceled due to exception.
        /// </summary>
        ByException
    }

    /// <summary>
    /// Represents a canceled state.
    /// </summary>
    public static class Canceled
    {
        /// <param name="cancelType">The CancelType enum value to parse.</param>
        /// <returns>String representation of the specified CancelType enum.</returns>
        public static string Parse(CancelType cancelType)
        {
            switch (cancelType)
            {
                case CancelType.ByUser:
                    return "by user";

                case CancelType.ByRunCount:
                    return "after reaching specified run count";

                case CancelType.ByException:
                    return "due to exception";

                default:
                    return "NO";
            }
        }
    }
}
