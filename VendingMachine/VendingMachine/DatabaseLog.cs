using System;

namespace CourseWork
{
    public class DatabaseLog : ILogType
    {
        private readonly string _databasePath;

        public DatabaseLog(string databasePath)
        {
            _databasePath = databasePath;
        }

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