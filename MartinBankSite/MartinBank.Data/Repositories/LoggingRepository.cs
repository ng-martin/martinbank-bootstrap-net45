using System;
using MartinBank.Data.Interfaces;

namespace MartinBank.Data.Repositories
{
    /// <summary>
    /// Logging information to a file
    /// Assumption: A file will be read and updated accordingly locally.
    /// </summary>
    public class FileLoggingRepository : ILoggingRepository
    {
        public void Error(Exception ex)
        {
            // save exception details on file
        }

        public void Info(string message)
        {
            // save info details on file
        }

        public void Debug(string message)
        {
            // save debug details on file
        }
    }
}
