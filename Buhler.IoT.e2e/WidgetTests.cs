using Buhler.IoT.e2e.Helpers;
using Buhler.IoT.e2e.PageObjects;
using NUnit.Framework;
using System;
using System.Threading;

namespace Buhler.IoT.e2e
{
    public class WidgetTests : BaseTests
    {
        [Test]
        public void CheckFriendlyName()
        {
            const string FRIENDLY_NAME = "My friendly name";

            Login();

            AppPage appPage = new AppPage(driver, wait);

            string dashboardName = "My Dashboard " + DateTime.Now.ToString("yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
            Dashboard dashboard = appPage.CreateDashboard(dashboardName);

            AddWidgetWizard addWidgetWizard = dashboard.OpenAddWidgetWizard();

            addWidgetWizard.SelectWidgetType("Calculation Value");
            addWidgetWizard.NextButton.Click();
            addWidgetWizard.TitleInput.SendKeys("My Widget");
            addWidgetWizard.NextButton.Click();
            addWidgetWizard.FriendlyNameInput.Click();
            addWidgetWizard.FriendlyNameInput.Clear();
            addWidgetWizard.FriendlyNameInput.SendKeys(FRIENDLY_NAME);
            addWidgetWizard.NextButton.Click();
            addWidgetWizard.DoneButton.Click();

            var widgetTitle = wait.WaitUntilDisplayed(() => driver.FindElement(ElementFinder.ByTitleOfDiv(FRIENDLY_NAME)));

            // Check whether the friendly name has been set correctly.
            Assert.AreEqual(widgetTitle.Text, FRIENDLY_NAME);

            appPage.DeleteDashboard(dashboard.Name);
            var hasDashboard = appPage.HasDashboard(dashboard.Name);

            Assert.IsFalse(hasDashboard);
        }
    }
}

