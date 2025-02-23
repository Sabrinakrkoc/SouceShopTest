using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SauceDemoShop.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement CheckoutButton => _wait.Until(d => d.FindElement(By.Id("checkout")));
        private IWebElement FirstNameField => _wait.Until(d => d.FindElement(By.Id("first-name")));
        private IWebElement LastNameField => _wait.Until(d => d.FindElement(By.Id("last-name")));
        private IWebElement PostalCodeField => _wait.Until(d => d.FindElement(By.Id("postal-code")));
        private IWebElement ContinueButton => _wait.Until(d => d.FindElement(By.Id("continue")));
        private IList<IWebElement> ItemPrices => _wait.Until(d => d.FindElements(By.CssSelector(".inventory_item_price")));
        private IWebElement ItemTotal => _wait.Until(d => d.FindElement(By.CssSelector(".summary_subtotal_label")));
        private IWebElement TaxTotal => _wait.Until(d => d.FindElement(By.CssSelector(".summary_tax_label")));
        private IWebElement FinishButton => _wait.Until(d => d.FindElement(By.Id("finish")));
        private IWebElement ConfirmationMessage => _wait.Until(d => d.FindElement(By.CssSelector(".complete-header")));
        private IWebElement ErrorMessage => _wait.Until(d => d.FindElement(By.CssSelector(".error-message-container")));

        public void StartCheckout()
        {
            CheckoutButton.Click();
        }

        public void EnterCheckoutInformation(string firstName, string lastName, string postalCode)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            PostalCodeField.SendKeys(postalCode);
            ContinueButton.Click();
        }

        public List<decimal> GetItemPrices()
        {
            return ItemPrices.Select(priceElement => decimal.Parse(priceElement.Text.Replace("$", ""))).ToList();
        }

        public decimal GetItemTotal()
        {
            return decimal.Parse(ItemTotal.Text.Replace("Item total: $", ""));
        }

        public decimal GetTaxTotal()
        {
            return decimal.Parse(TaxTotal.Text.Replace("Tax: $", ""));
        }

        public void FinishCheckout()
        {
            FinishButton.Click();
        }

        public string GetConfirmationMessage()
        {
            return ConfirmationMessage.Text;
        }

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }
    }
}
