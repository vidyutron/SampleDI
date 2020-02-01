using System;

namespace DomainLayer.Fork
{
    public class Logger : ILogger
    {
        public void Log(string text)
        {
            Console.WriteLine("Logging - $text");
        }
    }
}
