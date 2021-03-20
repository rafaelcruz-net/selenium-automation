using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumAutomation.PageObjects
{
    public abstract class BasePageObject 
    {
        public IWebDriver Driver { get; set; }
        private const string BaseUrl = "http://40.122.166.241";

        public BasePageObject()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            chromeOptions.AddArguments("incognito");
            chromeOptions.AddArguments("disable-web-security");
            var service = ChromeDriverService.CreateDefaultService();
            this.Driver = new ChromeDriver(service:service, options: chromeOptions);


            // var firefoxOptions = new FirefoxOptions();
            // firefoxOptions.AddArguments("headless");
            // this.Driver = new FirefoxDriver(firefoxOptions);
            
        }

        public void Navegate(string path)
        {
            this.Driver.Url = $"{BaseUrl}{path}";
            this.Driver.Navigate();
        }

        public void Close() 
        {
            this.Driver.Quit();
        }

        public IList<IWebElement> GetElementsByCssClass(string @class) =>
            this.Driver.FindElements(By.ClassName(@class));

        public IList<IWebElement> GetElementsByCssSelector(string cssSelector) =>
            this.Driver.FindElements(By.CssSelector(cssSelector));

        public IWebElement GetElementByCssClass(string @class) =>
            this.Driver.FindElement(By.ClassName(@class));

        public IWebElement GetElementById(string id) =>
            this.Driver.FindElement(By.Id(id));

    }
    
}