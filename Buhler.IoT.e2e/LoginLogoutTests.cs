using Buhler.IoT.e2e;
using Buhler.IoT.e2e.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using System.Threading;

namespace Tests
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            options.AddArgument("headless");
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void LoginLogout()
        {
            string url = TestContext.Parameters["url"];
            driver.Navigate().GoToUrl(url);

            LoginPage loginPage = new LoginPage(driver, wait);
            loginPage.Login(TestContext.Parameters["username"], TestContext.Parameters["password"]);

            Assert.AreEqual(driver.Title, "Bühler Insights");

            AppPage appPage = new AppPage(driver, wait);
            Assert.AreEqual(8, appPage.SidenavItems.Count);

            appPage.Logout();

            Assert.IsTrue(driver.Url.Contains("https://login.microsoftonline.com/"));
        }
    }
}