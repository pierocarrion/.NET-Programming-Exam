using EXAMEN.Contracts;
using NLog;
using System.Runtime.CompilerServices;

namespace EXAMEN.LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        
        public LoggerManager()
        {

        }
        
        public void LogDebug(string message,[CallerMemberName] string memberName = "")
        {
            _logger.Debug($"Function Name: {memberName} | {message}");
        }

        public void LogError(string message, [CallerMemberName] string memberName = "")
        {
            _logger.Error($"Function Name: {memberName} : {message}");
        }

        public void LogInfo(string message, [CallerMemberName] string memberName = "")
        {
            _logger.Info($"Function Name: {memberName} : {message}");
        }

        public void LogWarn(string message, [CallerMemberName] string memberName = "")
        {
            _logger.Warn($"Function Name: {memberName} : {message}");
        }
    }
}
