using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using TesteUnidade.PageObject.Login;

namespace Login
{
    [TestFixture]
    public class CTLogin
    {
        public RemoteWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");

            driver = new ChromeDriver(/*options*/); 
        }

        [TearDown]
        protected void TearDown()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }

        [Test]
        public void Acesso()
        {
            var pagina = new LoginPage(driver);
            driver.Navigate().GoToUrl("https://beta.jns.net.br/");

            pagina.Cpf.SendKeys("138.020.536-05");
            pagina.Senha.SendKeys("102030");
            pagina.EfetuarLogin();
        }
    }
}