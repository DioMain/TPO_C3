using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamTests.Pages
{
    internal class WishlistPage : PageObject
    {

        private IWebElement elementTitle
        {
            get => driver.FindElement(By.XPath("//div[@id='wishlist_ctn']//a[@class='title']"));
        }
        private IWebElement elementDeleteButton
        {
            get => driver.FindElement(By.XPath("//div[@id='wishlist_ctn']//div[@class='delete']"));
        }
        private IWebElement deleteConfirm
        {
            get => driver.FindElement(By.XPath("//div[@class='newmodal_buttons']//div[@class='btn_green_steamui btn_medium']/span"));
        }

        public WishlistPage(WebDriver? driver) : base(driver)
        {
        }

        public override PageObject OpenPage()
        {
            throw new NotImplementedException();
        }

        public bool DeleteFirstElement()
        {
            try
            {
                string title = elementTitle.Text;

                elementDeleteButton.Click();

                Thread.Sleep(500);

                deleteConfirm.Click();

                return title != elementTitle.Text;
            }
            catch
            {
                return false;
            }
        }
    }
}
