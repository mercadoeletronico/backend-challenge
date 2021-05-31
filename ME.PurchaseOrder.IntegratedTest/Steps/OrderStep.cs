using BoDi;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ME.PurchaseOrder.IntegratedTest.Steps
{
    [Binding]
    public sealed class OrderStep
    {
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;
        private string _body;
        private readonly IObjectContainer _objectContainer;

        public OrderStep(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void Setup()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, errors) => true;

            _restClient = new RestClient();
            _restRequest = new RestRequest();
            _restResponse = new RestResponse();
            _objectContainer.RegisterInstanceAs(_restClient);
            _objectContainer.RegisterInstanceAs(_restRequest);
            _objectContainer.RegisterInstanceAs(_restResponse);
        }

        [Given(@"the host is '(.*)'")]
        public void GivenHost(string uri) => _restClient.BaseUrl = new Uri(uri);

        [Given(@"the endpoint is '(.*)'")]
        public void GivenEndpoint(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"the method is '(.*)'")]
        public void GivenMethodHttp(string method)
        {
            switch (method.ToUpper())
            {
                case "GET": _restRequest.Method = Method.GET; break;
                case "PUT": _restRequest.Method = Method.PUT; break;
                case "POST": _restRequest.Method = Method.POST; break;
                case "DELETE": _restRequest.Method = Method.DELETE; break;
            }
        }

        [Given("that parameter '(.*)' is '(.*)'")]
        public void GivenUrlParameter(string parametro, string valor) => _restRequest.AddParameter(parametro, valor, ParameterType.UrlSegment);

        [Given("The body")]
        public void GivenParametrosDaRota(Table table)
        {
            var obj = new object();
            table.FillInstance(obj);
            _body = JsonSerializer.Serialize(obj);
        }

        [When("calling request")]
        public void WhenExecute() => Execute();

        [Then("The response is (.*)")]
        public void ThenValidaResposta(HttpStatusCode codigoDeResposta) => Assert.AreEqual(codigoDeResposta, _restResponse.StatusCode);

        private void Execute()
        {
            if (_restRequest.Method != Method.GET)
            {
                _restRequest.AddHeader("Content-Type", "application/json");
                _restRequest.AddJsonBody(_body);
            }

            _restResponse = _restClient.Execute(_restRequest);
        }
    }
}