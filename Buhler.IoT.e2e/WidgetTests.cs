using Buhler.IoT.e2e.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Buhler.IoT.e2e
{
    public class WidgetTests : BaseTests
    {
        [Test]
        public void CheckFriendlyName()
        {
            Login();
            AppPage appPage = new AppPage(driver, wait);
            appPage.CreateDashboard("Test Dashboard");
            appPage.AddCalculationWidgetWithFriendlyName("Test Widget", "My friendly Name");
            var widgetTitle = wait.WaitUntilDisplayed(() => driver.FindElement(By.XPath("//div[@title='My friendly Name']")));
            Assert.AreEqual(widgetTitle.Text, "My friendly Name");
        }
    }
}
