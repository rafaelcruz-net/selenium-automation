using FluentAssertions;
using OpenQA.Selenium;
using SeleniumAutomation.PageObjects;
using Xunit;

namespace SeleniumAutomation
{
    public class GalleryTest
    {
        private GalleryPageObject galleryPageObject;

        public GalleryTest()
        {
            
        }

        [Theory]
        [InlineData("All Cars")]
        public void Gallery_Deve_Apresentar_Carro_Por_Fabricante(string fabricante)
        {
            this.galleryPageObject = new GalleryPageObject();

            this.galleryPageObject.Navegate(fabricante);

            var element = this.galleryPageObject.GetPageTitle();
            element.Should().NotBeNull();

            var h1Element = element.FindElement(By.XPath("h1"));
            h1Element.Should().NotBeNull();
            h1Element.Text.ToUpper().Should().NotBeNullOrEmpty().And.Be(fabricante.ToUpper());

            var carElements = this.galleryPageObject.GetPageElements();

            carElements.Should().HaveCountGreaterThan(0);

            foreach (var item in carElements)
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

            this.galleryPageObject.Close();
        }

    }
    
}