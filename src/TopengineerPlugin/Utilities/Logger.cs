using System;
using System.IO;
using System.Text;

namespace TopengineerPlugin.Utilities
{
    /// <summary>
    /// Logging utility for plugin operations
    /// </summary>
    public class Logger
    {
        private readonly string _logDirectory;
        private readonly string _moduleName;
        private readonly string _logFilePath;

        public Logger(string moduleName = "TopengineerPlugin")
        {
            _moduleName = moduleName;
            _logDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Topengineer", "Logs");
            
            CreateLogDirectory();
            _logFilePath = Path.Combine(_logDirectory, $"TopengineerPlugin_{DateTime.Now:yyyy-MM-dd}.log");
        }

        private void CreateLogDirectory()
        {
            try
            {
                if (!Directory.Exists(_logDirectory))
                {
                    Directory.CreateDirectory(_logDirectory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create log directory: {ex.Message}");
            }
        }

        /// <summary>
        /// Log info message
        /// </summary>
        public void Log(string message)
        {
            WriteLog("INFO", message);
        }

        /// <summary>
        /// Log warning message
        /// </summary>
        public void Warning(string message)
        {
            WriteLog("WARNING", message);
        }

        /// <summary>
        /// Log error message
        /// </summary>
        public void Error(string message)
        {
            WriteLog("ERROR", message);
        }

        /// <summary>
        /// Log debug message
        /// </summary>
        public void Debug(string message)
        {
            WriteLog("DEBUG", message);
        }

        private void WriteLog(string level, string message)
        {
            try
            {
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{_moduleName}] [{level}] {message}";
                
                // Write to console
                Console.WriteLine(logEntry);

                // Write to file
                if (!string.IsNullOrEmpty(_logFilePath))
                {
                    File.AppendAllText(_logFilePath, logEntry + Environment.NewLine, Encoding.UTF8);
                }
            }
            catch
            {
                // Silently fail if logging fails
            }
        }

        /// <summary>
        /// Get current log file path
        /// </summary>
        public string GetLogFilePath()
        {
            return _logFilePath;
        }

        /// <summary>
        /// Clear old log files (older than 30 days)
        /// </summary>
        public void CleanOldLogs(int daysToKeep = 30)
        {
            try
            {
                if (!Directory.Exists(_logDirectory))
                    return;

                DirectoryInfo di = new DirectoryInfo(_logDirectory);
                FileInfo[] files = di.GetFiles("*.log");

                foreach (FileInfo file in files)
                {
                    if (file.LastAccessTime < DateTime.Now.AddDays(-daysToKeep))
                    {
                        file.Delete();
                    }
                }

                Log($"Cleaned log files older than {daysToKeep} days");
            }
            catch (Exception ex)
            {
                Error($"Failed to clean old logs: {ex.Message}");
            }
        }
    }
}
