using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TesteUnidade.PageObject.Navbar
{
    class NavbarPage
    {
        private readonly RemoteWebDriver _driver;

        public NavbarPage(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Perfil => _driver.FindElementById("dropdown-perfil");
        public IWebElement Atualizacao => _driver.FindElementByClassName("badge-info");
        public IWebElement Inicio => _driver.FindElementByLinkText("Início");
        public IWebElement Chip => _driver.FindElementByLinkText("Chip");
        public IWebElement Cliente => _driver.FindElementByLinkText("Cliente");
        public IWebElement Dispositivo => _driver.FindElementByLinkText("Dispositivo");
        public IWebElement Empresa => _driver.FindElementByLinkText("Empresa");
        public IWebElement Rastreador => _driver.FindElementByLinkText("Rastreador");
        public IWebElement Usuario => _driver.FindElementByLinkText("Usuário");
        public IWebElement Veiculo => _driver.FindElementByLinkText("Veículo");
        public IWebElement Notificacao => _driver.FindElementByClassName("badge-danger");
        public IWebElement Sessao => _driver.FindElementById("dropdown-sessao");
    }
}
