using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using TesteUnidade.PageObject.Rastrear;

namespace Rastreamento.Testes
{
    [TestFixture]
    class Veiculo
    {
        public RemoteWebDriver driver;
        private Login login;

        public IDictionary<string, object> Vars { get; private set; }
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

        public string WaitForWindow(int timeout)
        {
            try
            {
                Thread.Sleep(timeout);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

            var whNow = ((IReadOnlyCollection<object>)driver.WindowHandles).ToList();
            var whThen = ((IReadOnlyCollection<object>)Vars["WindowHandles"]).ToList();

            if (whNow.Count > whThen.Count)
                return whNow.Except(whThen).First().ToString();

            return whNow.First().ToString();
        }

        [Test]
        public void BuscarVeiculo()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.LinkText("Veículo")).Displayed);

            driver.FindElementByLinkText("Veículo").Click();
            driver.FindElementByLinkText("Rastrear").Click();

            var pagina = new Rastrear(driver);
            wait.Until(driver => pagina.BuscarVeiculo.Displayed);
            Thread.Sleep(500);
            pagina.BuscarVeiculo.Click();
            wait.Until(driver => pagina.Empresa.Displayed);
            pagina.Empresa.Click();
            pagina.Empresa.FindElement(By.XPath("//input[@type='search']")).SendKeys("jn" + Keys.Enter);
            wait.Until(driver => pagina.Veiculo.Displayed);
            pagina.Veiculo.Click();
            pagina.Veiculo.FindElement(By.XPath("//input[@type='search']")).SendKeys("br" + Keys.Enter);
            wait.Until(driver => pagina.ConfirmarLocalizacao.Displayed);
            pagina.ConfirmarLocalizacao.Click();
            wait.Until(driver => pagina.PopUp.Displayed);
            Thread.Sleep(500);
            pagina.PopUp.Click();
        }

        [Test]
        public void BuscarTrajeto()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(By.LinkText("Veículo")).Displayed);

            driver.FindElementByLinkText("Veículo").Click();
            driver.FindElementByLinkText("Rastrear").Click();

            var pagina = new Rastrear(driver);
            wait.Until(driver => pagina.BuscarTrajeto.Displayed);
            pagina.BuscarTrajeto.Click();
            wait.Until(driver => pagina.Empresa.Displayed);
            pagina.Empresa.Click();
            pagina.Empresa.FindElement(By.XPath("//input[@type='search']")).SendKeys("jn" + Keys.Enter);
            wait.Until(driver => pagina.Veiculo.Displayed);
            pagina.Veiculo.Click();
            pagina.Veiculo.FindElement(By.XPath("//input[@type='search']")).SendKeys("br" + Keys.Enter);
            wait.Until(driver => pagina.Trajeto.Displayed);
            pagina.Trajeto.Click();
            pagina.Trajeto.FindElement(By.XPath("//input[@type='search']")).SendKeys(Keys.Down + Keys.Enter);
            wait.Until(driver => driver.FindElement(By.Id("submit-trajeto")).Displayed);
            pagina.ConfirmarTrajeto.Click();           
        }

        [Test]
        public void Listar()
        {
            Login.Cpf = "138.020.536-05";
            Login.Senha = "102030";

            login.SetUp();
            login.Acesso();
            driver = login.driver;

            driver.FindElement(By.Id("dropdown-veiculo")).Click();
            driver.FindElement(By.LinkText("Listar")).Click();
            driver.FindElement(By.Name("tabela-veiculo_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-veiculo_length"));
                dropdown.FindElement(By.XPath("//option[. = '50']")).Click();
            }
            driver.FindElement(By.Name("tabela-veiculo_length")).Click();
            driver.FindElement(By.Name("tabela-veiculo_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-veiculo_length"));
                dropdown.FindElement(By.XPath("//option[. = '75']")).Click();
            }
            driver.FindElement(By.Name("tabela-veiculo_length")).Click();
            driver.FindElement(By.Name("tabela-veiculo_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-veiculo_length"));
                dropdown.FindElement(By.XPath("//option[. = '100']")).Click();
            }
            driver.FindElement(By.Name("tabela-veiculo_length")).Click();
            driver.FindElement(By.Name("tabela-veiculo_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-veiculo_length"));
                dropdown.FindElement(By.XPath("//option[. = '25']")).Click();
            }
            driver.FindElement(By.Name("tabela-veiculo_length")).Click();
            driver.FindElement(By.CssSelector(".buttons-copy > span")).Click();
            driver.FindElement(By.CssSelector(".buttons-excel > span")).Click();
            driver.FindElement(By.CssSelector(".buttons-print > span")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.FindElement(By.CssSelector(".buttons-pdf")).Click();
            driver.FindElement(By.CssSelector("#tabela-veiculo_filter .form-control")).SendKeys("AAA000" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-veiculo_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-veiculo_filter .form-control")).SendKeys("KRH8A40" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-veiculo_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-veiculo_filter .form-control")).SendKeys("KRH8A40" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-veiculo_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-veiculo_filter .form-control")).SendKeys("FIESTA" + Keys.Enter);
            driver.FindElement(By.CssSelector(".btn-block > .btn-outline-info:nth-child(1)")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.CssSelector("#modal-detalhamento span")).Displayed);
            driver.FindElement(By.CssSelector("#modal-detalhamento span")).Click();
            driver.FindElement(By.CssSelector(".btn-block > .btn-outline-info:nth-child(2)")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }
    }
}