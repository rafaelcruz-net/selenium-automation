using System.Collections.Generic;
using OpenQA.Selenium;

namespace SeleniumAutomation.PageObjects
{
    public class GalleryPageObject : BasePageObject
    {
        private const string URL = "/Car";
        
        public new void Navegate(string search) 
        {
            base.Navegate(URL);
        }

        public IWebElement GetPageTitle() =>
            base.GetElementByCssClass("pb-3");

        public IList<IWebElement> GetPageElements() => base.GetElementsByCssSelector(".row > .col-lg-6");



    }
    
}