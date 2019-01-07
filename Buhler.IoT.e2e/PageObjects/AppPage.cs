using Buhler.IoT.e2e.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Threading;

namespace Buhler.IoT.e2e.PageObjects
{

    public class AppPage : BasePage
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
                return wait.WaitUntilDisplayed(() => driver.FindElement(By.XPath("//*[contains(@class, 'sidenav-container')]/*[@class='expander']")));
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

        public void CreateDashboard(string name)
        {
            ExpandSidenav();

            var dashboardbutton = wait.WaitUntilDisplayed(() => driver.FindElement(ByExtensions.TextInsideDiv("Dashboard")));
            dashboardbutton.Click();

            var addNewPanelButton = wait.WaitUntilDisplayed(() => driver.FindElement(By.Id("addNewPanelButton")));
            addNewPanelButton.Click();

            var nameInput = wait.WaitUntilDisplayed(() => driver.FindElement(By.Id("name")));
            nameInput.Clear();
            nameInput.SendKeys(name);

            var submitButton = wait.WaitUntilDisplayed(() => driver.FindElement(By.XPath("//button[@type='submit']")));
            submitButton.Click();

            wait.WaitForModal();          
        }

        public void AddCalculationWidgetWithFriendlyName(string widgetName, string friendlyName)
        {
            var editDashboardButton = wait.WaitUntilDisplayed(() => driver.FindElement(By.XPath("//a[@title='Edit Dashboard']")));
            editDashboardButton.Click();

            var addWidgetButton = wait.WaitUntilDisplayed(() => driver.FindElement(By.XPath("//a[@title='Add widget']")));
            addWidgetButton.Click();

            var calculationCheckBox = wait.WaitUntilDisplayed(() => driver.FindElement(ByExtensions.TextInsideDiv("Calculation Value")));
            calculationCheckBox.Click();

            var nextButton = wait.WaitUntilDisplayed(() => driver.FindElement(ByExtensions.TextInsideButton("Next")));
            nextButton.Click();

            var titleInput = wait.WaitUntilDisplayed(() => driver.FindElement(By.Id("widgetTitleInput")));
            titleInput.SendKeys(widgetName);

            nextButton.Click();

            var selectPlant = wait.WaitUntilEnabled(() => driver.FindElement(By.XPath("//label[text()='Plant']/following-sibling::select")));
            var option = wait.WaitUntilEnabled(() => driver.FindElement(By.XPath("(//label[text()='Plant']/following-sibling::select/option)[1]")));
           
            var selectElement = new SelectElement(selectPlant);

            selectElement.SelectByIndex(0);

            var friendlyNameInput = wait.WaitUntilEnabled(() => driver.FindElement(By.XPath("(//input[@id[starts-with(.,'friendlyNameInput')]])[1]")));
            friendlyNameInput.Click();
            friendlyNameInput.Clear();
            friendlyNameInput.SendKeys(friendlyName);

            nextButton.Click();
            var doneButton = wait.WaitUntilDisplayed(() => driver.FindElement(ByExtensions.TextInsideButton("Done")));
            doneButton.Click();

            
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
