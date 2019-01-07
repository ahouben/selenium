using Buhler.IoT.e2e.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;

namespace Buhler.IoT.e2e
{
    public class BaseTests
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("incognito");
            options.AddArgument("headless");
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected void Login()
        {
            string url = TestContext.Parameters["url"];
            driver.Navigate().GoToUrl(url);

            LoginPage loginPage = new LoginPage(driver, wait);
            loginPage.Login(TestContext.Parameters["username"], TestContext.Parameters["password"]);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
