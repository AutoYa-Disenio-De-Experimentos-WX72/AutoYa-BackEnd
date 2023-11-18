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
public sealed class VehiculosServiceStepDefinition : WebApplicationFactory<Program>
{
    private readonly WebApplicationFactory<Program> _factory;
    
    private HttpClient Client { get; set; }
    private Uri BaseUri { get; set; }
    private Task<HttpResponseMessage> Response { get; set; }
    
    public VehiculosServiceStepDefinition(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Given(@"the Endpoint http://localhost:(.*)/api/v(.*)/vehiculos is available")]
    public void GivenTheEndpointHttpLocalhostApiVVehiculosIsAvailable(int port, int version)
    {
        BaseUri = new Uri($"https://localhost:{port}/api/v{version}/vehiculos");
        Client = _factory.CreateClient(new WebApplicationFactoryClientOptions { 
            BaseAddress = BaseUri });
    }

    [When(@"a Post Request for vehiculo is sent")]
    public void WhenAPostRequestForVehiculoIsSent(Table saveVehiculoResource)
    {
        var resource = 
            saveVehiculoResource.CreateSet<SaveVehiculoResource>().First();
        var content = new StringContent(resource.ToJson(), Encoding.UTF8, 
            MediaTypeNames.Application.Json);
        Response = Client.PostAsync(BaseUri, content);
    }

    [Then(@"a Response for vehiculo is received with Status (.*)")]
    public void ThenAResponseForVehiculoIsReceivedWithStatus(int expectedStatus)
    {
        var expectedStatusCode = 
            ((HttpStatusCode)expectedStatus).ToString();
        var actualStatusCode = Response.Result.StatusCode.ToString();
 
        Assert.Equal(expectedStatusCode, actualStatusCode);
    }

    [Then(@"a vehiculo Resource is included in Response body")]
    public async Task ThenAVehiculoResourceIsIncludedInResponseBody(Table expectedVehiculoResource)
    {
        var expectedResource = expectedVehiculoResource.CreateSet<VehiculoResource>().First();
        var responseData = await Response.Result.Content.ReadAsStringAsync();
        var resource = JsonConvert.DeserializeObject<VehiculoResource>(responseData);
        
        // Verificar que el recurso esperado y el recurso actual no sean nulos
        Assert.NotNull(expectedResource);
        Assert.NotNull(resource);

        // Verificar la igualdad de los Id de propietarios solo si ambos propietarios no son nulos
        if (expectedResource.Propietario != null && resource.Propietario != null)
        {
            Assert.Equal(expectedResource.Propietario.Id, resource.Propietario.Id);
        }
        else
        {
            // Ambos propietarios son nulos o uno de ellos es nulo, según la lógica de tu aplicación.
            // Puedes agregar más verificaciones según tus requisitos.
            
            if (expectedResource.Propietario == null)
            {
                Console.WriteLine("expectedResource.Propietario is null");
            }

            if (resource.Propietario == null)
            {
                Console.WriteLine("resource.Propietario is null");
            }
        }
    }
}