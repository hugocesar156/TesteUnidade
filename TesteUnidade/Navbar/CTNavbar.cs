﻿using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System.Threading;
using Login;
using TesteUnidade.PageObject.Navbar;

namespace Navbar
{
    [TestFixture]
    public class CTNavbar
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
        public void ItensNavbar()
        {
            login.SetUp();
            login.Acesso();

            driver = login.driver;
            Thread.Sleep(5000);

            var pagina = new NavbarPage(driver);
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
        }
    }
}