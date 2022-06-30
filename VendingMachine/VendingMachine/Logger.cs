namespace CourseWork
{
    public class Logger
    {
        private readonly ILogType _logType;

        public Logger(ILogType logType)
        {
            _logType = logType;
        }

        public void Log(string message)
        {
            _logType.Log(message);
        }

        public void Log(string message, string location)
        {
            _logType.Log(message, location);
        }
    }
}
