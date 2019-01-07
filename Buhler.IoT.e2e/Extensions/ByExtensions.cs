using OpenQA.Selenium;

namespace Buhler.IoT.e2e.Extensions
{
    public static class ByExtensions
    {
        public static By TextInsideDiv(string text)
        {
            string xPath = "//div[contains(text(),'" + text + "')]";
            return By.XPath(xPath);
        }

        public static By TextInsideButton(string text)
        {
            string xPath = "//button[contains(text(),'" + text + "')]";
            return By.XPath(xPath);
        }
    }
}
