using ExampleConsole.Abstracts;
using ExampleConsole.Services;
using System;
using System.Threading.Tasks;

namespace ExampleConsole.Features
{
    public interface IViewDateTime : IService
    {
        Task Print();
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
    }
}
