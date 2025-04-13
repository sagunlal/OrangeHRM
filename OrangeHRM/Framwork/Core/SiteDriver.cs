using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OrangeHRM.Framwork.Support;
using OrangeHRM.Service.PageObjects;

namespace OrangeHRM.Framwork.Core
{
    public  class SiteDriver :ISiteDriver
    {
        IWebDriver _webdriver;
        public SiteDriver(IWebDriver driver) {
            _webdriver = driver;

        }
        public  string Url
        {
            get { return _webdriver.Url; }

        }
        public  ICookieJar GetCookies
        {
            get { return _webdriver.Manage().Cookies; }

        }
        public  string Title
        {
            get { return _webdriver.Title; }
        }

        public  IWebElement FindElement(string select, How selector, ISearchContext context, int elementTimeOut = 2000)
        {
            switch (selector)
            {
                case How.ClassName:
                    return WaitandReturnElementExists(By.ClassName(select), context, elementTimeOut);
                case How.CssSelector:
                    return WaitandReturnElementExists(By.CssSelector(select), context, elementTimeOut);
                case How.Id:
                    return WaitandReturnElementExists(By.Id(select), context, elementTimeOut);
                case How.LinkText:
                    return WaitandReturnElementExists(By.LinkText(select), context, elementTimeOut);
                case How.Name:
                    return WaitandReturnElementExists(By.Name(select), context, elementTimeOut);
                case How.PartialLinkText:
                    return WaitandReturnElementExists(By.PartialLinkText(select), context, elementTimeOut);
                case How.TagName:
                    return WaitandReturnElementExists(By.TagName(select), context, elementTimeOut);
                case How.XPath:
                    return WaitandReturnElementExists(By.XPath(select), context, elementTimeOut);
            }
            Logger.Info(string.Format("Find Element for locator: {0} using selector: {1}", selector,select));
            throw new NotSupportedException(string.Format("Selector \"{0}\" is not supported.", selector));
        }

        public  IWebElement FindElement(string select, How selector)
        {
            return FindElement(select, selector, _webdriver);
        }

        public  IEnumerable<IWebElement> FindElements(string select, How selector, ISearchContext context, int elementTimeOut = 2000)
        {
            switch (selector)
            {
                case How.ClassName:
                    return WaitandReturnElementsExists(By.ClassName(select), context, elementTimeOut);
                case How.CssSelector:
                    return WaitandReturnElementsExists(By.CssSelector(select), context, elementTimeOut);
                case How.Id:
                    return WaitandReturnElementsExists(By.Id(select), context, elementTimeOut);
                case How.LinkText:
                    return WaitandReturnElementsExists(By.LinkText(select), context, elementTimeOut);
                case How.Name:
                    return WaitandReturnElementsExists(By.Name(select), context, elementTimeOut);
                case How.PartialLinkText:
                    return WaitandReturnElementsExists(By.PartialLinkText(select), context, elementTimeOut);
                case How.TagName:
                    return WaitandReturnElementsExists(By.TagName(select), context, elementTimeOut);
                case How.XPath:
                    return WaitandReturnElementsExists(By.XPath(select), context, elementTimeOut);
            }
            throw new NotSupportedException(string.Format("Selector \"{0}\" is not supported.", selector));
        }

        public  IEnumerable<IWebElement> FindElements(string select, How selector)
        {
            throw new NotImplementedException();
        }

        public  int FindElementsCount(string select, How selector)
        {
            return FindElements(select, selector, _webdriver).Count();
        }

        public IEnumerable<Cookie> GetAllCookies()
        {
            return _webdriver.Manage().Cookies.AllCookies;
        }
        public string FindElementAndGetAttribute(String select, How selector, string attribute = "id")
        {
            Logger.Info(string.Format(" Element attribute Return for Locator: {0} using selector: {1} Attribute: {2}", LoginPageObject.LoginErrorAlertMessageXPath, How.XPath,attribute));

            return FindElements(select, selector, _webdriver).Last().GetAttribute(attribute);
        }

        public  bool IsElementDisplayed(string select, How selector, int timeOut = 0)
        {
            try
            {
                return FindElement(select, selector, _webdriver, timeOut).Displayed;
            }
            catch (Exception ex)
            {
                // Don't handle NotSupportedException
                if (ex is NotSupportedException)
                    throw;
                return false;
            }
        }

        public  bool IsElementEnabled(string select, How selector, int timeOut = 0)
        {
            try
            {
                return FindElement(select, selector, _webdriver, timeOut).Enabled;
            }
            catch (Exception ex)
            {
                // Don't handle NotSupportedException
                if (ex is NotSupportedException)
                    throw;
                return false;
            }
        }

        public  bool IsElementPresent(string select, How selector, IWebElement context)
        {
            try
            {
                FindElement(select, selector, _webdriver, 10000);
                return true;
            }
            catch (Exception ex)
            {
                // Don't handle NotSupportedException
                if (ex is NotSupportedException)
                    throw;
                return false;
            }
        }
        public  bool IsElementPresent(string select, How selector, int timeOut = 0)
        {
            try
            {
                FindElement(select, selector, _webdriver, timeOut);
                return true;
            }
            catch (Exception ex)
            {
                // Don't handle NotSupportedException
                if (ex is NotSupportedException)
                    throw;
                return false;
            }
        }


        public  IWebElement WaitandReturnElementExists(By locator, ISearchContext context, int elementTimeOut = 2000)
        {
            try
            {
                if (elementTimeOut == 0)
                    return context.FindElement(locator);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to find element for locator {locator} in page {_webdriver.Url}");
            }

            var wait = new WebDriverWait(new SystemClock(), _webdriver, TimeSpan.FromMilliseconds(10000), TimeSpan.FromMilliseconds(10000));
            IWebElement webElement = null;
            try
            {
                wait.Until(driver =>
                {
                    try
                    {
                        webElement = context.FindElement(locator);
                        return webElement != null;

                    }
                    catch (Exception ex)
                    {
                        //Console.Out.WriteLine($"Searching for locator {locator} in page  \nException Message\n" + ex.Message);
                        return false;
                    }
                });
            }
            catch (Exception e)
            {
                if (webElement == null)
                    throw new Exception($"Unable to find element for locator {locator} in page {_webdriver.Url}");
            }

            return webElement;
        }
        public  IEnumerable<IWebElement> WaitandReturnElementsExists(By locator, ISearchContext context, int elementTimeOut = 2000)
        {
            if (elementTimeOut == 0)
                return context.FindElements(locator);

            var wait = new WebDriverWait(new SystemClock(), _webdriver, TimeSpan.FromMilliseconds(10000), TimeSpan.FromMilliseconds(10000));
            IEnumerable<IWebElement> webElement = null;
            wait.Until(driver =>
            {
                try
                {
                    webElement = context.FindElements(locator);
                    return webElement != null;

                }
                catch (Exception ex)
                {
                    //Console.Out.WriteLine("unhandled exception" + ex.Message);
                    return false;
                }
            });
            return webElement;
        }

        public void WaitForStaticTime(int time)
        {
            Thread.Sleep(time);
        }

        protected string screenshotDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots");
    }
}
