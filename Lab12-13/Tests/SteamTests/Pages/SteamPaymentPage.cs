using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SteamTests.Pages
{
    internal class SteamPaymentPage : PageObject
    {
        private IWebElement paymentRowHeader
        {
            get => driver.FindElement(By.Id("payment_row_step2_header"));
        }

        public SteamPaymentPage(WebDriver? driver) : base(driver)
        {
        }

        public override PageObject OpenPage()
        {
            return this;
        }

        public string GetPaymentHeader()
        {
            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(drv => paymentRowHeader);

            Thread.Sleep(2000);

            return paymentRowHeader.Text;
        }
    }
}
