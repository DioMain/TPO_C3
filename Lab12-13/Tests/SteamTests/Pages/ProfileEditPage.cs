using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamTests.Pages
{
    internal class ProfileEditPage : PageObject
    {
        private IWebElement profileButton
        {
            get => driver.FindElement(By.XPath("//div[@class='supernav_content']//a[2]"));
        }
        private IWebElement confirmButton
        {
            get => driver.FindElement(By.XPath("//button[@class='DialogButton _DialogLayout Primary Focusable']"));
        }
        private IWebElement descrptionTextarea
        {
            get => driver.FindElement(By.XPath("//textarea[@class='summary_summaryTextArea_2ipSt']"));
        }

        public ProfileEditPage(WebDriver? driver) : base(driver)
        {
        }

        public override PageObject OpenPage()
        {
            throw new NotImplementedException();
        }

        public ProfilePage OpenProfilePage()
        {
            profileButton.Click();

            return new ProfilePage(driver);
        }

        public ProfileEditPage SetDescription(string value)
        {
            descrptionTextarea.SendKeys(value);

            return this;
        }

        public ProfileEditPage ConfirmChanges()
        {
            confirmButton.Click();

            return this;
        }
    }
}
