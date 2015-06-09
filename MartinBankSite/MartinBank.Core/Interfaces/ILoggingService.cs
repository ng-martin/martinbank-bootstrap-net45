using System;

namespace MartinBank.Core.Interfaces
{
    public interface ILoggingService
    {
        void Debug(string message);
        void Info(string message);
        void Error(string message, Exception ex);
        
    }
}
