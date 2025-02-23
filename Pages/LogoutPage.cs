using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SauceDemoShop.Pages
{
    public class LogoutPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LogoutPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Localizadores de los elementos
        private IWebElement MenuButton => _wait.Until(d => d.FindElement(By.Id("react-burger-menu-btn")));
        private IWebElement LogoutButton => _wait.Until(d => d.FindElement(By.Id("logout_sidebar_link")));

        // Método para hacer clic en el botón del menú
        public void ClickOnMenuButton()
        {
            try
            {
                _wait.Until(d => MenuButton.Displayed);  // Esperar a que el botón esté visible
                MenuButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("El botón de menú no estuvo disponible dentro del tiempo esperado.");
            }
        }

        // Método para hacer clic en el botón de logout
        public void ClickOnLogoutButton()
        {
            try
            {
                _wait.Until(d => LogoutButton.Displayed);  // Esperar a que el botón esté visible
                LogoutButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("El botón de logout no estuvo disponible dentro del tiempo esperado.");
            }
        }
    }
}
