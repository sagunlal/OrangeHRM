using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Service.PageObjects
{
    public class DashboardPageObjects
    {
        //locator for page header
        public const string DashboardPageHeaderXPath = "//div[@class = 'oxd-topbar-header-title']//h6";

        //locator for logout menu
        public const string UserMenuDropdownXPath = "//li[contains(@class,'oxd-userdropdown')]//p";

        //locator for logoutbutton
        public const string LogoutbtnXPath = "//ul[@class='oxd-dropdown-menu']//a[text()='Logout']";
    }
}
