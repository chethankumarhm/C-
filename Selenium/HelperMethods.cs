using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    public static class HelperMethods
    {
        //Click on element
        public static void clickOnElement(this IWebElement locator)
        {
            locator.Click();
        }

        //Enter input into textfield
        public static void enterIntoTextfield(this IWebElement locator,string value)
        {
            locator.Click();
            locator.Clear();
            locator.SendKeys(value);
        }

        //Select dropdown select tag using Text
        public static void selectDropdownByText(this IWebElement locator, string Text)
        {
            SelectElement element = new SelectElement(locator);
            element.SelectByText(Text);
        }


        //Below mentioned method is optimized to above mentioned method "(IWebDriver driver, By locator) not required"
        //public static void Value(IWebDriver driver, By locator, string Value)
        //{
        //    SelectElement element = new SelectElement(driver.FindElement(locator));
        //    element.SelectByText(Value);
        //}



    }
}
