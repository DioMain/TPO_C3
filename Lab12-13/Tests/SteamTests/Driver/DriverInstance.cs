using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamTests.Driver
{
    public static class DriverInstance
    {
        private static WebDriver? driver;
        public static WebDriver? Driver => driver;

        public static void CreateIntance(string browser = "edge")
        {
            if (driver == null)
            {
                EdgeOptions options = new EdgeOptions();

                string userProfilePath = "";

                switch (browser)
                {
                    case "edge":
                        userProfilePath = "C:\\Users\\Xyandopovich\\AppData\\Local\\Microsoft\\Edge\\User Data\\Default";

                        options.AddArgument($"user-data-dir={userProfilePath}");

                        driver = new EdgeDriver("msedgedriver.exe", options);
                        break;
                    default:
                        driver = new EdgeDriver("msedgedriver.exe", options);
                        break;
                }

                
            }

            driver?.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            driver?.Manage().Window.Maximize();
        }

        public static void CloseDriver()
        {
            if (driver != null)
            {
                driver?.Close();
                driver?.Dispose();
            }
        }
    }
}
