using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace OrangeHRM.Framwork.Support
{
    public static class ExtentManager
    {
        private static ExtentReports _extent;
        private static ExtentSparkReporter _sparkReporter;

        public static ExtentReports GetInstance()
        {
            if (_extent == null)
            {
                string reportDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                Directory.CreateDirectory(reportDir);

                string reportPath = Path.Combine(reportDir, $"TestReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");
                _sparkReporter = new ExtentSparkReporter(reportPath);
                _extent = new ExtentReports();
                _extent.AttachReporter(_sparkReporter);
            }

            return _extent;
        }
    }
}
