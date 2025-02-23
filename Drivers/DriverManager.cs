using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SauceDemoShop.Drivers
{
    public class DriverManager
    {
        private IWebDriver? _driver;

        public IWebDriver InitializeDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            return _driver;
        }

        public void QuitDriver()
        {
            _driver?.Quit();
        }
    }
}
