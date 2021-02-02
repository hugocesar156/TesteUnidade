using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TesteUnidade.PageObject.Cliente
{
    class Lista
    {
        private readonly RemoteWebDriver _driver;

        public Lista(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Novo => _driver.FindElementByClassName("btn-success");
        public IWebElement Buscar => _driver.FindElementByCssSelector("#tabela-cliente_filter .form-control");
        public IWebElement Detalhamento => _driver.FindElementByClassName("fa-info-circle");
        public IWebElement Observacao => _driver.FindElementByClassName("fa-comment");
        public IWebElement Gerenciamento => _driver.FindElementByClassName("fa-pen");
        public IWebElement Remover => _driver.FindElementByClassName("fa-times");
        public IWebElement Copiar => _driver.FindElementByClassName("buttons-copy");
        public IWebElement Exportar => _driver.FindElementByClassName("buttons-excel");
        public IWebElement Imprimir => _driver.FindElementByClassName("buttons-print");
        public IWebElement Salvar => _driver.FindElementByClassName("buttons-pdf");
        public IWebElement Exibir => _driver.FindElementByName("tabela-cliente_length");
        public IWebElement Filtrar => _driver.FindElementByLinkText("Filtrar lista");

        public void AlterarRegistrosPagina(string valor) => Exibir.SendKeys(valor);

        public void BuscarRegistro(string pesquisa) => Buscar.SendKeys(pesquisa);

        public void EditarCliente() => Gerenciamento.Click();

        public void ExibirModal() => Detalhamento.Click();

        public void CadastrarCliente() => Novo.Click();

        public void ObservacaoCliente() => Observacao.Click();

        public void RemoverCliente(IWebDriver driver)
        {
            Remover.Click();
            driver.FindElement(By.Id("submit-inativacao")).Click();
        }
    }
}