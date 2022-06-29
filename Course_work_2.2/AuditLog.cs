using System;

namespace CourseWork
{
    public class AuditLog : ILogType
    {
        public void Log(string message)
        {
            Console.WriteLine($"{message} [{DateTime.Now}]");
        }

        public void Log(string message, string location)
        {
            Console.WriteLine($"{location}: {message} [{DateTime.Now}]");
        }
    }
}