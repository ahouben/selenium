using OpenQA.Selenium;

namespace Buhler.IoT.e2e.Helpers
{
    public static class ElementFinder
    {
        public static By ByTextInsideDiv(string text)
        {
            return ByTextInsideType("div", text);
        }

        public static By ByTextInsideButton(string text)
        {
            return ByTextInsideType("button", text);
        }

        public static By ByTitleOfDiv(string text)
        {
            return ByTitleOfType("div", text);
        }

        public static By ByTitleOfLink(string text)
        {
            return ByTitleOfType("a", text);
        }

        private static By ByTitleOfType(string type, string text)
        {
            return By.XPath(XPathHelper.ByTitleOfType(type, text));
        }

        private static By ByTextInsideType(string type, string text)
        {            
            return By.XPath(XPathHelper.ByTextInsideType(type, text));
        }

        private class XPathHelper
        {
            public static string ByTextInsideType(string type, string text)
            {
                string xPath = "//" + type + "[contains(text(),'" + text + "')]";
                return xPath;
            }

            public static string ByTitleOfType(string type, string text)
            {
                string xPath = "//" + type + "[@title='" + text + "']";
                return xPath;
            }
        }
    }
}
