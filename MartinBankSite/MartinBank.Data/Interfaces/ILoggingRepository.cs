using System;

namespace MartinBank.Data.Interfaces
{
    public interface ILoggingRepository
    {
        void Error(Exception ex);
        void Info(string message);
        void Debug(string message);
    }
}
