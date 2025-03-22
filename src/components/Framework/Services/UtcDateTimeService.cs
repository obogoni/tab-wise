
namespace Framework.Services;

public class UtcDateTimeService : IDateTimeService
{
    public DateTime Now => DateTime.UtcNow;

    public DateTime Today => Now.Date;
}
