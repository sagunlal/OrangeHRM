using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OrangeHRM.Framwork.Core;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace OrangeHRM.Service.Default
{
    [TestFixture]
    public class Base
    {
        
        public IWebDriver driver;

        protected string screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");


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
        }

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                ScreenshotHelper.TakeScreenshot(driver, TestContext.CurrentContext.Test.Name);
            }
            driver.Quit();
            driver.Dispose();
        }
    }
}
