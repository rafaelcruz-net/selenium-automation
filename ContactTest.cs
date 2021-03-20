using FluentAssertions;
using OpenQA.Selenium;
using SeleniumAutomation.PageObjects;
using Xunit;

namespace SeleniumAutomation
{
    public class ContactTest
    {
        private ContactPageObject contactPageObject;

        public ContactTest()
        {
            this.contactPageObject = new ContactPageObject();
        }

        //[Fact]
        public void Contact_Deve_Enviar_Formulario_Com_Sucesso()
        {
            this.contactPageObject.Navegate();

            this.contactPageObject.FillText("Name", "Rafael Cruz");
            this.contactPageObject.FillText("Email", "rafaelcruz.net81@gmail.com");
            this.contactPageObject.FillText("Message", "Lorem ipsum Lorem Ipsum");

            this.contactPageObject.SubmitForm();

            var element = this.contactPageObject.GetSuccessElement();

            element.Should().NotBeNull();
            element.Displayed.Should().BeTrue();

            this.contactPageObject.Close();
        }

        [Fact]
        public void Contact_Deve_Validar_Formulario_Corretamente()
        {
            this.contactPageObject.Navegate();

            this.contactPageObject.FillText("Name", "");
            this.contactPageObject.FillText("Email", "");
            this.contactPageObject.FillText("Message", "");
            
            this.contactPageObject.SubmitForm();

            var errors = this.contactPageObject.GetErrorsElement();

            errors.Should().NotBeNull();

            var childErrors = errors.FindElements(By.XPath("ul/li"));

            childErrors.Should().NotBeEmpty().And.HaveCount(3);

            foreach (var item in childErrors)
                item.Text.Should().NotBeNullOrWhiteSpace().And.Contain("é obrigatório");

            this.contactPageObject.Close();
        }

    }
    
}