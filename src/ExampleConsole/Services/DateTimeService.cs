using System;

namespace ExampleConsole.Services
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
        DateTime Now { get; }
        DateTime NowAddSeconds(int seconds);
    }

    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
        public DateTime Now => DateTime.Now;
        public DateTime NowAddSeconds(int seconds) => DateTime.Now.AddSeconds(seconds);
    }
}