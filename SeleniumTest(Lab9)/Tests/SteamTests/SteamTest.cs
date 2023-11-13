using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SteamTests
{
    [TestClass]
    public class SteamTest
    {
        private WebDriver? driver;

        private IWebElement addToCartButton
        {
            get => driver.FindElement(By.Id("btn_add_to_cart_515"));
        }

        private IWebElement purchaseForSelfButton
        {
            get => driver.FindElement(By.Id("btn_purchase_self"));
        }

        private IWebElement paymentRowHeader
        {
            get => driver.FindElement(By.Id("payment_row_step2_header"));
        }

        [TestInitialize]
        public void Init()
        {
            EdgeOptions options = new EdgeOptions();

            string userProfilePath = "C:\\Users\\Xyandopovich\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default";

            options.AddArgument($"user-data-dir={userProfilePath}");

            driver = new EdgeDriver("msedgedriver.exe", options);
        }

        [TestMethod]
        public void NoMoneyBuyTest()
        {
            if (driver == null)
                Assert.Fail("Driver not started!");

            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 0, 20);
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 30);

            driver.Navigate().GoToUrl("https://store.steampowered.com/app/400/Portal");

            addToCartButton.Click();

            purchaseForSelfButton.Click();

            _ = new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(drv => paymentRowHeader);

            Thread.Sleep(5000);

            string testResult = paymentRowHeader.Text;

            driver.Quit();

            Assert.IsTrue(string.Compare(
                "В кошельке Steam недостаточно средств для совершения операции!",
                testResult) == 0, testResult);
        }
    }
}