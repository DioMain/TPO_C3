using OpenQA.Selenium;

namespace SteamTests.Pages
{
    internal class SteamCartPage : PageObject
    {
        private IWebElement purchaseForSelfButton
        {
            get => driver.FindElement(By.Id("btn_purchase_self"));
        }

        public SteamCartPage(WebDriver? driver) : base(driver)
        {
        }

        public override PageObject OpenPage()
        {
            return this;
        }

        public SteamPaymentPage ByeForSelf()
        {
            purchaseForSelfButton.Click();

            return new SteamPaymentPage(driver);
        }
    }
}
