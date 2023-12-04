using OpenQA.Selenium;

namespace SteamTests.Pages
{
    internal class SteamPortalPage : PageObject
    {
        private IWebElement addToCartButton
        {
            get => driver.FindElement(By.Id("btn_add_to_cart_515"));
        }


        public SteamPortalPage(WebDriver? driver) : base(driver)
        {
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);
        }

        public override PageObject OpenPage()
        {
            driver.Navigate().GoToUrl("https://store.steampowered.com/app/400/Portal");

            return this;
        }

        public SteamCartPage AddGameToCart()
        {
            addToCartButton.Click();

            return new SteamCartPage(driver);
        }
    }
}
