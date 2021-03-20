using SeleniumAutomation.PageObjects;
using Xunit;
using FluentAssertions;
using System.Linq;
using OpenQA.Selenium;

namespace SeleniumAutomation
{
    public class HomeTest
    {
        private HomePageObject homePageObject;

        public HomeTest()
        {
            this.homePageObject = new HomePageObject();
        }

        [Fact]
        public void HomePage_Deve_Exibir_Carros_Corretamente() 
        {
            this.homePageObject.Navegate();

            var elements = this.homePageObject.GetHomeElements();

            elements.Should().HaveCountGreaterThan(0);

            foreach (var item in elements)
            {
                //TESTA SE TEM IMAGEM
                var imgElement = item.FindElement(By.ClassName("img-responsive"));
                imgElement.GetAttribute("src").Should().NotBeNullOrEmpty();

                // Testa se tem link para pagina de detalhe
                var anchorElement = item.FindElement(By.XPath("*//div[@class='caption']//h3//a"));
                anchorElement.Should().NotBeNull();
                anchorElement.GetAttribute("href").Should().NotBeNullOrEmpty();
                anchorElement.Text.Should().NotBeNullOrEmpty();
            }

            this.homePageObject.Close();
        }

    }
}