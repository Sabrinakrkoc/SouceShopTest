using Allure.NUnit;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using SauceDemoShop.Base;
using SauceDemoShop.Pages;

namespace SauceDemoShop.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class LogoutTests : BaseTest
    {
        private LoginPage loginPage;
        private ProductPage productPage;
        private LogoutPage logoutPage;

        [SetUp]
        public void BeforeTest()
        {
            loginPage = new LoginPage(_driver);
            productPage = new ProductPage(_driver);
            logoutPage = new LogoutPage(_driver);
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test]
        [AllureFeature("Logout")]
        public void LogoutTest()
        {
            logoutPage.ClickOnMenuButton();  
            logoutPage.ClickOnLogoutButton(); 

            Assert.That(_driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }
    }
}
