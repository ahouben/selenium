using Buhler.IoT.e2e.Helpers;
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
            const string DASHBOARD_NAME = "My Dashboard";
            const string WIDGET_NAME = "My Widget";
            const string FRIENDLY_NAME = "My friendly name";

            Login();

            AppPage appPage = new AppPage(driver, wait);
            appPage.ExpandSidenav();

            Dashboard dashboard = appPage.CreateDashboard(DASHBOARD_NAME);
            AddWidgetWizard addWidgetWizard = dashboard.OpenAddWidgetWizard();

            addWidgetWizard.SelectWidgetType("Calculation Value");
            addWidgetWizard.NextButton.Click();
            addWidgetWizard.TitleInput.SendKeys(WIDGET_NAME);
            addWidgetWizard.NextButton.Click();
            addWidgetWizard.FriendlyNameInput.Click();
            addWidgetWizard.FriendlyNameInput.Clear();
            addWidgetWizard.FriendlyNameInput.SendKeys(FRIENDLY_NAME);
            addWidgetWizard.NextButton.Click();
            addWidgetWizard.DoneButton.Click();

            var widgetTitle = wait.WaitUntilDisplayed(() => driver.FindElement(ElementFinder.ByTitleOfDiv(FRIENDLY_NAME)));

            Assert.AreEqual(widgetTitle.Text, FRIENDLY_NAME);
        }
    }
}

