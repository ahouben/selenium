using Buhler.IoT.e2e.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
            var browser = TestContext.Parameters["browser"].ToLower();

            if (browser == "chrome")
            {
                ChromeOptions chromeOptions = new ChromeOptions();

                if (bool.TryParse(TestContext.Parameters["incognito"], out bool incognito) && incognito)
                {
                    chromeOptions.AddArgument("incognito");
                }

                if (bool.TryParse(TestContext.Parameters["headless"], out bool headless) && headless)
                {
                    chromeOptions.AddArgument("headless");
                }

                driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            }
            else if (browser == "firefox")
            {
                FirefoxOptions firefoxOptions = new FirefoxOptions();

                if (bool.TryParse(TestContext.Parameters["incognito"], out bool incognito) && incognito)
                {
                    firefoxOptions.AddArgument("--private");
                }

                if (bool.TryParse(TestContext.Parameters["headless"], out bool headless) && headless)
                {
                    firefoxOptions.AddArgument("--headless");
                }

                driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), firefoxOptions);
            }

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
            // Close browsers after tests have run.
            driver.Close();
        }
    }
}
