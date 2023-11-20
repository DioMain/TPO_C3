using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

using SteamTests.Pages;

namespace SteamTests
{
    [TestClass]
    public class SteamTest
    {
        private WebDriver? driver;

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

            string result = (new SteamPortalPage(driver).OpenPage() as SteamPortalPage)
                                .AddGameToCart()
                                .ByeForSelf()
                                .GetPaymentHeader();

            Assert.IsTrue(string.Compare(
                "В кошельке Steam недостаточно средств для совершения операции!",
                result) == 0, result);
        }

        [TestMethod]
        public void CyrillicSearchTest()
        {
            if (driver == null)
                Assert.Fail("Driver not started!");

            const string game = "Портал";

            bool result = (new SteamMainPage(driver).OpenPage() as SteamMainPage)
                                .SearchGame(game)
                                .GameIsExistsInSearchResult(game);

            Assert.IsFalse(result, "Game is finded!");
        }

        [TestCleanup]
        public void Cleaup()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}