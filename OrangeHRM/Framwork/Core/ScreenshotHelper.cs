using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OrangeHRM.Framwork.Core
{
    public static class ScreenshotHelper
    {
        // Automatically uses the DLL directory for screenshots
        private static readonly string screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");

        // Call this to take a screenshot
        public static void TakeScreenshot(IWebDriver driver, string testName)
        {
            try
            {
                if (!Directory.Exists(screenshotDirectory))
                    Directory.CreateDirectory(screenshotDirectory);

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileName = $"{testName}_{timestamp}.png";
                string fullPath = Path.Combine(screenshotDirectory, fileName);

                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(fullPath);

                Console.WriteLine($"Screenshot saved at: {fullPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error taking screenshot: {ex.Message}");
            }
        }
    }
}
