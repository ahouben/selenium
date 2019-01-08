using Buhler.IoT.e2e.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Buhler.IoT.e2e.PageObjects
{
    public class AddWidgetWizard : BasePageObject
    {
        public AddWidgetWizard(IWebDriver driver, WebDriverWait wait) : base(driver, wait)
        {
        }

        public void SelectWidgetType(string widgetName)
        {
            var row = WaitUntilDisplayed(ElementFinder.ByTextInsideDiv(widgetName));
            row.Click();
        }

        public IWebElement NextButton
        {
            get
            {
                return WaitUntilDisplayed(ElementFinder.ByTextInsideButton("Next"));
            }
        }

        public IWebElement DoneButton
        {
            get
            {
                return WaitUntilDisplayed(ElementFinder.ByTextInsideButton("Done"));
            }
        }

        public IWebElement TitleInput
        {
            get
            {
                return WaitUntilDisplayed(By.Id("widgetTitleInput"));
            }
        }

        public IWebElement FriendlyNameInput
        {
            get
            {
                return WaitUntilDisplayed(By.XPath("(//input[@id[starts-with(.,'friendlyNameInput')]])[1]"));
            }
        }
    }
}
