using System.Net;
using System.Threading.Tasks;
using ValidaDocumentoFiscal.IntegrationTests.Config;
using Xunit;

namespace ValidaDocumentoFiscal.IntegrationTests
{
    [Collection(nameof(IntegrationApiTestFixtureCollection))]
    public class ValidaDocumentoFiscalApiTests
    {
        private readonly IntegrationTestsFixture<StartupApiTests> _testsFixture;

        public ValidaDocumentoFiscalApiTests(IntegrationTestsFixture<StartupApiTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Trait("Categoria", "Documento Fiscal (CPF ou CNPJ) válidos")]
        [Theory(DisplayName = "CPFs ou CNPJs válidos")]
        [InlineData("54422545094")]
        [InlineData("57755013065")]
        [InlineData("67851424070")]
        [InlineData("067.741.400-50")]
        [InlineData("08980436000104")]
        [InlineData("96744137000120")]
        [InlineData("31188249000104")]
        [InlineData("56907240000129")]
        [InlineData("47646141000140")]
        public async Task Consulta_DocumentoFiscalValido_DeveRetornarSucesso(string documentoFiscal)
        {
            // Arrange & Act
            var resp = await _testsFixture.Client.GetAsync($"v1/ValidacaoDocumentoFiscal/{documentoFiscal}");

            // Assert
            Assert.True(resp.IsSuccessStatusCode);
        }

        [Trait("Categoria", "Documento Fiscal (CPF ou CNPJ) inválidos")]
        [Theory(DisplayName = "CPFs ou CNPJs inválidos")]
        [InlineData("11111111111")]
        [InlineData("22222222222")]
        [InlineData("123456")]
        public async Task Consulta_DocumentoFiscalInvalido_DeveRetornarSucesso(string documentoFiscal)
        {
            // Arrange & Act
            var resp = await _testsFixture.Client.GetAsync($"v1/ValidacaoDocumentoFiscal/{documentoFiscal}");

            // Assert
            Assert.True(resp.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
