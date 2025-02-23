using NUnit.Framework;
using SauceDemoShop.Pages;
using Microsoft.Extensions.Configuration;
using System.IO;
using Allure.NUnit.Attributes;
using Allure.NUnit;
using SauceDemoShop.Base;

namespace SauceDemoShop.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class LogoutTests : BaseTest
    {
        private LoginPage loginPage;
        private ProductPage productPage;
        private LogoutPage logoutPage;
        private IConfiguration _configuration;

        [SetUp]
        public void BeforeTest()
        {
            // Cargar la configuración para Allure, ahora considerando que está en la carpeta Resources
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  // Ruta base donde se encuentra el archivo .dll o ejecutable
                .AddJsonFile("Resources/appsettings.json", optional: false, reloadOnChange: true)  // Ajuste aquí
                .Build();

            loginPage = new LoginPage(_driver);
            productPage = new ProductPage(_driver);
            logoutPage = new LogoutPage(_driver);
            loginPage.Login("standard_user", "secret_sauce");
        }

        [Test]
        [AllureFeature("Logout")]
        public void LogoutTest()
        {
            // Hacer clic en el botón de logout usando LogoutPage
            logoutPage.ClickOnMenuButton();  // Abrir el menú
            logoutPage.ClickOnLogoutButton(); // Hacer logout

            // Verificar que la URL haya cambiado correctamente
            Assert.That(_driver.Url, Is.EqualTo("https://www.saucedemo.com/"));

            // Puedes obtener la ruta de los resultados de Allure desde la configuración
            string allureResultsDir = _configuration["AppSettings:AllureResultsDirectory"];
            Console.WriteLine("Allure Results Directory: " + allureResultsDir);  // Aquí puedes hacer lo que necesites con esta ruta
        }
    }
}
