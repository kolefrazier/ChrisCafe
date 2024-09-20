namespace ChrisCafe.Providers
{
    /// <summary>
    /// Abstracts DateTime methods.
    /// Implemented mainly for testing purposes - mocking a simpler 
    ///     abstraction in tests is a lot easier than mocking a framework library.
    /// </summary>
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Today { 
            get
            {
                return DateTime.Today;
            }
        }

        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        public DateTime NowUtc
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
