using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Framwork.Support
{
    public static class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", $"log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");

        static Logger()
        {
            string logDir = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);
        }

        public static void Info(string message)
        {
            WriteLog("INFO", message);
        }

        public static void Error(string message)
        {
            WriteLog("ERROR", message);
        }

        public static void Warn(string message)
        {
            WriteLog("WARN", message);
        }

        private static void WriteLog(string level, string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            Console.WriteLine(logEntry); // Optional: write to console
        }
    }
}
