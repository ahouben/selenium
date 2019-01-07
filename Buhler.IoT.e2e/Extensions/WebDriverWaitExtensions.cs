using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Buhler.IoT.e2e
{
    public static class WebDriverWaitExtensions
    {
        public static IWebElement WaitUntilDisplayed(this WebDriverWait webDriverWait, Func<IWebElement> getWebElement)
        {
            IWebElement webElement = null;

            webDriverWait.Until(condition =>
            {
                try
                {
                    webElement = getWebElement();
                    return webElement.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            return webElement;
        }

        public static ReadOnlyCollection<IWebElement> WaitUntilFirstDisplayed(this WebDriverWait webDriverWait, Func<ReadOnlyCollection<IWebElement>> getWebElements)
        {
            ReadOnlyCollection<IWebElement> webElements = null;

            webDriverWait.Until(condition =>
            {
                try
                {
                    webElements = getWebElements();

                    if(!webElements.Any())
                    {
                        return false;
                    }

                    return webElements.First().Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });

            return webElements;
        }
    }
}
