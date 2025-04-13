using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHRM.Framwork.Core;
using OrangeHRM.Framwork.Support;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OrangeHRM.Service.Default
{
    [TestFixture]
    public class Base
    {
        
        public IWebDriver driver;

        protected string screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
        protected ExtentReports _extent;
        protected ExtentTest Log;

        [OneTimeSetUp]
        public void SetupReport()
        {
            _extent = ExtentManager.GetInstance();
        }

        [SetUp] 
        public void setUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());

            var options = new ChromeOptions();
            options.AddArgument("start-maximized"); 
            driver = new ChromeDriver(options);

            string URL = Datareader.Get("BaseUrl");
            driver.Navigate().GoToUrl(URL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            if (!Directory.Exists(screenshotDirectory))
            {
                Directory.CreateDirectory(screenshotDirectory);
            }
            Log = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                string screenshotPath = ScreenshotHelper.CaptureScreenshot(driver, TestContext.CurrentContext.Test.Name);
                Log.Fail($"Test failed! Screenshot: <a href='{screenshotPath}'>Click Here</a>");
            }
            else
            {
                Log.Pass("Test passed successfully");
            }
            driver.Quit();
            driver.Dispose();
        }
        [OneTimeTearDown]
        public void TearDownReport()
        {
            _extent.Flush();
        }
    }
}
