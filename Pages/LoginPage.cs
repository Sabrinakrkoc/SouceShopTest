using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SauceDemoShop.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Localizadores
        private IWebElement UsernameField => _wait.Until(d => d.FindElement(By.Id("user-name")));
        private IWebElement PasswordField => _wait.Until(d => d.FindElement(By.Id("password")));
        private IWebElement LoginButton => _wait.Until(d => d.FindElement(By.Id("login-button")));

        // Método de Login
        public void Login(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }
    }
}
