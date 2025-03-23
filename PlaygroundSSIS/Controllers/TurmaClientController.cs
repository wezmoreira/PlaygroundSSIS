using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaygroundSSIS.Data;
using PlaygroundSSIS.Entities;
using PlaygroundSSIS.Vo;

namespace PlaygroundSSIS.Controllers
{
    [ApiController]
    [Route("api/integracao-client")]
    public class TurmaClientController : ControllerBase
    {
        private readonly ClientDbContext _context;

        public TurmaClientController(ClientDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.Turmas.ToList());

        [HttpPost]
        public IActionResult Post([FromBody] TurmaIntegracao integracao)
        {
            if (integracao.TipoOperacao == "U")
            {
                return AtualizarTurma(integracao);
            }
            else
            {
                return AdicionarTurma(integracao);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private IActionResult AdicionarTurma(TurmaIntegracao integracao)
        {
            try
            {
                var turma = new TurmaClient
                {
                    Nome = integracao.Nome,
                    Email = integracao.Email,
                    Disciplina = integracao.Disciplina,
                    NumeroAlunos = integracao.NumeroAlunos,
                    Curso = integracao.Curso,
                    Docente = integracao.Docente,
                    Sala = integracao.Sala,
                    Predio = integracao.Predio,
                    DataInicio = integracao.DataInicio,
                    DataFim = integracao.DataFim,
                    Periodo = integracao.Periodo
                };


                _context.Turmas.Add(turma);
                _context.SaveChanges();
                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private IActionResult AtualizarTurma(TurmaIntegracao integracao)
        {
            try
            {

                var turma = _context.Turmas.FirstOrDefault(t => t.Id == integracao.TurmaId);

                if (turma == null)
                {
                    return NotFound("Turma não encontrada");
                }

                turma.Nome = integracao.Nome;
                turma.Email = integracao.Email;
                turma.Disciplina = integracao.Disciplina;
                turma.NumeroAlunos = integracao.NumeroAlunos;
                turma.Curso = integracao.Curso;
                turma.Docente = integracao.Docente;
                turma.Sala = integracao.Sala;
                turma.Predio = integracao.Predio;
                turma.DataInicio = integracao.DataInicio;
                turma.DataFim = integracao.DataFim;
                turma.Periodo = integracao.Periodo;

                _context.Entry(turma).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
