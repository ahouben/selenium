using Buhler.IoT.e2e;
using Buhler.IoT.e2e.PageObjects;
using NUnit.Framework;

namespace Buhler.IoT.e2e
{
    public class LoginLogoutTests : BaseTests
    {     
        [Test]
        public void LoginLogout()
        {
            Login();

            Assert.AreEqual(driver.Title, "Bühler Insights");

            AppPage appPage = new AppPage(driver, wait);
            Assert.AreEqual(8, appPage.SidenavItems.Count);

            appPage.Logout();

            Assert.IsTrue(driver.Url.Contains("https://login.microsoftonline.com/"));
        }
    }
}