using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using TesteUnidade.PageObject.Cliente;

namespace Rastreamento.Testes
{
    [TestFixture]
    class Cliente
    {
        public RemoteWebDriver driver;
        private Login login;

        private Stopwatch watch;

        [SetUp]
        public void SetUp()
        {
            login = new Login();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Cadastro()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.LinkText("Cliente")));

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            new Lista(driver).CadastrarCliente();
            var pagina = new Cadastro(driver);

            driver.SwitchTo().Window(driver.WindowHandles[1]);
            pagina.Nome.SendKeys("Nome de cliente");
            pagina.Cpf.SendKeys("680.473.220-01");
            pagina.Rg.SendKeys("000000000");
            pagina.Cnh.SendKeys("00000000000");
            pagina.Nascimento.SendKeys("01011000");
        }

        [Test]
        public void Detalhamento()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.LinkText("Cliente")).Displayed);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new Lista(driver);
            pagina.ExibirModal();
            wait.Until(driver => driver.FindElement(By.Id("modal-detalhamento")).Displayed);
        }

        [Test]
        public void Gerenciar()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.LinkText("Cliente")).Displayed);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new Lista(driver);
            pagina.EditarCliente();
        }

        [Test]
        public void Observacao()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.LinkText("Cliente")).Displayed);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new Lista(driver);
            pagina.ObservacaoCliente();
        }

        [Test]
        public void PesquisarLista()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.LinkText("Cliente")).Displayed);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new Lista(driver);
            pagina.BuscarRegistro("Admin");
        }

        [Test]
        public void RegistrosLista()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.LinkText("Cliente")).Displayed);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new Lista(driver);
            pagina.AlterarRegistrosPagina("5");
            pagina.AlterarRegistrosPagina("7");
            pagina.AlterarRegistrosPagina("1");
            pagina.AlterarRegistrosPagina("2");
        }

        [Test]
        public void Relatorio()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.LinkText("Cliente")).Displayed);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new Lista(driver);
            pagina.Copiar.Click();
            pagina.Exportar.Click();
            pagina.Imprimir.Click();
            pagina.Salvar.Click();
        }

        [Test]
        public void Remover()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.LinkText("Cliente")).Displayed);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new Lista(driver);
            pagina.RemoverCliente(driver);
        }

        [Test]
        public void Listar()
        {
            try
            {
                login.SetUp();
                login.Acesso();
                driver = login.driver;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => driver.FindElement(By.LinkText("Cliente")).Displayed);

                driver.FindElementByLinkText("Cliente").Click();
                driver.FindElementByLinkText("Listar").Click();
                wait.Until(driver => driver.FindElement(By.CssSelector(".table-hover")));
            }
            catch (NoSuchElementException erro)
            {
                Console.WriteLine(erro);
                throw erro;
            }
        }
    }
}