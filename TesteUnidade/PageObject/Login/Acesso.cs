using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TesteUnidade.PageObject.Login
{
    class Acesso
    {
        private readonly RemoteWebDriver _driver;

        public Acesso(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement Cpf => _driver.FindElementById("cpf");
        public IWebElement Senha => _driver.FindElementById("senha");
        public IWebElement Entrar => _driver.FindElementById("submit-acesso");

        public void EfetuarLogin() => Entrar.Click();
    }
}
