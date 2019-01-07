using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Buhler.IoT.e2e.PageObjects
{
    public class LoginPage : BasePageObject
    {    
        public LoginPage(IWebDriver driver, WebDriverWait wait) : base (driver, wait)
        {
        }

        public void Login(string username, string password)
        {
            var emailInput = wait.Until(f => f.FindElement(By.CssSelector("input[name='loginfmt']")));          

            emailInput.SendKeys(username);
            emailInput.SendKeys(Keys.Enter);

            var passwordInput = wait.WaitUntilDisplayed(() => driver.FindElement(By.CssSelector("input[name='passwd']")));           

            passwordInput.SendKeys(password);
            passwordInput.SendKeys(Keys.Enter);

            var dontShowagainEle = wait.WaitUntilDisplayed(() => driver.FindElement(By.CssSelector("input[name='DontShowAgain']")));
            dontShowagainEle.SendKeys(Keys.Enter);
        }       
    }
}
