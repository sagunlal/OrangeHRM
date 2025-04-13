using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using OpenQA.Selenium;
using OrangeHRM.Framwork.Core;
using OrangeHRM.Framwork.Support;
using OrangeHRM.Service.PageObjects;

namespace OrangeHRM.Service.PageService
{
    public class DashboardPage : SiteDriver
    {
        IWebDriver _webdriver;

        public DashboardPage(IWebDriver driver) : base(driver)
        {
            _webdriver = driver;
        }
        public string GetPageHeader()
        {
            return FindElement(DashboardPageObjects.DashboardPageHeaderXPath,How.XPath).Text;
        }
        public void Logout()
        {
            FindElement(DashboardPageObjects.UserMenuDropdownXPath,How.XPath).Click();
            WaitForStaticTime(1000);
            FindElement(DashboardPageObjects.LogoutbtnXPath,How.XPath).Click();
        }
    }
}
