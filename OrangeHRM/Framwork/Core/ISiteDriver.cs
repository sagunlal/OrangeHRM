using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OrangeHRM.Framwork.Support;

namespace OrangeHRM.Framwork.Core
{
    public interface ISiteDriver
    {
        string Url { get; }
        string Title { get; }
        IWebElement FindElement(string select, How selector, ISearchContext context, int elementTimeOut = 2000);
        IWebElement FindElement(string select, How selector);
        IEnumerable<IWebElement> FindElements(string select, How selector);
        int FindElementsCount(string select, How selector);
        bool IsElementDisplayed(string select, How selector, int timeOut = 0);
        bool IsElementPresent(string select, How selector, IWebElement context);
        bool IsElementPresent(string select, How selector, int timeOut = 0);
        bool IsElementEnabled(string select, How selector, int timeOut = 0);
        IEnumerable<Cookie> GetAllCookies();
        string FindElementAndGetAttribute(String select, How selector, string attribute = "id");
        void WaitForStaticTime(int time);
    }
}
