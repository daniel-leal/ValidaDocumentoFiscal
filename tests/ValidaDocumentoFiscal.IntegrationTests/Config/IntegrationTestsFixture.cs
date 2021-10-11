using System;
using System.Net.Http;
using Xunit;

namespace ValidaDocumentoFiscal.IntegrationTests.Config
{
    [CollectionDefinition(nameof(IntegrationApiTestFixtureCollection))]
    public class IntegrationApiTestFixtureCollection : ICollectionFixture<IntegrationTestsFixture<StartupApiTests>>
    { }

    public class IntegrationTestsFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly ValidaDocumentoFiscalAppFactory<TStartup> Factory;
        public HttpClient Client;

        public IntegrationTestsFixture()
        {
            var clientOptions = new Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactoryClientOptions()
            {
                HandleCookies = false,
                BaseAddress = new Uri("https://localhost:5001"),
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 7
            };

            Factory = new ValidaDocumentoFiscalAppFactory<TStartup>();
            Client = Factory.CreateClient(clientOptions);
        }

        public void Dispose()
        {
            Client.Dispose();
            Factory.Dispose();
        }
    }
}
