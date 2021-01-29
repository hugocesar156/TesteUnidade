using Login;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
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
            Thread.Sleep(3000);
            driver.Quit();
        }

        [Test]
        public void BuscarVeiculo()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            Thread.Sleep(5000);

            driver.FindElementByLinkText("Veículo").Click();
            driver.FindElementByLinkText("Rastrear").Click();

            var pagina = new MapaPage(driver);
            Thread.Sleep(500);
            pagina.BuscarVeiculo.Click();
            Thread.Sleep(1000);
            pagina.AreaEmpresa.Click();
            pagina.CampoEmpresa.SendKeys("jn" + Keys.Enter);
            Thread.Sleep(1000);
            pagina.AreaVeiculo.Click();
            pagina.CampoVeiculo.SendKeys("br" + Keys.Enter);
            Thread.Sleep(2000);
            pagina.ConfirmarLocalizacao.Click();
            Thread.Sleep(5000);
            pagina.PopUp.Click();
        }

        [Test]
        public void BuscarTrajeto()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            Thread.Sleep(5000);

            driver.FindElementByLinkText("Veículo").Click();
            driver.FindElementByLinkText("Rastrear").Click();

            var pagina = new MapaPage(driver);
            Thread.Sleep(500);
            pagina.BuscarTrajeto.Click();
            Thread.Sleep(1000);
            pagina.AreaEmpresa.Click();
            pagina.CampoEmpresa.SendKeys("jn" + Keys.Enter);
            Thread.Sleep(1000);
            pagina.AreaVeiculo.Click();
            pagina.CampoVeiculo.SendKeys("br" + Keys.Enter);
            Thread.Sleep(4000);
            pagina.AreaTrajeto.Click();
            pagina.CampoTrajeto.SendKeys(Keys.Down + Keys.Enter);
            pagina.ConfirmarTrajeto.Click();
            Thread.Sleep(10000);
        }
    }
}