##SauceDemoShop##
This is an automation testing project for the Sauce Demo Shop web application using Selenium and NUnit in C#. The goal of this project is to test key functionalities of the web application such as login, adding products to the cart, performing checkout, and logout.

#Technologies Used
Selenium WebDriver: A tool for automating browser navigation and interactions.
NUnit: A testing framework for .NET.
Allure: A tool for generating visual test reports.
Git: A version control system for managing source code.

#Project Structure
/SauceDemoShop
  /Base               # Base class for the tests
  /Drivers            # Browser drivers
  /Pages              # Application pages (Page Object Model)
  /Reports            # Generated test reports
  /Tests              # Automated tests
  /Utils              # Common utilities (e.g., configuration reading)
  appsettings.json    # Environment configuration
  README.md           # This file

#Setup
-Install Dependencies: Make sure you have .NET and Selenium WebDriver installed in your environment. Use the following command to restore project dependencies:
dotnet restore

-Configuration Files:
appsettings.json: This file contains basic configuration for the base URL of the application and other necessary settings for the tests.
Example content:
{
  "AppSettings": {
    "BaseUrl": "https://www.saucedemo.com/",
    "AllureResultsDirectory": "allure-results"
  }
}

#Running Tests
To run the Selenium tests with NUnit, open a terminal in the root of the project and execute:
dotnet test
This will run all the tests defined in the project.

#Generating Reports
To generate a visual report with Allure, first run the tests, then use the following command to generate the report:
allure serve allure-results
This command will generate an HTML report that you can view in your browser.

#Tested Functionalities
Login: Login to the application with a valid user.
Add to Cart: Add products to the shopping cart.
Checkout: Perform a checkout process with products in the cart.
Logout: Log out of the application successfully.

