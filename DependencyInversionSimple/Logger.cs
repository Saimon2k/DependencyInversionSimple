using System.Diagnostics;

namespace DependencyInversionSimple
{
    public interface ILogService
    {
        void Write(string message);
    }

    // простой вывод на консоль
    public class SimpleLogService : ILogService
    {
        public void Write(string message) => Console.WriteLine(message);
    }

    // сервис, который выводит сообщение зеленым цветом
    public class GreenLogService : ILogService
    {
        public void Write(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    public class DebugLogService : ILogService
    {
        public void Write(string message) => Debug.WriteLine(message);
    }

    public class Logger
    {
        private readonly ILogService logService;

        public Logger(ILogService logService) => this.logService = logService;
        public void Log(string message) => logService.Write($"{DateTime.Now} {message}");
    }
}
