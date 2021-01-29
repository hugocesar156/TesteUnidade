using Login;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TesteUnidade.PageObject.Cliente;

namespace Cliente
{
    [TestFixture]
    class CTCliente
    {
        public RemoteWebDriver driver;
        private CTLogin login;

        [SetUp]
        public void SetUp()
        {
            login = new CTLogin();
        }

        [TearDown]
        protected void TearDown()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }

        [Test]
        public void Cadastro()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            Thread.Sleep(5000);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            new ListaClientePage(driver).CadastrarCliente();
            var pagina = new CadastroCliente(driver);

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
            Thread.Sleep(5000);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new ListaClientePage(driver);
            pagina.ExibirModal();
            Thread.Sleep(2000);

            Assert.IsTrue(driver.FindElementById("modal-detalhamento").Displayed);
        }

        [Test]
        public void Gerenciar()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            Thread.Sleep(5000);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new ListaClientePage(driver);
            pagina.EditarCliente();
        }

        [Test]
        public void Observacao()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            Thread.Sleep(5000);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new ListaClientePage(driver);
            pagina.ObservacaoCliente();
        }

        [Test]
        public void PesquisarLista()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            Thread.Sleep(5000);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new ListaClientePage(driver);
            pagina.BuscarRegistro("Admin");
        }

        [Test]
        public void RegistrosLista()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            Thread.Sleep(5000);
            
            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new ListaClientePage(driver);
            pagina.AlterarRegistrosPagina("5");
            Thread.Sleep(500);

            pagina.AlterarRegistrosPagina("7");
            Thread.Sleep(500);

            pagina.AlterarRegistrosPagina("1");
            Thread.Sleep(500);

            pagina.AlterarRegistrosPagina("2");
            Thread.Sleep(500);
        }

        [Test]
        public void Relatorio()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            Thread.Sleep(5000);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new ListaClientePage(driver);
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
            Thread.Sleep(5000);

            driver.FindElementByLinkText("Cliente").Click();
            driver.FindElementByLinkText("Listar").Click();

            var pagina = new ListaClientePage(driver);
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
                Thread.Sleep(5000);

                driver.FindElementByLinkText("Cliente").Click();
                driver.FindElementByLinkText("Listar").Click();

                var watch = Stopwatch.StartNew();
            }
            catch (NoSuchElementException erro)
            {
                Console.WriteLine(erro);
            }
            catch (AssertionException erro)
            {
                Console.WriteLine(erro);
            }
        }
    }
}