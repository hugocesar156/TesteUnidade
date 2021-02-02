using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using TesteUnidade.PageObject.Login;

namespace Rastreamento.Testes
{
    [TestFixture]
    public class Login
    {
        public RemoteWebDriver driver;
        public Stopwatch watch;

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
            driver.Quit();
        }

        [Test]
        public void Acesso()
        {
            try
            {
                watch = Stopwatch.StartNew();

                var pagina = new Acesso(driver);
                driver.Navigate().GoToUrl("https://beta.jns.net.br/");

                pagina.Cpf.SendKeys("138.020.536-05");
                pagina.Senha.SendKeys("102030");
                pagina.EfetuarLogin();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(driver => driver.FindElement(By.CssSelector(".card-header")));

                watch.Stop();
                Console.WriteLine($"Tempo de execução: {watch.ElapsedMilliseconds/1000} segundos");
            }
            catch (NoSuchElementException erro)
            {
                watch.Stop();

                Console.WriteLine($"Mensagem de erro: {erro.Message}\nTempo de execução: " +
                    $"{watch.ElapsedMilliseconds/1000} segundos");
                throw erro;
            }
        }
    }
}