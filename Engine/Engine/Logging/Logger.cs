using System;

using log4net;

namespace CoreEngine.Engine.Logging
{
    #region Enums
    /// <summary>
    /// Enum for defining the log level
    /// </summary>
    public enum LogLevel
    {
        FATAL = 0,
        ERROR,
        WARNING,
        INFO,
        DEBUG
    };
    #endregion

    /// <summary>
    ///  Main logging class
    /// </summary>
    public static class Logger
    {
        #region Data
        private static ILog _log;
        #endregion

        #region Events
        /// <summary>
        /// Called when the application is loaded
        /// </summary>
        /// <param name="e">Event arguments</param>
        internal static void OnLoad(EventArgs e)
        {
            _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        #endregion

        #region Public API
        /// <summary>
        /// Static log function used to log data
        /// </summary>
        /// <param name="level">Log importance</param>
        /// <param name="text">String to log</param>
        public static void Log(LogLevel level, string text)
        {
            switch (level)
            {
                case LogLevel.DEBUG:
                {
                    _log.Debug(text);
                    break;
                }

                case LogLevel.INFO:
                {
                    _log.Info(text);
                    break;
                }

                case LogLevel.WARNING:
                {
                    _log.Warn(text);
                    break;
                }

                case LogLevel.ERROR:
                {
                    _log.Error(text);
                    break;
                }

                case LogLevel.FATAL:
                {
                    _log.Fatal(text);
                    break;
                }
            }
        }
        #endregion
    }
}
