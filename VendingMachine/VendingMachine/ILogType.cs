﻿namespace VendingMachine
{
    public interface ILogType
    {
        void LogError(string errorMessage);
        void LogWarning(string warningMessage);
        void LogInfo(string infoMessage);
    
    }
}
