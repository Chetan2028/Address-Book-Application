using System;
using System.Collections.Generic;
using System.Text;
using NLog;

namespace AddressBookApplication
{
    class Nlog
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Logs the debug.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// Logs the information.
        /// </summary>
        /// <param name="message">The message.</param>
        public void logInfo(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">The message.</param>
        public void LogError(string message)
        {
            logger.Error(message);
        }
    }
}
