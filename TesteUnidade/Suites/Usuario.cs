using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Rastreamento.Testes
{
    class Usuario
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
            Login.Cpf = "138.020.536-05";
            Login.Senha = "102030";

            login.SetUp();
            login.Acesso();
            driver = login.driver;

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
            driver.FindElement(By.Name("tabela-usuario_length")).Click();
            {
                var dropdown = driver.FindElement(By.Name("tabela-usuario_length"));
                dropdown.FindElement(By.XPath("//option[. = '25']")).Click();
            }
            driver.FindElement(By.Name("tabela-usuario_length")).Click();
            driver.FindElement(By.CssSelector(".buttons-copy > span")).Click();
            driver.FindElement(By.CssSelector(".buttons-excel > span")).Click();
            driver.FindElement(By.CssSelector(".buttons-print > span")).Click();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.FindElement(By.CssSelector(".buttons-pdf > span")).Click();
            driver.FindElement(By.CssSelector("#tabela-usuario_filter .form-control")).SendKeys("ana" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-usuario_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-usuario_filter .form-control")).SendKeys("anna" + Keys.Enter);
            driver.FindElement(By.CssSelector("#tabela-usuario_filter .form-control")).Clear();
            driver.FindElement(By.CssSelector("#tabela-usuario_filter .form-control")).SendKeys("12" + Keys.Enter);
            driver.FindElement(By.CssSelector(".dataTables_scrollHeadInner .sorting_asc")).Click();
            driver.FindElement(By.CssSelector(".sorting_desc")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector(".dataTables_scrollHeadInner .sorting:nth-child(2)")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector(".sorting_asc:nth-child(2)")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector(".dataTables_scrollHeadInner .sorting:nth-child(3)")).Click();
            Thread.Sleep(500);
            driver.FindElement(By.CssSelector(".sorting_asc")).Click();
        }
    }
}
