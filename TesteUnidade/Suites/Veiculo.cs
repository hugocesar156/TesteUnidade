using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TesteUnidade.PageObject.Rastrear;

namespace Rastreamento.Testes
{
    [TestFixture]
    class Veiculo
    {
        public RemoteWebDriver driver;
        private Login login;

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
    }
}