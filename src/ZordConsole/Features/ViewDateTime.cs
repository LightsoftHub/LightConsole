using ZordConsole.Abstracts;
using ZordConsole.Services;

namespace ZordConsole.Features
{
    public interface IViewDateTime : IService
    {
        Task Print();
        Task PrintAsync();
    }

    public class ViewDateTime : IViewDateTime
    {
        private readonly IDateTimeService _dateTimeService;

        public ViewDateTime(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        public Task Print()
        {
            Console.WriteLine($"---------------");
            Console.WriteLine($"---------------");

            var now = _dateTimeService.Now;
            Console.WriteLine($"Local time: {now}");

            var utcNow = _dateTimeService.NowUtc;
            Console.WriteLine($"UTC time: {utcNow}");

            return Task.CompletedTask;
        }

        public async Task PrintAsync()
        {
            Console.WriteLine($"---------------");
            Console.WriteLine($"---------------");

            var now = _dateTimeService.Now;
            Console.WriteLine($"Local time: {now}");

            var utcNow = _dateTimeService.NowUtc;
            Console.WriteLine($"UTC time: {utcNow}");

            await Task.Delay(1);
        }
    }
}
