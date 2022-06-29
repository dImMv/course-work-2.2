using System;
using System.IO;

namespace CourseWork
{
    public class FileLog : ILogType
    {
        private readonly string _filePath;

        public FileLog(string filePath)
        {
            _filePath = filePath;
        }

        public void Log(string message)
        {
            var messageLog = $"{message} [{DateTime.Now}]";

            if (File.Exists(_filePath))
            {
                File.AppendAllText(_filePath, messageLog);
            }
            else
            {
                File.WriteAllText(_filePath, messageLog);
            }
        }

        public void Log(string message, string location)
        {
            var messageLog = $"{location}: {message} [{DateTime.Now}]";

            if (File.Exists(_filePath))
            {
                File.AppendAllText(_filePath, messageLog);
            }
            else
            {
                File.WriteAllText(_filePath, messageLog);
            }
        }
    }
}