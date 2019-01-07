using Buhler.IoT.e2e.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

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

        public Dashboard CreateDashboard(string name)
        {
            var dashboardbutton = WaitUntilDisplayed(ElementFinder.ByTextInsideDiv("Dashboard"));
            dashboardbutton.Click();

            var addNewPanelButton = WaitUntilDisplayed(By.Id("addNewPanelButton"));
            addNewPanelButton.Click();

            var nameInput = WaitUntilDisplayed(By.Id("name"));
            nameInput.Clear();
            nameInput.SendKeys(name);

            var submitButton = WaitUntilDisplayed(By.XPath("//button[@type='submit']"));
            submitButton.Click();

            wait.WaitForModal();

            return new Dashboard(driver, wait);
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
