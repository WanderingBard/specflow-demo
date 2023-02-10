
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace WebApi.SystemTests.Steps
{
    [Binding]
    public class PlaceForecastSteps
    {
        private ForecastTestContext _context;

        public PlaceForecastSteps(ForecastTestContext context)
        {
            _context = context;
        }

        //[Given(@"the country name is Scotland")]
        //public void GivenTheCountryNameIsScotland()
        //{
        //    _context.PlaceName = "Scotland";
        //}

        [Given(@"the country name is (.*)")]
        public void GivenTheCountryNameIs(string countryName)
        {
            _context.PlaceName = countryName;
        }


        [When(@"The get place forecast is called")]
        public void WhenTheGetPlaceForecastIsCalled()
        {
            using HttpClient client = new HttpClient();
            var result = client.Send(new HttpRequestMessage
            {
                RequestUri = new Uri($"https://localhost:7159/WeatherForecast?placeName={_context.PlaceName}"),
                Method = HttpMethod.Get,
                Headers = 
                {
                    { "Accept", "application/json" }
                }
            });

            _context.ApiResponse = result;
        }

        //[Then(@"the summary is Freezing")]
        //public void ThenTheSummaryIsFreezing()
        //{
        //    var content = _context.ApiResponse.Content.ReadAsStringAsync().Result;
        //    var jsonContent = JObject.Parse(content);
        //    Assert.AreEqual("Freezing", jsonContent.Value<string>("summary"));
        //}

        //[Then(@"the summary is Chilly")]
        //public void ThenTheSummaryIsChilly()
        //{
        //    var content = _context.ApiResponse.Content.ReadAsStringAsync().Result;
        //    var jsonContent = JObject.Parse(content);
        //    Assert.AreEqual("Chilly", jsonContent.Value<string>("summary"));
        //}

        [Then(@"the summary is (.*)")]
        public void ThenTheSummaryIs(string summaryText)
        {
            var content = _context.ApiResponse.Content.ReadAsStringAsync().Result;
            var jsonContent = JObject.Parse(content);
            Assert.AreEqual(summaryText, jsonContent.Value<string>("summary"));
        }
    }
}
