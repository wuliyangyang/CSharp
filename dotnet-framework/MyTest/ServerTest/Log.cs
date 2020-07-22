using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTest
{
    class Log
    {
        private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("RollingLogFileAppender");
        private static readonly log4net.ILog logdebug = log4net.LogManager.GetLogger("DebugRollingFileAppender");
        private static readonly log4net.ILog logwarn = log4net.LogManager.GetLogger("WarnRollingFileAppender");
        private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("ErrorRollingFileAppender");

        public static void LogInfo(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        public static void LogError(string error)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(error);
            }

        }

        public static void LogWarn(string warn)
        {
            if (logwarn.IsWarnEnabled)
            {
                logwarn.Warn(warn);
            }
        }

        public static void LogDebug(string msg)
        {
            if (logdebug.IsDebugEnabled)
            {
                logdebug.Debug(msg);
            }
        }
    }
}
