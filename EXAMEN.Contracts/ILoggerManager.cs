using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EXAMEN.Contracts
{
    public interface ILoggerManager
    {
        void LogInfo(string message, [CallerMemberName] string memberName = "");
        void LogWarn(string message, [CallerMemberName] string memberName = "");
        void LogDebug(string message, [CallerMemberName] string memberName = "");
        void LogError(string message, [CallerMemberName] string memberName = "");
    }
}
