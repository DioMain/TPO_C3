using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SteamTests.Driver;
using SteamTests.Pages;

namespace SteamTests
{
    [TestClass]
    public class SteamTest
    {
        [TestInitialize]
        public void Init()
        {
            DriverInstance.CreateIntance();
        }

        [TestMethod]
        public void NoMoneyBuyTest()
        {
            string result = (new SteamPortalPage(DriverInstance.Driver).OpenPage() as SteamPortalPage)
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
            const string game = "Портал";

            bool result = (new SteamMainPage(DriverInstance.Driver).OpenPage() as SteamMainPage)
                                .SearchGame(game)
                                .GameIsExistsInSearchResult(game);

            Assert.IsFalse(result, "Game is finded!");
        }

        [TestMethod]
        public void DeleteFromWishlist()
        {
            bool result = (new SteamMainPage(DriverInstance.Driver).OpenPage() as SteamMainPage)
                                .OpenWishlistPage()
                                .DeleteFirstElement();

            Assert.IsTrue(result, "Is not can delete first element!");
        }

        [TestMethod]
        public void AddGameToCart()
        {
            try
            {
                _ = (new SteamPortalPage(DriverInstance.Driver).OpenPage() as SteamPortalPage)
                    .AddGameToCart();

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void ChangeProfileDescription()
        {
            Random rand = new Random();

            string oldDescrption, newDescription;

            ProfilePage profilePage = (new SteamMainPage(DriverInstance.Driver).OpenPage() as SteamMainPage)
                                        .OpenProfilePage();

            oldDescrption = profilePage.profileDescriptionText;

            profilePage = profilePage
                                .OpenEditPage()
                                .SetDescription($"Descrpition {rand.Next(0, 5000)}")
                                .ConfirmChanges()
                                .OpenProfilePage();

            newDescription = profilePage.profileDescriptionText;

            Assert.IsTrue(oldDescrption != newDescription, "Descriptions not equals!");
        }

        [TestCleanup]
        public void Cleaup()
        {
            DriverInstance.CloseDriver();
        }
    }
}