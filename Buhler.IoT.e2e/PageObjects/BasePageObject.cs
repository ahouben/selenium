using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buhler.IoT.e2e.PageObjects
{
    public class BasePageObject
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePageObject(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        protected  IWebElement WaitUntilDisplayed(By by)
        {
            return wait.WaitUntilDisplayed(() => driver.FindElement(by));
        }
    }
}
