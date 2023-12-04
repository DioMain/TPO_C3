using OpenQA.Selenium;

namespace SteamTests
{
    internal abstract class PageObject
    {
        protected WebDriver? driver;

        public PageObject(WebDriver? driver) 
        { 
            this.driver = driver;
        }

        public abstract PageObject OpenPage();
    }
}
