using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LinkManager.UI.Models
{
    public class SeriLogger
    {
        private static Serilog.Core.Logger seriLog;

        static SeriLogger()
        {
            seriLog = new LoggerConfiguration()
              .ReadFrom.AppSettings()
              .CreateLogger();
        }

        #region INFO

        public static void Info(string msg)
        {
            seriLog.Information(msg);
        }

        public static void Info(string msg, params object[] args)
        {
            seriLog.Information(msg, args);
        }

        public static void Info(string msg, Exception ex)
        {
            seriLog.Information(msg, ex);
        }

        #endregion

        #region WARNING

        public static void Warning(string msg)
        {
            seriLog.Warning(msg);
        }

        public static void Warning(string msg, Exception ex)
        {
            seriLog.Warning(msg, ex);
        }


        public static void WarningFormat(string format, params object[] args)
        {
            Warning(string.Format(format, args));
        }

        #endregion

        #region ERROR

        public static void Error(string msg)
        {
            seriLog.Error(msg);
        }

        public static void Error(string msg, Exception ex)
        {
            seriLog.Error(msg, ex);
        }


        public static void Error(string format, params object[] args)
        {
            Error(string.Format(format, args));
        }

        #endregion

        /// ToDo: Add DEBUG

    }
}