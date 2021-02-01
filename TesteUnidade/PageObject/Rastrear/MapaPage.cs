using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace TesteUnidade.PageObject.Rastrear
{
    class MapaPage
    {
        private readonly RemoteWebDriver _driver;

        public MapaPage(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement BuscarVeiculo => _driver.FindElementByLinkText("Buscar veículo");
        public IWebElement BuscarTrajeto => _driver.FindElementByLinkText("Buscar trajeto");
        public IWebElement Empresa => _driver.FindElementByXPath("//form[@id='formulario-empresa']/div[2]/div/div/button/div/div/div");
        public IWebElement Veiculo => _driver.FindElementByXPath("//form[@id='formulario-veiculo']/div/div/div/button/div/div/div");
        public IWebElement Rastreador => _driver.FindElementByXPath("//form[@id='formulario-rastreador']/div/div/div/button/div/div/div");
        public IWebElement Trajeto => _driver.FindElementByXPath("//form[@id='formulario-trajeto']/div[3]/div/div/button/div/div/div");
        public IWebElement ConfirmarLocalizacao => _driver.FindElementById("submit-localizacao");
        public IWebElement ConfirmarTrajeto => _driver.FindElementById("submit-trajeto");
        public IWebElement PopUp => _driver.FindElementByClassName("leaflet-marker-icon");
    }
}