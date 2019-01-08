using Buhler.IoT.e2e.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Buhler.IoT.e2e.PageObjects
{
    public class Dashboard : BasePageObject
    {
        public string Name { get; private set; }

        public Dashboard(string name, IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
            Name = name;
        }

        public IWebElement EditDashboardButton
        {
            get
            {
                return WaitUntilDisplayed(ElementFinder.ByTitleOfLink("Edit Dashboard"));
            }
        }

        public IWebElement AddWidgetButton
        {
            get
            {
                return WaitUntilDisplayed(ElementFinder.ByTitleOfLink("Add widget"));
            }
        }

        public AddWidgetWizard OpenAddWidgetWizard()
        {
            EditDashboardButton.Click();
            AddWidgetButton.Click();

            return new AddWidgetWizard(driver, wait);
        }
    }
}
