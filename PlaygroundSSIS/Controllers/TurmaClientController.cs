using Microsoft.AspNetCore.Mvc;
using PlaygroundSSIS.Entities;
using PlaygroundSSIS.Services;

namespace PlaygroundSSIS.Controllers
{
    [ApiController]
    [Route("api/turma-client")]
    public class TurmaClientController : ControllerBase
    {

        public TurmaClientController()
        {
            
        }

        [HttpGet]
        public IActionResult GetTurmas([FromServices] TurmaClientService service)
        {
            var result = service.GetTurmaCliente();
            return Ok();
        }

        [HttpPost]
        public IActionResult PostTurma([FromBody] TurmaClient turma, [FromServices] TurmaClientService service)
        {
            var result = service.AddTurmaClient(turma);
            return Created($"api/turma-client/{turma.Id}", turma);
        }
    }
}
