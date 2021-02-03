using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System.Threading;
using TesteUnidade.PageObject.Navbar;
using System;
using OpenQA.Selenium;
using TesteUnidade;
using OpenQA.Selenium.Support.UI;

namespace Rastreamento.Testes
{
    [TestFixture]
    public class Navbar
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

        [Parallelizable]
        public void ItensNavbar()
        {
            try
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();

                login.SetUp();
                login.Acesso();

                driver = login.driver;

                var pagina = new TesteUnidade.PageObject.Navbar.Navbar(driver);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => pagina.Perfil.Displayed);

                Assert.IsTrue(pagina.Perfil.Displayed);
                Assert.IsTrue(pagina.Atualizacao.Displayed);
                Assert.IsTrue(pagina.Inicio.Displayed);
                Assert.IsTrue(pagina.Chip.Displayed);
                Assert.IsTrue(pagina.Cliente.Displayed);
                Assert.IsTrue(pagina.Dispositivo.Displayed);
                Assert.IsTrue(pagina.Empresa.Displayed);
                Assert.IsTrue(pagina.Rastreador.Displayed);
                Assert.IsTrue(pagina.Usuario.Displayed);
                Assert.IsTrue(pagina.Veiculo.Displayed);
                Assert.IsTrue(pagina.Notificacao.Displayed);
                Assert.IsTrue(pagina.Sessao.Displayed); 

                watch.Stop();
            }
            catch (NoSuchElementException erro)
            {
                Console.WriteLine(erro);
                throw erro;
            }
            catch (AssertionException erro)
            {
                Console.WriteLine(erro);
                throw erro;
            }
        }
    }
}