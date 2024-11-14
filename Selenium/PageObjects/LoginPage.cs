using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver) {
            this.driver = driver;
        }

        //------------------ Login Page Elements ------------------
        IWebElement LogInLink => driver.FindElement(By.XPath("//a[text()='Log in']"));
        IWebElement email => driver.FindElement(By.XPath("//input[@id='Email']"));
        IWebElement password => driver.FindElement(By.XPath("//input[@id='Password']"));
        IWebElement LogInButton => driver.FindElement(By.XPath("(//input[@type='submit'])[2]"));


        //-------------------- METHODS---------------------
        // Here we call the Helper/Custom methods from Helper methods class and for methods, required
        // webelement is passed as a parameter in POM page, call this method in script and use it.
        public void clickLogin()
        {
            HelperMethods.clickOnElement(LogInLink);
            HelperMethods.enterIntoTextfield(password, "123");
        }


        // Final optimization is done , by removing HelperMethods class while calling methods as mentioned above by adding 
        // by adding this keyword along with IWebElement as parameter in Helper methods as shown below.
        public void Login(string Email, string Password)
        {
            email.enterIntoTextfield(Email); //IWebElement.HelperMethods(string)
            password.enterIntoTextfield(Password);
            LogInButton.clickOnElement();
        }
    }
}
