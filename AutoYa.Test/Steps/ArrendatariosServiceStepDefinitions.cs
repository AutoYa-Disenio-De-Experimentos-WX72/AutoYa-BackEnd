using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using AutoYa_Backend.AutoYa.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace AutoYa.Test.Steps;

[Binding]
public sealed class ArrendatarioServiceStepDefinitions : WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> _factory;
    
    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    private Task<HttpResponseMessage> Response { get; set; }
    
    public ArrendatarioServiceStepDefinitions(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Given(@"the Endpoint http://localhost:(.*)/api/v(.*)/arrendatarios is available")]
    public void GivenTheEndpointHttpLocalhostApiVArrendatariosIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/arrendatarios");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { 
            BaseAddress = BaseUri });
    }

    [When(@"a Post Request for arrendatario is sent")]
    public void WhenAPostRequestForArrendatarioIsSent(Table saveArrendatarioResource)
    {
        var resource = 
            saveArrendatarioResource.CreateSet<SaveArrendatarioResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, 
            MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"a Response is received with Status (.*)")]
    public void ThenAResponseIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = 
            ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
 
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"an Arrendatario Resource is included in Response body")]
    public async Task ThenAnArrendatarioResourceIsIncludedInResponseBody(Table expectedArrendatarioResource)
    {
        var expectedResource = 
            expectedArrendatarioResource.CreateSet<ArrendatarioResource>().First();
        var responseData = await 
            Response.Result.Content.ReadAsStringAsync();
        var resource = 
            JsonConvert.DeserializeObject<ArrendatarioResource>(responseData);
        Assert.Equal(expectedResource.Correo, resource.Correo);
    }

    [Given(@"An Arrendatario is already stored")]
    public async void GivenAnArrendatarioIsAlreadyStored(Table saveArrendatarioResource)
    {
        var resource = 
            saveArrendatarioResource.CreateSet<SaveArrendatarioResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, 
            MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
        var responseData = await 
            Response.Result.Content.ReadAsStringAsync();
        var responseResource = 
            JsonConvert.DeserializeObject<ArrendatarioResource>(responseData);
        Assert.Equal(resource.Correo, responseResource.Correo);
    }

    [Then(@"An Error Message for arrendatario is returned with value ""(.*)""")]
    public void ThenAnErrorMessageForArrendatarioIsReturnedWithValue(string expectedMessage)
    {
        var message = Response.Result.Content.ReadAsStringAsync().Result;
        Assert.Equal(expectedMessage, message);
    }
}