using LightConsole.Abstracts;
using LightConsole.Services;

namespace LightConsole.Features
{
    public interface IViewDateTime : IService
    {
        Task Print();
        Task PrintAsync();
    }

    public class ViewDateTime(IDateTimeService _dateTimeService) : IViewDateTime
    {
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
