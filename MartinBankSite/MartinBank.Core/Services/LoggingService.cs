using System;
using MartinBank.Core.Interfaces;
using MartinBank.Data.Interfaces;

namespace MartinBank.Core.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly ILoggingRepository _loggingRepository;

        public LoggingService(ILoggingRepository loggingRepository)
        {
            _loggingRepository = loggingRepository;
        }

        public void Debug(string message)
        {
            // Do some other logic and then save into repository
            _loggingRepository.Debug(message);
        }

        public void Info(string message)
        {
            // Do some other logic and then save into repository
            _loggingRepository.Info(message);
        }

        public void Error(string message, Exception ex)
        {
            // Do some other logic and then save into repository
            _loggingRepository.Error(ex);
        }
    }
}
