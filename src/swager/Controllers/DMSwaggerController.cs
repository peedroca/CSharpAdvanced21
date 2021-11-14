using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using swager.DMSwagger;

namespace swager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DMSwaggerReaderController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Models.DMSwagger> Consultar()
        {
            var documentation = new SwaggerDocumentation()
                .WithController(typeof(ProductController))
                .WithController(typeof(ClientController));

            return Ok(documentation.GetDMSwagger());
        }
    }
}