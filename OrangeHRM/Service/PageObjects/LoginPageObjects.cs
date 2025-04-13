using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM.Service.PageObjects
{
    public class LoginPageObject
    {
        #region Locators
        // Locators for username textbox
        public const string UsernameInputXPath = "//input[@name = 'username']";

        // Locators for password textbox
        public const string PasswordInputXPath = "//input[@name = 'password']";

        // Locators for Login button
        public const string LoginButtonXPath = "//button[@type= 'submit']";

        //Locator for login fail message
        public const string LoginErrorAlertMessageXPath = "//div[@class='orangehrm-login-error']//p";

        //Locator for hidden auth token
        public const string HiddenAutTokenXPath = "//input[@type='hidden']";

        #endregion
    }
}
