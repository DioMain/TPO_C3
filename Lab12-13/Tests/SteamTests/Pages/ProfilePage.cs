using OpenQA.Selenium;

namespace SteamTests.Pages
{
    internal class ProfilePage : PageObject
    {
        private IWebElement editProfileButton
        {
            get => driver.FindElement(By.XPath("//a[@class='btn_profile_action btn_medium']"));
        }

        private IWebElement profileDescription
        {
            get => driver.FindElement(By.XPath("//div[@class='profile_summary noexpand']"));
        }

        public string profileDescriptionText => profileDescription.Text;

        public ProfilePage(WebDriver? driver) : base(driver)
        {
        }

        public override PageObject OpenPage()
        {
            throw new NotImplementedException();
        }

        public ProfileEditPage OpenEditPage()
        {
            editProfileButton.Click();

            return new ProfileEditPage(driver);
        }
    }
}
