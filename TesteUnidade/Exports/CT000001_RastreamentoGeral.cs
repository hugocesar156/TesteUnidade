using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Exports
{
    [TestFixture]
    public class DefaultSuiteTest
    {
        private IWebDriver driver;
        public IDictionary<string, object> Vars { get; private set; }

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            Vars = new Dictionary<string, object>();
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
        public void Geral()
        {
            driver.Navigate().GoToUrl("https://rastreamento.jns.net.br/Login/Login?ReturnUrl=%2F");
            driver.Manage().Window.Size = new System.Drawing.Size(1616, 855);
            driver.FindElement(By.Id("emailUsuario")).Click();
            driver.FindElement(By.Id("emailUsuario")).SendKeys("gerente@web.teste");
            driver.FindElement(By.Id("senhaUsuario")).Click();
            driver.FindElement(By.Id("senhaUsuario")).SendKeys("teste$gerente");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.CssSelector(".link_mapa:nth-child(2) > .titulo-menu")).Click();
            driver.FindElement(By.Id("buscaVeiculo")).Click();
            driver.FindElement(By.Id("buscaVeiculo")).SendKeys("Bruno");
            {
                var element = driver.FindElement(By.CssSelector("#\\33 127 > span:nth-child(1)"));
                var builder = new Actions(driver);
                builder.MoveToElement(element).ClickAndHold().Perform();
            }
            {
                var element = driver.FindElement(By.CssSelector("#\\33 127 > span:nth-child(1)"));
                var builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            {
                var element = driver.FindElement(By.CssSelector("#\\33 127 > span:nth-child(1)"));
                var builder = new Actions(driver);
                builder.MoveToElement(element).Release().Perform();
            }
            Thread.Sleep(2000);
            driver.FindElement(By.CssSelector(".leaflet-marker-icon")).Click();
            Vars["WindowHandles"] = driver.WindowHandles;
            Thread.Sleep(2000);
            driver.FindElement(By.LinkText("Google Maps")).Click();
            Vars["win6973"] = WaitForWindow(2000);
            Vars["root"] = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(Vars["win6973"].ToString());
            driver.SwitchTo().Window(Vars["root"].ToString());
            Vars["WindowHandles"] = driver.WindowHandles;
            driver.FindElement(By.LinkText("Street View")).Click();
            Vars["win7152"] = WaitForWindow(2000);
            driver.SwitchTo().Window(Vars["win7152"].ToString());
            driver.SwitchTo().Window(Vars["root"].ToString());
            driver.FindElement(By.CssSelector(".link_mapa:nth-child(3) > .titulo-menu")).Click();
            driver.FindElement(By.Id("select2-device-container")).Click();
            driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Down);
            driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("bruno");
            driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);
            driver.FindElement(By.Id("percursos")).Click();
            driver.FindElement(By.Id("percursos")).SendKeys(Keys.Down);
            driver.FindElement(By.Id("percursos")).Click();
            driver.FindElement(By.Id("verRota")).Click();
            {
                var element = driver.FindElement(By.Id("voltar"));
                var builder = new Actions(driver);
                builder.MoveToElement(element).Perform();
            }
            Thread.Sleep(3000);
            {
                var element = driver.FindElement(By.TagName("body"));
                var builder = new Actions(driver);
                builder.MoveToElement(element, 0, 0).Perform();
            }
            driver.FindElement(By.CssSelector(".link_mapa:nth-child(5) > .titulo-menu")).Click();
            driver.FindElement(By.CssSelector(".row")).Click();
            driver.FindElement(By.CssSelector(".fa-angle-down")).Click();
            driver.FindElement(By.LinkText("Sair")).Click();
        }

        [Test]
        public void Login()
        {
            driver.Navigate().GoToUrl("https://beta.jns.net.br/");
            driver.Manage().Window.Size = new System.Drawing.Size(1616, 855);
            driver.FindElement(By.Id("cpf")).SendKeys("998.604.568-99");
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).SendKeys("102030");
            driver.FindElement(By.Id("submit-acesso")).Click();
        }

        [Test]
        public void LoginLogout()
        {
            driver.Navigate().GoToUrl("https://beta.jns.net.br/");
            driver.Manage().Window.Size = new System.Drawing.Size(1616, 855);
            driver.FindElement(By.Id("cpf")).SendKeys("998.604.568-99");
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).SendKeys("102030");
            driver.FindElement(By.Id("submit-acesso")).Click();

            Thread.Sleep(5000);
            driver.FindElement(By.CssSelector(".rounded")).Click();
            driver.FindElement(By.Id("saida-usuario")).Click();
        }

        [Test]
        public void AveriguarLinksGerente()
        {
            driver.Navigate().GoToUrl("https://beta.jns.net.br/");
            driver.Manage().Window.Size = new System.Drawing.Size(1616, 855);
            driver.FindElement(By.Id("cpf")).Click();
            driver.FindElement(By.Id("cpf")).SendKeys("998.604.568-99");
            driver.FindElement(By.Id("senha")).Click();
            driver.FindElement(By.Id("senha")).SendKeys("102030");
            driver.FindElement(By.Id("submit-acesso")).Click();
            {
                var wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(50));
                wait.Until(driver => driver.FindElements(By.LinkText("In�cio")).Count > 0);
            }

            var elements = driver.FindElements(By.LinkText("In�cio"));
            Assert.True(elements.Count > 0);
            elements = driver.FindElements(By.LinkText("Cliente"));
            Assert.True(elements.Count > 0);
            elements = driver.FindElements(By.Id("dropdown-empresa"));
            Assert.True(elements.Count > 0);
            elements = driver.FindElements(By.Id("dropdown-rastreador"));
            Assert.True(elements.Count > 0);
            elements = driver.FindElements(By.Id("dropdown-usuario"));
            Assert.True(elements.Count > 0);
            elements = driver.FindElements(By.Id("dropdown-veiculo"));
            Assert.True(elements.Count > 0);
            elements = driver.FindElements(By.CssSelector(".fa-user-circle > path"));
            Assert.True(elements.Count > 0);
            elements = driver.FindElements(By.CssSelector(".badge-info"));
            Assert.True(elements.Count > 0);
            elements = driver.FindElements(By.CssSelector(".badge-danger"));
            Assert.True(elements.Count > 0);
        }

        [Test]
        public void ListarCompletoGerente()
        {
            Login();

            Thread.Sleep(5000);
            driver.FindElement(By.Id("dropdown-cliente")).Click();
            driver.FindElement(By.LinkText("Listar")).Click();
            driver.FindElement(By.Name("tabela-cliente_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-cliente_length"));
                dropdown.FindElement(By.XPath("//option[. = '50']")).Click();
            }

            driver.FindElement(By.Name("tabela-cliente_length")).Click();
            driver.FindElement(By.Name("tabela-cliente_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-cliente_length"));
                dropdown.FindElement(By.XPath("//option[. = '75']")).Click();
            }

            driver.FindElement(By.Name("tabela-cliente_length")).Click();
            driver.FindElement(By.Name("tabela-cliente_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-cliente_length"));
                dropdown.FindElement(By.XPath("//option[. = '100']")).Click();
            }

            driver.FindElement(By.Name("tabela-cliente_length")).Click();
            driver.FindElement(By.CssSelector("#tabela-cliente_filter .form-control")).Click();
            driver.FindElement(By.CssSelector("#tabela-cliente_filter .form-control")).SendKeys("pedro");
            driver.FindElement(By.CssSelector("#tabela-cliente_filter .form-control")).SendKeys(Keys.Enter);
            driver.FindElement(By.Id("dropdown-cliente")).Click();
            driver.FindElement(By.LinkText("Cadastrar")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("dropdown-rastreador")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Listar")).Click();
            driver.FindElement(By.Name("tabela-rastreador_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-rastreador_length"));
                dropdown.FindElement(By.XPath("//option[. = '50']")).Click();
            }

            driver.FindElement(By.Name("tabela-rastreador_length")).Click();
            driver.FindElement(By.Name("tabela-rastreador_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-rastreador_length"));
                dropdown.FindElement(By.XPath("//option[. = '75']")).Click();
            }

            driver.FindElement(By.Name("tabela-rastreador_length")).Click();
            driver.FindElement(By.Name("tabela-rastreador_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-rastreador_length"));
                dropdown.FindElement(By.XPath("//option[. = '100']")).Click();
            }

            driver.FindElement(By.Name("tabela-rastreador_length")).Click();
            driver.FindElement(By.CssSelector(".buttons-excel > span")).Click();
            Vars["WindowHandles"] = driver.WindowHandles;
            //print da p�gina causa travamento
            /*driver.FindElement(By.CssSelector(".buttons-print")).Click();
            Vars["win2215"] = WaitForWindow(2000);
            Vars["root"] = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(Vars["win2215"].ToString());
            driver.SwitchTo().Window(Vars["root"].ToString());*/
            driver.FindElement(By.CssSelector(".buttons-pdf > span")).Click();
            driver.FindElement(By.Id("dropdown-usuario")).Click();
            driver.FindElement(By.LinkText("Listar")).Click();
            driver.FindElement(By.Name("tabela-usuario_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-usuario_length"));
                dropdown.FindElement(By.XPath("//option[. = '50']")).Click();
            }

            driver.FindElement(By.Name("tabela-usuario_length")).Click();
            driver.FindElement(By.Name("tabela-usuario_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-usuario_length"));
                dropdown.FindElement(By.XPath("//option[. = '75']")).Click();
            }

            driver.FindElement(By.Name("tabela-usuario_length")).Click();
            driver.FindElement(By.Name("tabela-usuario_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-usuario_length"));
                dropdown.FindElement(By.XPath("//option[. = '100']")).Click();
            }

            driver.FindElement(By.Name("tabela-usuario_length")).Click();
            driver.FindElement(By.Id("dropdown-veiculo")).Click();
            driver.FindElement(By.LinkText("Listar")).Click();
            driver.FindElement(By.Id("dropdown-veiculo")).Click();
            driver.FindElement(By.CssSelector("#dropdown-sessao > .rounded")).Click();
        }
    }
}