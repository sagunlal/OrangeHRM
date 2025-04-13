using OpenQA.Selenium;
using OrangeHRM.Framwork.Core;
using OrangeHRM.Framwork.Support;
using OrangeHRM.Service.Default;
using OrangeHRM.Service.PageService;

namespace OrangeHRM
{
    public class Tests : Base
    {
        [Test]
        public void Verify_Login_Session()
        {
            LoginPage loginPage =new LoginPage(driver);
            DashboardPage dashboardPage =new DashboardPage(driver);

            Log.Info("Authentication Token: " + loginPage.GetHiddenAuthToken());

            loginPage.ValidLogin();

            var cookies = loginPage.GetAllCookies();

            foreach (var cookie in cookies)
            {
                if (cookie.Expiry == null)
                {
                    Log.Info("Cookie for authentication: " + cookie);
                }
            }

            Assert.That(dashboardPage.GetPageHeader(), Is.EqualTo("Dashboard"), "User should be logged into default Dashboard page.");

            dashboardPage.Logout();

            loginPage.InvalidLogin();
            Assert.That(loginPage.IsAlertMessagePresent(), Is.EqualTo(true), "Alert message should be present.");
            Assert.That(loginPage.GetAlertMessage(), Is.EqualTo("Invalid credentials"), "Login should fail for invalid credenrtials");

            Assert.Fail();

        }
    }
}  