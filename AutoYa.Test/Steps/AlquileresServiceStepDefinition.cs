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
public sealed class AlquileresServiceStepDefinition : WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> _factory;
    
    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    private Task<HttpResponseMessage> Response { get; set; }
    
    public AlquileresServiceStepDefinition(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Given(@"the Endpoint http://localhost:(.*)/api/v(.*)/alquileres is available")]
    public void GivenTheEndpointHttpLocalhostApiVAlquileresIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/alquileres");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { 
            BaseAddress = BaseUri });
    }

    [When(@"a Post Request for alquiler is sent")]
    public void WhenAPostRequestForAlquilerIsSent(Table saveAlquilerResource)
    {
        var resource = saveAlquilerResource.CreateSet<SaveAlquilerResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"a Response for alquiler is received with Status (.*)")]
    public void ThenAResponseForAlquilerIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = 
            ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
 
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"an alquiler Resource is included in Response body")]
    public async Task ThenAnAlquilerResourceIsIncludedInResponseBody(Table expectedAlquilerResource)
    {
        var expectedResource = 
            expectedAlquilerResource.CreateSet<AlquilerResource>().First();
        var responseData = await 
            Response.Result.Content.ReadAsStringAsync();
        var resource = 
            JsonConvert.DeserializeObject<AlquilerResource>(responseData);
        Assert.Equal(expectedResource.ArrendatarioId, resource.ArrendatarioId);
        Assert.Equal(expectedResource.PropietarioId, resource.PropietarioId);
        Assert.Equal(expectedResource.VehiculoId, resource.VehiculoId);
    }
}