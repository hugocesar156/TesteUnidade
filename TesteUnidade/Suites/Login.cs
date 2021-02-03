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

        public static string Cpf = "138.020.536-05";
        public static string Senha = "102030";

        [SetUp]
        public void SetUp()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");

            driver = new ChromeDriver(); 
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
                var pagina = new Acesso(driver);
                driver.Navigate().GoToUrl("https://beta.jns.net.br/");

                pagina.Cpf.SendKeys(Cpf);
                pagina.Senha.SendKeys(Senha);
                pagina.EfetuarLogin();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(driver => driver.FindElement(By.CssSelector(".card-header")));
            }
            catch (NoSuchElementException erro)
            {
                Console.WriteLine($"Mensagem de erro: {erro.Message}\nTempo de execução: " +
                    $"{watch.ElapsedMilliseconds/1000} segundos");
                throw erro;
            }
        }
    }
}