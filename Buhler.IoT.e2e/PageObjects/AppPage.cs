using Buhler.IoT.e2e.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace Buhler.IoT.e2e.PageObjects
{

    public class AppPage : BasePageObject
    {
        public AppPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }
               
        public ReadOnlyCollection<IWebElement> SidenavItems
        {
            get
            {
                return wait.WaitUntilFirstDisplayed(() => driver.FindElements(By.CssSelector("sidenav-item")));
            }
        }       

        public IWebElement SidenavExpander
        {
            get
            {
                return WaitUntilDisplayed(By.XPath("//*[contains(@class, 'sidenav-container')]/*[@class='expander']"));
            }
        }

        public bool IsSidenavExpanded
        {
            get
            {
                if (SidenavExpander.Text == "chevron_left")
                {
                    return true;
                }

                return false;
            }
        }

        public void Logout()
        {
            var menu = wait.WaitUntilDisplayed(() => driver.FindElement(By.CssSelector(".overflowMenu .dropdown-button")));
            menu.Click();

            var logout = wait.WaitUntilDisplayed(() => driver.FindElement(By.CssSelector(".icon--logout")));
            logout.Click();
        }

        public IWebElement DashboardButton
        {
            get
            {
                return WaitUntilDisplayed(ElementFinder.ByTextInsideDiv("Dashboard"));
            }
        }

        public Dashboard CreateDashboard(string name)
        {
            ExpandSidenav();
            DashboardButton.Click();

            var addNewPanelButton = WaitUntilDisplayed(By.Id("addNewPanelButton"));
            addNewPanelButton.Click();

            var nameInput = WaitUntilDisplayed(By.Id("name"));
            nameInput.Clear();
            nameInput.SendKeys(name);

            var submitButton = WaitUntilDisplayed(By.XPath("//button[@type='submit']"));
            submitButton.Click();

            wait.WaitForModal();

            return new Dashboard(name, driver, wait);
        }

        public void DeleteDashboard(string name)
        {
            ExpandSidenav();
            DashboardButton.Click();

            var deleteButton = WaitUntilDisplayed(By.XPath("//div[contains(text(), '" + name + "')]/following-sibling::div[contains(@class, 'submenu-button-group')]"));
            deleteButton.Click();
            var okButton = WaitUntilDisplayed(By.XPath("//confirmation-dialog//button[contains(text(), 'Ok')]"));
            okButton.Click();

            wait.WaitForModal();
        }

        public bool HasDashboard(string name)
        {
            ExpandSidenav();
            DashboardButton.Click();

            var dashboardList = WaitUntilDisplayed(By.XPath("//sidenav-submenu-panels/div[@class='submenu-header']/following-sibling::ul"));            
            var elements = dashboardList.FindElements(By.XPath("//div[contains(text(), '" + name + "')]"));

            return elements.Count > 0;
        }

        public void ExpandSidenav()
        {
            if(IsSidenavExpanded)
            {
                this.SidenavExpander.Click();
            }

            this.SidenavExpander.Click();
        }       
    }
}
