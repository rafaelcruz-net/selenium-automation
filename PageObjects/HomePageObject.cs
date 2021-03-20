using System.Collections.Generic;
using OpenQA.Selenium;

namespace SeleniumAutomation.PageObjects
{
    public class HomePageObject : BasePageObject
    {
        private const string URL = "/";

        public HomePageObject()
        {

        }

        public void Navegate() 
        {
            base.Navegate(URL);
        }

        public IList<IWebElement> GetHomeElements() => base.GetElementsByCssSelector(".row > .col-lg-6");



    }
    
}