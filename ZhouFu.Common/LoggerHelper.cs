using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace ZhongLi.Common
{
    /// <summary>
    /// 日志记录公共类
    /// </summary>
    public class LoggerHelper
    {
        static log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
        static log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");

        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        public static void SetConfig(FileInfo configFile)
        {
            log4net.Config.XmlConfigurator.Configure(configFile);
        }
        /// <summary>
        /// 记录异常信息
        /// </summary>
        /// <param name="errorMsg">异常信息</param>
        public static void LogError(string errorMsg)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(new Exception(errorMsg));
            }
        }

        /// <summary>
        /// 记录一般信息
        /// </summary>
        /// <param name="msg">记录内容</param>
        public static void LogInfo(string msg)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(msg);
            }
        }
    }
}
