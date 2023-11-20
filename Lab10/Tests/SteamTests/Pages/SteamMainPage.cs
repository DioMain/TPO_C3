using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SteamTests.Pages
{
    internal class SteamMainPage : PageObject
    {
        private IWebElement searchBar
        {
            get => driver.FindElement(By.Id("store_nav_search_term"));
        }
        private IWebElement searchForm
        {
            get => driver.FindElement(By.Id("searchform"));
        }

        public SteamMainPage(WebDriver? driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }

        public override PageObject OpenPage()
        {
            driver.Navigate().GoToUrl("https://store.steampowered.com");

            return this;
        }

        public SteamMainPage SearchGame(string name)
        {
            searchBar.SendKeys(name);
            searchForm.Submit();

            return this;
        }

        public bool GameIsExistsInSearchResult(string name)
        {
            By by = By.XPath($"//div[@id='search_resultsRows']//span[@class='title' and text()='{name}']");

            try
            {
                _ = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(drv => drv.FindElement(by));
            }
            catch
            {
                return false;
            }
            
            return true;
        }
    }
}
