using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlaygroundSSIS.Data;
using PlaygroundSSIS.Entities;
using System;

namespace PlaygroundSSIS.Controllers
{
    [ApiController]
    [Route("api/turma-lyceum")]
    public class TurmaLyceumController : ControllerBase
    {
        private readonly LyceumDbContext _context;

        public TurmaLyceumController(LyceumDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_context.TurmasLyceum.ToList());

        [HttpPost]
        public IActionResult Post([FromBody] TurmaLyceum turma)
        {
            _context.TurmasLyceum.Add(turma);
            _context.SaveChanges();
            return Created($"api/turmas/{turma.Id}", turma);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TurmaLyceum turma)
        {
            if (id != turma.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingTurma = _context.TurmasLyceum.Find(id);
            if (existingTurma == null)
            {
                return NotFound();
            }

            existingTurma.Nome = turma.Nome;
            existingTurma.Email = turma.Email;
            existingTurma.Disciplina = turma.Disciplina;
            existingTurma.NumeroAlunos = turma.NumeroAlunos;
            existingTurma.Curso = turma.Curso;
            existingTurma.Docente = turma.Docente;
            existingTurma.Sala = turma.Sala;
            existingTurma.Predio = turma.Predio;
            existingTurma.DataInicio = turma.DataInicio;
            existingTurma.DataFim = turma.DataFim;
            existingTurma.Periodo = turma.Periodo;

            //_context.Entry(existingTurma).State = EntityState.Modified;
            //_context.TurmasLyceum.Update(existingTurma);
            //_context.SaveChanges();

            _context.Entry(existingTurma).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }
    }
}
