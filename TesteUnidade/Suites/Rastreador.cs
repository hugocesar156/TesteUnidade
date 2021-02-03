using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Rastreamento.Testes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rastreamento.Testes
{
    class Rastreador
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
        public void Listar()
        {
            login.SetUp();
            login.Acesso();
            driver = login.driver;

            driver.FindElement(By.Id("dropdown-rastreador")).Click();
            driver.FindElement(By.LinkText("Listar")).Click();
            driver.FindElement(By.Name("tabela-rastreador_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-rastreador_length"));
                dropdown.FindElement(By.XPath("//option[. = '50']")).Click();
            }
            driver.FindElement(By.Name("tabela-rastreador_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-rastreador_length"));
                dropdown.FindElement(By.XPath("//option[. = '75']")).Click();
            }
            driver.FindElement(By.Name("tabela-rastreador_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-rastreador_length"));
                dropdown.FindElement(By.XPath("//option[. = '100']")).Click();
            }
            driver.FindElement(By.Name("tabela-rastreador_length")).Click();
            driver.FindElement(By.CssSelector(".buttons-excel > span")).Click();
            driver.FindElement(By.CssSelector(".buttons-print")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).Click();
            driver.FindElement(By.CssSelector(".dataTables_scrollHeadInner .sorting_asc")).Click();
            driver.FindElement(By.CssSelector(".sorting_desc")).Click();
            driver.FindElement(By.CssSelector(".dataTables_scrollHeadInner .sorting:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".sorting_asc:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector(".dataTables_scrollHeadInner .sorting:nth-child(3)")).Click();
            driver.FindElement(By.CssSelector(".sorting_asc")).Click();
            driver.FindElement(By.CssSelector(".dataTables_scrollHeadInner .sorting:nth-child(4)")).Click();
            driver.FindElement(By.CssSelector(".sorting_asc")).Click();
            driver.FindElement(By.CssSelector(".dataTables_scrollHeadInner .sorting:nth-child(5)")).Click();
            driver.FindElement(By.CssSelector(".sorting_asc")).Click();
            driver.FindElement(By.Id("tabela-rastreador_filter")).Click();
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).SendKeys("claro" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).SendKeys("arqia" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).SendKeys("indefinido" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).SendKeys("gt06" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).SendKeys("89550" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).SendKeys("3526" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).SendKeys("3545" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-rastreador_filter .form-control")).SendKeys("8652" + Keys.Enter);
            driver.FindElement(By.CssSelector(".fa-info-circle > path")).Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.CssSelector("#modal-detalhamento span")).Displayed);
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector("#modal-detalhamento span")).Click();
            driver.FindElement(By.CssSelector(".btn-block > .btn-outline-info:nth-child(2)")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }
    }
}