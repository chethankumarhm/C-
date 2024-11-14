using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Selenium.PageObjects;
using System.Security.Cryptography.X509Certificates;

namespace Selenium
{
    public class Tests
    {
       private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
        }

        [Test]
        [TestCase("chethan@gmail.com", "12345")]
        [TestCase("chethan.com", "11111")]
        public void Test1(string email,string password)
        {
            //Launch chrome browser and navigate to url
              
                _driver.FindElement(By.XPath("//input[@id='small-searchterms']")).Click();
                _driver.FindElement(By.XPath("//input[@id='small-searchterms']")).SendKeys("Books");
                IWebElement Apparel= _driver.FindElement(By.XPath("(//a[contains(text(),'Apparel & Shoes')])[1]"));

            //Actions class
            Actions action = new Actions(_driver);
            action.MoveToElement(Apparel).Build().Perform();

                _driver.FindElement(By.XPath("(//a[contains(text(),'Apparel & Shoes')])[1]")).Click();
                IWebElement element= _driver.FindElement(By.XPath("//select[@id='products-orderby']"));

            //Select class
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByIndex(2);

            ////Click and enter using Helper methods
            //HelperMethods.clickOnElement(driver,By.XPath("//input[@id='small-searchterms']"));
            //HelperMethods.enterIntoTextfield(driver, By.XPath("//input[@id='small-searchterms']"),"Done");

            ////Select dropdown using Helper methods
            //HelperMethods.selectDropdownByText(driver, By.XPath("//select[@id='products-orderby']"), "Price: Low to High");


            //Login to demo web shop using methods in POM page (Original simplified code)
            LoginPage page = new LoginPage(_driver);
            page.clickLogin();
            page.Login(email, password);
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Hai");
            Programs.print();
            _driver.Quit();
        }
    }
}