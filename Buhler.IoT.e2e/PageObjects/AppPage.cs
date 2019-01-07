using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Buhler.IoT.e2e.PageObjects
{

    public class AppPage : BasePage
    {
        public AppPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void Logout()
        {
            var menu = wait.WaitUntilDisplayed(() => driver.FindElement(By.CssSelector(".overflowMenu .dropdown-button")));
            menu.Click();

            var logout = wait.WaitUntilDisplayed(() => driver.FindElement(By.CssSelector(".icon--logout")));
            logout.Click();
        }

        public ReadOnlyCollection<IWebElement> SidenavItems
        {
            get
            {
                return wait.WaitUntilFirstDisplayed(() => driver.FindElements(By.CssSelector("sidenav-item")));
            }
        }
    }
}
