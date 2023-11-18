using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using AutoYa_Backend.AutoYa.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace AutoYa.Test.Steps;

[Binding]
public sealed class PropietariosServiceStepDefinition : WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> _factory;
    
    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    private Task<HttpResponseMessage> Response { get; set; }
    
    public PropietariosServiceStepDefinition(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    [Given(@"the Endpoint http://localhost:(.*)/api/v(.*)/propietarios is available")]
    public void GivenTheEndpointHttpLocalhostApiVPropietariosIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/propietarios");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { 
            BaseAddress = BaseUri });
    }

    [When(@"a Post Request for propietario is sent")]
    public void WhenAPostRequestForPropietarioIsSent(Table savePropietarioResource)
    {
        var resource = 
            savePropietarioResource.CreateSet<SavePropietarioResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, 
            MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"an propietario Resource is included in Response body")]
    public async Task ThenAnPropietarioResourceIsIncludedInResponseBody(Table expectedPropietarioResource)
    {
        var expectedResource = 
            expectedPropietarioResource.CreateSet<PropietarioResource>().First();
        var responseData = await 
            Response.Result.Content.ReadAsStringAsync();
        var resource = 
            JsonConvert.DeserializeObject<PropietarioResource>(responseData);
        Assert.Equal(expectedResource.Correo, resource.Correo);
    }

    [Given(@"An propietario is already stored")]
    public async void GivenAnPropietarioIsAlreadyStored(Table savePropietarioResource)
    {
        var resource = 
            savePropietarioResource.CreateSet<SavePropietarioResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, 
            MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
        var responseData = await 
            Response.Result.Content.ReadAsStringAsync();
        var responseResource = 
            JsonConvert.DeserializeObject<PropietarioResource>(responseData);
        Assert.Equal(resource.Correo, responseResource.Correo);
    }

    [Then(@"An Error Message for propietario is returned with value ""(.*)""")]
    public void ThenAnErrorMessageForPropietarioIsReturnedWithValue(string expectedMessage)
    {
        var message = Response.Result.Content.ReadAsStringAsync().Result;
        Assert.Equal(expectedMessage, message);
    }

    [Then(@"a Response for propietario is received with Status (.*)")]
    public void ThenAResponseForPropietarioIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = 
            ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
 
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }
}