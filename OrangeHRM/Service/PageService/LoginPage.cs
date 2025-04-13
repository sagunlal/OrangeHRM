using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OrangeHRM.Framwork.Core;
using OrangeHRM.Framwork.Support;
using OrangeHRM.Service.Default;
using OrangeHRM.Service.PageObjects;

namespace OrangeHRM.Service.PageService
{
    public class LoginPage : SiteDriver
    {
        IWebDriver _webdriver;
        public string validUsername =Datareader.Get("Username");
        public string validPassword =Datareader.Get("Password");
        public string invalidPassword =Datareader.Get("InvalidPassword");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            _webdriver = driver;
        }

        public void ValidLogin()
        {

            SetUsernameField(validUsername);
            SetPasswordField(validPassword);
            ClickLoginButton();
        }
        public void InvalidLogin()
        {

            SetUsernameField(validUsername);
            SetPasswordField(invalidPassword);
            ClickLoginButton();
        }
        public string GetHiddenAuthToken()
        {
            Logger.Info(string.Format(" Get Auth token using Locator: {0} using selector: {1}", LoginPageObject.HiddenAutTokenXPath, How.XPath));

            return FindElementAndGetAttribute(LoginPageObject.HiddenAutTokenXPath, How.XPath, "value");
        }

        #region Private Methods
        #region Username Field Functions
        public void ClickOnUsernameInputBox()
        {
            FindElement(LoginPageObject.UsernameInputXPath, How.XPath).Click();
        }
        public void SetUsernameField(string username)
        {
            IWebElement element = FindElement(LoginPageObject.UsernameInputXPath, How.XPath);

            element.Clear();
            Logger.Info(string.Format("Clear Element for Locator: {0} using selector: {1}", LoginPageObject.UsernameInputXPath, How.XPath));

            element.SendKeys(username);
            Logger.Info(string.Format("Sent text value for Locator: {0} using selector: {1} with value: {2}", LoginPageObject.UsernameInputXPath, How.XPath,username));

        }
        #endregion

        #region Password Field functions
        public void ClickOnPasswordInputBox()
        {
            FindElement(LoginPageObject.PasswordInputXPath, How.XPath).Click();

        }
        public void SetPasswordField(string password)
        {
            IWebElement element = FindElement(LoginPageObject.PasswordInputXPath, How.XPath);
            element.Clear();
            Logger.Info(string.Format("Clear Element for Locator: {0} using selector: {1}", LoginPageObject.PasswordInputXPath, How.XPath));
            element.SendKeys(password);
            Logger.Info(string.Format("Sent text value for Locator: {0} using selector: {1} with value: {2}", LoginPageObject.UsernameInputXPath, How.XPath, password));

        }
        #endregion

        #region Login Button Functions
        public void ClickLoginButton()
        {
            FindElement(LoginPageObject.LoginButtonXPath, How.XPath).Click();
            Logger.Info(string.Format("Click Element for Locator: {0} using selector: {1}", LoginPageObject.LoginButtonXPath, How.XPath));

        }
        #endregion

        #region Alertbox functions
        public bool IsAlertMessagePresent()
        {
            Logger.Info(string.Format(" Element present check for Locator: {0} using selector: {1}", LoginPageObject.LoginErrorAlertMessageXPath, How.XPath));

            return IsElementPresent(LoginPageObject.LoginErrorAlertMessageXPath, How.XPath);
        }
        public string GetAlertMessage()
        {
            Logger.Info(string.Format("String return for  Element for Locator: {0} using selector: {1}", LoginPageObject.LoginErrorAlertMessageXPath, How.XPath));

            return FindElement(LoginPageObject.LoginErrorAlertMessageXPath, How.XPath).Text;
        }
        #endregion 
        #endregion

    }
}
