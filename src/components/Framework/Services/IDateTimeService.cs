namespace Framework.Services;

public interface IDateTimeService
{
    DateTime Now { get; }

    DateTime Today { get; }
}
