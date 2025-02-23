using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;  // Usar esta nueva referencia
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoShop.Base;
using SauceDemoShop.Pages;
using System;

namespace SauceDemoShop.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class LoginTests : BaseTest
    {
        private LoginPage loginPage;

        [SetUp]
        public void BeforeTest()
        {
            loginPage = new LoginPage(_driver);
        }

        [Test]
        [AllureFeature("Login")]
        [AllureSeverity(SeverityLevel.critical)]
        public void ValidLoginTest()
        {
            loginPage.Login("standard_user", "secret_sauce");

            Assert.That(_driver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }

        [Test]
        [AllureFeature("Login")]
        [AllureSeverity(SeverityLevel.normal)]
        public void InvalidLoginTest()
        {
            loginPage.Login("invalid_user", "wrong_password");

            var errorMessage = _driver.FindElement(By.CssSelector(".error-message-container")).Text;
            Assert.That(errorMessage, Does.Contain("Epic sadface"));
        }
    }
}
