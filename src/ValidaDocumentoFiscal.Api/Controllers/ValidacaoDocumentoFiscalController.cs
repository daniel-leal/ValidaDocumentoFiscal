using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ValidaDocumentoFiscal.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ValidacaoDocumentoFiscalController : Controller
    {
        
        [HttpGet("{documentoFiscal}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ValidarDocumentoFiscal([FromRoute] string documentoFiscal)
        {
            if (Utils.DocumentoFiscalUtils.IsValid(documentoFiscal))
                return Ok(new { message = "Documento Fiscal Válido" });

            return BadRequest(new { message = "Documento Fiscal Inválido" });
        }
    }
}
