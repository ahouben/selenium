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
            return WaitUntil(webDriverWait, getWebElement, f => f.Displayed);
        }

        public static IWebElement WaitUntilEnabled(this WebDriverWait webDriverWait, Func<IWebElement> getWebElement)
        {
            return WaitUntil(webDriverWait, getWebElement, f => f.Enabled);
        }

        public static ReadOnlyCollection<IWebElement> WaitUntilFirstDisplayed(this WebDriverWait webDriverWait, Func<ReadOnlyCollection<IWebElement>> getWebElements)
        {
            return WaitUntil(webDriverWait, getWebElements, webElements =>
            {
                if (!webElements.Any())
                {
                    return false;
                }

                return webElements.First().Displayed;
            });
        }
        
        public static void WaitForModal(this WebDriverWait webDriverWait)
        {
            webDriverWait.Until(d =>
            {
                if (d.FindElements(By.ClassName("modal-overlay")).Count == 0)
                {
                    return true;
                }

                return false;
            });
        }

        private static T WaitUntil<T>(this WebDriverWait webDriverWait, Func<T> get, Predicate<T> condition)
        {
            T result = default(T);

            webDriverWait.Until(driver =>
            {
                try
                {
                    result = get();
                    return condition(result);
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

            return result;
        }

    }
}
