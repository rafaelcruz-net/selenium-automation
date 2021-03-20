using System;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumAutomation.PageObjects
{
    public class ContactPageObject : BasePageObject
    {
        private const string URL = "/Contact";
        private const int Timeout = 5000;

        public void Navegate()
        {
            base.Navegate(URL);
        }

        public void SubmitForm() 
        {
            var element = base.GetElementsByCssSelector(".btn-primary")
                              .FirstOrDefault();
            element.Submit();
        }

        public void FillText(string id, string value) 
        {
            var element =  base.GetElementById(id);
            element.SendKeys(value);
        }

        public IWebElement GetSuccessElement()
        {
            var element = new WebDriverWait(this.Driver, TimeSpan.FromMilliseconds(Timeout))
                                        .Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".alert-success")));

            return element;
        }

        public IWebElement GetErrorsElement()
        {
            var element = new WebDriverWait(this.Driver, TimeSpan.FromMilliseconds(Timeout))
                                        .Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".validation-summary-errors")));

            return element;
        }

    }

}