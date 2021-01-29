using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TesteUnidade.PageObject.Cliente
{
    class CadastroCliente
    {
        private readonly RemoteWebDriver _driver;

        public CadastroCliente(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Nome => _driver.FindElementById("nome");
        public IWebElement Cpf => _driver.FindElementById("cpf");
        public IWebElement Rg => _driver.FindElementById("rg");
        public IWebElement Cnh => _driver.FindElementById("cnh");
        public IWebElement Nascimento => _driver.FindElementById("data-nascimento");
        public IWebElement Empresa => _driver.FindElementByLinkText("Selecionar Empresa");
        public IWebElement SelecaoEmpresa => _driver.FindElementByLinkText("");
        public IWebElement Situacao => _driver.FindElementByLinkText("Selecionar Situação");
        public IWebElement SelecaoSituacao => _driver.FindElementByLinkText("Selecionar Situação");
        public IWebElement Avancar => _driver.FindElementById("submit-cliente");
    }
}