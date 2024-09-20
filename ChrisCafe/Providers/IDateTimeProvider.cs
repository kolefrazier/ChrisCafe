namespace ChrisCafe.Providers
{
    public interface IDateTimeProvider
    {
        DateTime Today { get; }
        DateTime Now { get; }
        DateTime NowUtc { get; }
    }
}
