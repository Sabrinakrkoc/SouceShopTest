using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoShop.Drivers;
using Microsoft.Extensions.Configuration;

namespace SauceDemoShop.Base
{
    public class BaseTest
    {
        protected IWebDriver _driver;
        private DriverManager _driverManager;

        [SetUp]
        public void SetUp()
        {
            _driverManager = new DriverManager();
            _driver = _driverManager.InitializeDriver();
            _driver.Navigate().GoToUrl(Config.ConfigReader.GetBaseUrl());
        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
