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

        private IWebElement MenuButton => _wait.Until(d => d.FindElement(By.Id("react-burger-menu-btn")));
        private IWebElement LogoutButton => _wait.Until(d => d.FindElement(By.Id("logout_sidebar_link")));

        public void ClickOnMenuButton()
        {
            try
            {
                _wait.Until(d => MenuButton.Displayed);  
                MenuButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("The menu button was not available within the expected time.");
            }
        }

        public void ClickOnLogoutButton()
        {
            try
            {
                _wait.Until(d => LogoutButton.Displayed);
                LogoutButton.Click();
            }
            catch (WebDriverTimeoutException)
            {
                throw new Exception("The logout button was not available within the expected time.");
            }
        }
    }
}
