using Login;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TesteUnidade.PageObject.Rastrear;

namespace Rastrear
{
    [TestFixture]
    class CTRastrear
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
            driver.Quit();
        }

        [Test]
        public void BuscarVeiculo()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElements(By.LinkText("Veículo")).Count > 0);

            driver.FindElementByLinkText("Veículo").Click();
            driver.FindElementByLinkText("Rastrear").Click();

            var pagina = new MapaPage(driver);
            wait.Until(driver => pagina.BuscarVeiculo.Enabled);
            pagina.BuscarVeiculo.Click();
            wait.Until(driver => pagina.Empresa.Enabled);
            pagina.Empresa.Click();
            pagina.Empresa.FindElement(By.XPath("//input[@type='search']")).SendKeys("jn" + Keys.Enter);
            wait.Until(driver => pagina.Veiculo.Enabled);
            pagina.Veiculo.Click();
            pagina.Veiculo.FindElement(By.XPath("//input[@type='search']")).SendKeys("br" + Keys.Enter);
            wait.Until(driver => pagina.ConfirmarLocalizacao.Enabled);
            pagina.ConfirmarLocalizacao.Click();
            wait.Until(driver => pagina.PopUp.Enabled);
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
            wait.Until(driver => driver.FindElements(By.LinkText("Veículo")).Count > 0);

            driver.FindElementByLinkText("Veículo").Click();
            driver.FindElementByLinkText("Rastrear").Click();

            var pagina = new MapaPage(driver);
            wait.Until(driver => pagina.BuscarTrajeto.Enabled);
            pagina.BuscarTrajeto.Click();
            wait.Until(driver => pagina.Empresa.Enabled);
            pagina.Empresa.Click();
            pagina.Empresa.FindElement(By.XPath("//input[@type='search']")).SendKeys("jn" + Keys.Enter);
            wait.Until(driver => pagina.Veiculo.Enabled);
            pagina.Veiculo.Click();
            pagina.Veiculo.FindElement(By.XPath("//input[@type='search']")).SendKeys("br" + Keys.Enter);
            wait.Until(driver => pagina.Trajeto.Enabled);
            pagina.Trajeto.Click();
            pagina.Trajeto.FindElement(By.XPath("//input[@type='search']")).SendKeys(Keys.Down + Keys.Enter);
            wait.Until(driver => driver.FindElement(By.Id("submit-trajeto")).Enabled);
            pagina.ConfirmarTrajeto.Click();           
        }
    }
}