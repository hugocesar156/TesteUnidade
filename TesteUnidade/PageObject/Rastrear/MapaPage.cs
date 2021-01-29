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
        public IWebElement AreaEmpresa => _driver.FindElementByXPath("//form[@id='formulario-empresa']/div[2]/div/div/button/div/div/div");
        public IWebElement CampoEmpresa => _driver.FindElementByXPath("//input[@type='search']");
        public IWebElement AreaVeiculo => _driver.FindElementByXPath("//form[@id='formulario-veiculo']/div/div/div/button/div/div/div");
        public IWebElement CampoVeiculo => _driver.FindElementByXPath("//input[@type='search']");
        public IWebElement AreaRastreador => _driver.FindElementByXPath("//form[@id='formulario-rastreador']/div/div/div/button/div/div/div");
        public IWebElement AreaTrajeto => _driver.FindElementByXPath("//form[@id='formulario-trajeto']/div[3]/div/div/button/div/div/div");
        public IWebElement CampoTrajeto => _driver.FindElementByXPath("//input[@type='search']");
        public IWebElement ConfirmarLocalizacao => _driver.FindElementById("submit-localizacao");
        public IWebElement ConfirmarTrajeto => _driver.FindElementById("submit-trajeto");
        public IWebElement PopUp => _driver.FindElementByClassName("leaflet-marker-icon");
    }
}