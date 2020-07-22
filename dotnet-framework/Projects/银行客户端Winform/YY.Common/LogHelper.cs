using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs
{
    public class LogHelper
    {
            private static readonly log4net.ILog loginfo = log4net.LogManager.GetLogger("InfoRollingFileAppender");
            private static readonly log4net.ILog logdebug = log4net.LogManager.GetLogger("DebugRollingFileAppender");
            private static readonly log4net.ILog logwarn = log4net.LogManager.GetLogger("WarnRollingFileAppender");
            private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("ErrorRollingFileAppender");
            private static readonly log4net.ILog logfatal = log4net.LogManager.GetLogger("FatalRollingFileAppender");
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
            public static void LogFatal(string msg)
            {
                if (logfatal.IsFatalEnabled)
                {
                    logfatal.Fatal(msg);
                }
            }
        }
    public class LogTool
    {
        private string _path;
        private string _logFile;
        private string _dateStr;
        private string _moduleName;

        private DateTime _date;
        private StreamWriter writer;
        private FileStream fileStream = null;
        public LogTool(string path, string moduleName)
        {
            _moduleName = moduleName;
            _path = path;
            _date = DateTime.Now;
            _dateStr = _date.ToString("yyyy-MM-dd");
            _logFile = Path.Combine(path, "ModuleLog/" + _dateStr + "/" + moduleName + ".txt");
            CreateDirectory(_logFile);
            //log("creat...");
        }
        public LogTool(string fileName)
        {
            _moduleName = fileName;
            _path = System.Environment.CurrentDirectory;
            _date = DateTime.Now;
            _dateStr = _date.ToString("yyyy-MM-dd");
            _logFile = Path.Combine(_path, "Receipt/" + _dateStr + "/" + _moduleName + ".txt");
            CreateDirectory(_logFile);
        }
        //使用
        //Log log = new Log(AppDomain.CurrentDomain.BaseDirectory + @"/log/Log.txt");
        private bool IsTheSameDay()
        {
            DateTime nowDate = DateTime.Now;
            string dateStr = nowDate.ToString("yyyy-MM-dd");
            if (DateTime.Compare(nowDate, _date) != 0)
            {
                _date = nowDate;
                _dateStr = dateStr;
                return false;
            }
            return true;
        }
        private void UpdateLogPath()
        {

            _logFile = Path.Combine(_path, "Receipt/" + _dateStr + "/" + _moduleName+ ".txt");
            CreateDirectory(_logFile);

        }
        public void log(string info)
        {
            try
            {
                if (!IsTheSameDay()) UpdateLogPath();

                System.IO.FileInfo fileInfo = new System.IO.FileInfo(_logFile);
                /*
                 if (!fileInfo.Exists)
                 {
                     fileStream = fileInfo.Create();
                     writer = new StreamWriter(fileStream);
                 }
                 */
                if (!File.Exists(_logFile))
                {
                    fileStream = fileInfo.Create();
                    writer = new StreamWriter(fileStream);
                    writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss.ff") + ":Creat...");
                }

                else
                {
                    fileStream = fileInfo.Open(FileMode.Append, FileAccess.Write);
                    writer = new StreamWriter(fileStream);
                }
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss.ff") + ":" + info);
                //writer.WriteLine("----------------------------------");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                    writer.Dispose();
                    fileStream.Close();
                    fileStream.Dispose();
                }
            }
        }

        public void CreateDirectory(string infoPath)
        {

            DirectoryInfo directoryInfo = Directory.GetParent(infoPath);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }
    }

}
