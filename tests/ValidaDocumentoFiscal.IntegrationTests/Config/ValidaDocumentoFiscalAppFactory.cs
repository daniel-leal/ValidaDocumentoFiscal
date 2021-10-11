using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ValidaDocumentoFiscal.IntegrationTests.Config
{
    public class ValidaDocumentoFiscalAppFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<TStartup>();
            builder.UseEnvironment("Testing");
        }
    }
}
