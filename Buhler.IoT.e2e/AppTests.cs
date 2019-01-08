using Buhler.IoT.e2e.PageObjects;
using NUnit.Framework;

namespace Buhler.IoT.e2e
{
    public class AppTests : BaseTests
    {     
        [Test]
        public void LoginLogout()
        {
            Login();

            // Check whether login has worked by looking at the browser title.
            Assert.AreEqual(driver.Title, "Bühler Insights");

            AppPage appPage = new AppPage(driver, wait);

            // Check whether there are 8 menu items in the left navigation bar.
            Assert.AreEqual(8, appPage.SidenavItems.Count);

            appPage.Logout();

            // Check whether logout worked by looking at the url.
            Assert.IsTrue(driver.Url.Contains("https://login.microsoftonline.com/"));
        }
    }
}